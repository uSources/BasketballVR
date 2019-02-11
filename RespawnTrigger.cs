using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RespawnTrigger : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {
            Debug.Log("Respawning");
            collision.gameObject.GetComponent<BallBehaviour>().AttachToHand(0,GrabTypes.Grip);
          
        }
    }
}
