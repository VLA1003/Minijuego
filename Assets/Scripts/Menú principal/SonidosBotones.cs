using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SonidosBotones : MonoBehaviour
{
    public AudioClip sonidoHover; // Sonido al pasar el rat�n por encima
    public AudioClip sonidoClick; // Sonido al hacer clic
    private AudioSource audioSource;

    void Start()
    {
        // Obt�n el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Desactiva la reproducci�n autom�tica para que el sonido no comience a reproducirse autom�ticamente
        audioSource.playOnAwake = false;

        // Asigna el AudioClip al AudioSource
        audioSource.clip = sonidoHover;
    }

    // M�todo que se ejecuta cuando el rat�n pasa por encima del bot�n
    public void OnMouseOverButton()
    {
        // Reproduce el sonido al pasar el rat�n por encima
        audioSource.clip = sonidoHover;
        audioSource.Play();
    }

    // M�todo que se ejecuta cuando se hace clic en el bot�n
    public void OnButtonClick()
    {
        // Reproduce el sonido al hacer clic
        audioSource.clip = sonidoClick;
        audioSource.Play();

        // Puedes agregar aqu� cualquier otra l�gica que desees realizar cuando se hace clic en el bot�n
        Debug.Log("Bot�n clickeado");
    }
}
