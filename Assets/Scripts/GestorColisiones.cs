using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorColisiones : MonoBehaviour
{
    public int puntosPremio = 10;
    public int puntosObstaculo = 5;

    public AudioClip sonidoPremio;
    public AudioClip sonidoObstaculo;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Premio"))
        {
            ColisionPremio(other.gameObject);
        }

        else if (other.CompareTag("Obstaculo"))
        {
            ColisionObstaculo(other.gameObject);
        }
    }

    void ColisionPremio(GameObject prizeObject)
    {
        if (sonidoPremio != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoPremio);
        }

        GameManager.Instance.SumarPuntos(puntosPremio);

        LeanTween.scale(prizeObject, new Vector3(0f, 0f, 1f), 0.1f).setOnComplete(() =>
        {
            Destroy(prizeObject);
        });
    }

    void ColisionObstaculo(GameObject obstacleObject)
    {
        if (sonidoObstaculo != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoObstaculo);
        }

        GameManager.Instance.RestarPuntos(puntosObstaculo);


        LeanTween.scale(obstacleObject, new Vector3(0f, 0f, 1f), 0.1f).setOnComplete(() =>
        {
            Destroy(obstacleObject);
        });
    }
}
