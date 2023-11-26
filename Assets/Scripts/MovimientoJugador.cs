using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidadMovimiento = 5f;

    public bool bocaAbierta = false;
    private Collider2D colliderBoca;
    private Animator animator;

    public AudioClip sonidoAbrirBoca;
    public AudioClip sonidoCerrarBoca;
    public AudioSource audioSource;

    private bool sonidoReproducido = false;

    void Start()
    {
        bocaAbierta = true;
        colliderBoca = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        if (colliderBoca != null)
        {
            colliderBoca.enabled = false;
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sonidoReproducido = false;
            AbrirBoca();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            sonidoReproducido = false;
            CerrarBoca();
        }
    }

    void AbrirBoca()
    {
        bocaAbierta = true;
        animator.SetBool("haAbiertoBoca", true);
        if (colliderBoca != null)
        {
            colliderBoca.enabled = true;
        }

        if (!sonidoReproducido && sonidoAbrirBoca != null)
        {
            audioSource.PlayOneShot(sonidoAbrirBoca);
            sonidoReproducido = true;
        }
    }

    void CerrarBoca()
    {
        bocaAbierta = false;
        animator.SetBool("haAbiertoBoca", false);
        if (colliderBoca != null)
        {
            colliderBoca.enabled = false;
        }

        if (!sonidoReproducido && sonidoCerrarBoca != null)
        {
            audioSource.PlayOneShot(sonidoCerrarBoca);
            sonidoReproducido = true;
        }
    }
}
