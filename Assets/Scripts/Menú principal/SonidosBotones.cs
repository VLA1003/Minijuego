using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SonidosBotones : MonoBehaviour
{
    public AudioClip sonidoHover; // Sonido al pasar el ratón por encima
    public AudioClip sonidoClick; // Sonido al hacer clic
    private AudioSource audioSource;

    void Start()
    {
        // Obtén el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Desactiva la reproducción automática para que el sonido no comience a reproducirse automáticamente
        audioSource.playOnAwake = false;

        // Asigna el AudioClip al AudioSource
        audioSource.clip = sonidoHover;
    }

    // Método que se ejecuta cuando el ratón pasa por encima del botón
    public void OnMouseOverButton()
    {
        // Reproduce el sonido al pasar el ratón por encima
        audioSource.clip = sonidoHover;
        audioSource.Play();
    }

    // Método que se ejecuta cuando se hace clic en el botón
    public void OnButtonClick()
    {
        // Reproduce el sonido al hacer clic
        audioSource.clip = sonidoClick;
        audioSource.Play();

        // Puedes agregar aquí cualquier otra lógica que desees realizar cuando se hace clic en el botón
        Debug.Log("Botón clickeado");
    }
}
