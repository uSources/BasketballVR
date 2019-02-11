using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnableZone : MonoBehaviour
{

    //En caso de que la bola colisione con este trigger la bola que ha colisionado vuelve a su mano
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) {
            other.gameObject.GetComponent<BallBehaviour>().AttachToHand(0, Valve.VR.InteractionSystem.GrabTypes.Scripted);
        }
    }
}
