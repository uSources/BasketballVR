using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDuelManager : MonoBehaviour
{
    //Cantidad de bolas restantes
    public int BallCount = 0;

    public static ShootDuelManager instance = null;


    //Se crea un singleton
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


    // Recogemos la cantidad de bolas restantes que hay en la escena
    void Start()
    {
        BallCount = FindObjectsOfType<BallBehaviour>().Length;
    }

    //Miramos si las pelotas restantes son cero en caso de que sea cierto el juego termina
    void Update()
    {
        if (BallCount <= 0) {
            ScoreMananger.instance.time = 0;
        }
    }
}
