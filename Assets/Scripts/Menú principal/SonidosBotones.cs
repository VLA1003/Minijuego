using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosBotones : MonoBehaviour
{
    public AudioClip sonidoClick;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sonidoClick;
    }

    public void ReproducirSonido()
    {
        audioSource.Play();
    }
}
