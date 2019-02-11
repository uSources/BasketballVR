using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{


    public AudioClip swishCip;

    public ParticleSystem particleSystem;


    IEnumerator Score(Collider other)
    {
        //Desactivamos durante un pequeño periodo de tiempo el trigger para evitar posibles dobles puntos
        GetComponent<SphereCollider>().enabled = false;
        //Actualizamos el marcador de puntos
        ScoreMananger.instance.UpdateScore();
        //Reproducimos un audio
        AudioSource.PlayClipAtPoint(swishCip, transform.position);
        //Reproducimos las particulas
        particleSystem.Play();
        //Esperamos medio segundo
        yield return new WaitForSeconds(0.5f);
        //Activamos el colider de nuevo
        GetComponent<SphereCollider>().enabled = true;
        
        
        
        //Te devuelve la pelota a la mano, desactivado temporalmente
        //other.gameObject.GetComponent<BallBehaviour>().AttachToHand(0, Valve.VR.InteractionSystem.GrabTypes.Scripted);
       
    }


    private void OnTriggerEnter(Collider other)
    {

        //En caso de que haya colisionado la bola y esta bola no este agarrada con la mano llama a una coroutina
        if (other.gameObject.CompareTag("Ball")) {

            if(!other.GetComponent<BallBehaviour>().getOnHand())
                StartCoroutine(Score(other));
          
        }
    }
}
