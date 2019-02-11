using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR;

public class ScoreMananger : MonoBehaviour
{

    //Puntos actuales
    public int score = 0;

    //Tiempo restante
    public float time = 30f;

    //Es el tiempo infinito?
    public bool unlimitedTime = true;

    //La zona de puntuaje que se encuentra en jugador
    public int scoreZone = 2;

    //La zona por defecto que se aplicara si no se encuentra ninguna zona de puntuaje
    public int defaultScoreZone;

    //El juego esta iniciado?
    public bool isPlaying = true;

    public AudioClip airHorn;

    public TextMeshProUGUI scoreGUI;

    public TextMeshProUGUI timeGUI;

    //instance
    public static ScoreMananger instance = null;


    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

    }


    //Actualizar el marcador de puntuaje
    public void UpdateScore()
    {
        if (isPlaying) {
            this.score += scoreZone;
            scoreGUI.SetText(this.score + "");
        }
        
    }


    //En caso de que el tiempo sea infinito este juego no acaba y el marcado de tiempo no se actualiza
    //En el otro caso se actualizan ambos
    private void Update()
    {
        if (unlimitedTime || !isPlaying) return;

        if (!isGameEnd())
        {
            time -= Time.deltaTime;
            timeGUI.SetText((int)this.time + "");
        }
        else {
            Debug.Log("False");
            isPlaying = false;
            GetComponent<AudioSource>().PlayOneShot(airHorn);
            StartCoroutine(goToMainMenu());
        }
    }

    //Ha termiando el tiempo?
    private bool isGameEnd() {

        if (time <= 0)
        {
            return true;
        }
        return false;
    }

    //Empezar el juego
    public void StartGame()
    {
        Debug.Log(this.transform.name);
        Debug.Log("Game start");
        isPlaying = true;
        //ball.gameObject.SetActive(true);
        //ball.AttachToHand(0, Valve.VR.InteractionSystem.GrabTypes.Scripted);
    }

    IEnumerator goToMainMenu() {
        yield return new WaitForSeconds(2f);
        ScoreMananger.instance = null;
        //Go to main Menu

        GetComponent<SteamVR_LoadLevel>().Trigger();
    }

}
