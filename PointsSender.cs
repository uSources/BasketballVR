using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSender : MonoBehaviour
{
    public int points;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player")) {
            ScoreMananger.instance.scoreZone = points;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            ScoreMananger.instance.scoreZone = ScoreMananger.instance.defaultScoreZone;
        }
    }
}
