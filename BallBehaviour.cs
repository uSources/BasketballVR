using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BallBehaviour : MonoBehaviour
{

    private Player player;

    public AudioClip bounceClip;

    private bool onHand = false;

    private void Awake()
    {
        //En el futuro deberias ser un sigleton, solamente puede haber un jugador en una partida offline
        player = FindObjectOfType<Player>();
    }

    //Nos permite devolver la pelota a la mano del personaje
    public void AttachToHand(int handId, GrabTypes grabType) {

        player.GetHand(handId).AttachObject(this.gameObject,GrabTypes.Scripted);

        //Hace vibrar el mando
        player.GetHand(handId).TriggerHapticPulse(800);

    }


    //A la hora de colisionar con algo
    public void OnCollisionEnter(Collision collision)
    {

        //En caso de que sea suelo suena un audio, como no se permiten poner dos tags he creado un nuevo tag
        //Para el modo 3ShootDuel
        if(collision.gameObject.CompareTag("Floor")){
            AudioSource.PlayClipAtPoint(bounceClip,transform.position);
        }

        //En este caso la pelota que ha colisionado el suelo no se puede volver a coger y al ShootDuelManager
        //le informa que una pelota ya no puede usarse, cuando te quedas sin pelotas el juego termina
        if (collision.gameObject.CompareTag("NotAllowedArea"))
        {
            if (GetComponent<Interactable>().enabled)
            {
                ShootDuelManager.instance.BallCount -= 1;
                GetComponent<Interactable>().enabled = false;
            }

            AudioSource.PlayClipAtPoint(bounceClip, transform.position);
            
        }
    }

    //Se utiliza para detectar si estas metiendo la pelota por la canasta con ella cogida en la mano
    public void setOnHand(bool state)
    {

        onHand = state;
    }

    public bool getOnHand()
    {

        return onHand;
    }
}
