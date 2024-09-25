using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuidoPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip _shootingClip;
    [SerializeField][Range(0f, 1f)] float _shootingVolume = 1f;

    [Header("TakingDamage")]
    [SerializeField] AudioClip TakeDamageClip;
    [SerializeField][Range(0f, 1f)] float _volume = 1f;

    [Header("TakingDamageOnDestroy")]
    [SerializeField] AudioClip TakeDamageClipOnDestroy;
    [SerializeField][Range(0f, 1f)] float _volumeOnDestroy = 1f;

    static AuidoPlayer instance;


    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        //int instancecount = findobjectsoftype(gettype()).length;
        //if (instancecount > 1)
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(_shootingClip, _shootingVolume);
    }

    public void PlayTakeDamageClip()
    {
        PlayClip(TakeDamageClip, _volume);
    }


    public void PlayTakeDamageClipOnDestroy()
    {
        PlayClip(TakeDamageClipOnDestroy, _volumeOnDestroy);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}
