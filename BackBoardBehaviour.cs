using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBoardBehaviour : MonoBehaviour
{
    public AudioClip backBoardClip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            AudioSource.PlayClipAtPoint(backBoardClip, transform.position);
        }
    }
}
