using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWolfAudio : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
