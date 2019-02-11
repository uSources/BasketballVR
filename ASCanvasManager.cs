using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASCanvasManager : MonoBehaviour
{

    void PlayAudio(AudioClip clip)
    {

        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    void StartGame()
    {
        ScoreMananger.instance.StartGame();
    }
}
