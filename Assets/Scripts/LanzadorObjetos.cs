using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanzadorObjetos : MonoBehaviour
{
    public GameObject prefabPremio;
    public GameObject prefabObstaculo;
    public Transform puntoLanzamiento;
    public float fuerzaLanzamientoMinima = 5f;
    public float fuerzaLanzamientoMaxima = 10f;
    public float tiempoEntreLanzamientos = 0.5f;
    public float vidaObjetos = 3f;

    public AudioClip sonidoLanzamiento;
    public AudioSource audioSource;

    private float tiempoProximoLanzamiento;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        string nombreEscena = SceneManager.GetActiveScene().name;

        if (nombreEscena == "Nivel 1")
        {
            tiempoEntreLanzamientos = 0.5f;
            fuerzaLanzamientoMinima = 5f;
            fuerzaLanzamientoMaxima = 10f;
        }
        else if (nombreEscena == "Nivel 2")
        {
            tiempoEntreLanzamientos = 0.3f;
            fuerzaLanzamientoMinima = 3f;
            fuerzaLanzamientoMaxima = 12f;
        }
    }

    void Update()
    {
        if (Time.time > tiempoProximoLanzamiento)
        {
            GameObject objectToLaunch = GetRandomObject();
            LaunchObject(objectToLaunch);
            if (sonidoLanzamiento != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoLanzamiento);
            }
            tiempoProximoLanzamiento = Time.time + tiempoEntreLanzamientos;
        }
    }

    GameObject GetRandomObject()
    {
        return Random.Range(0f, 1f) > 0.5f ? prefabPremio : prefabObstaculo;
    }

    void LaunchObject(GameObject objectToLaunch)
    {
        GameObject launchedObject = Instantiate(objectToLaunch, puntoLanzamiento.position, Quaternion.identity);
        Rigidbody2D rb = launchedObject.GetComponent<Rigidbody2D>();
        launchedObject.transform.localScale = Vector3.zero;

        if (rb != null)
        {
            float launchForce = Random.Range(fuerzaLanzamientoMinima, fuerzaLanzamientoMaxima);
            rb.AddForce(new Vector2(-launchForce, 0f), ForceMode2D.Impulse);
        }
        StartCoroutine(EscalarObjeto(launchedObject.transform, new Vector3(0.5f, 0.5f, 0.5f), 0.2f));

        Destroy(launchedObject, vidaObjetos);
    }

    IEnumerator EscalarObjeto(Transform transform, Vector3 targetScale, float duration)
    {
        float timeElapsed = 0f;
        Vector3 startScale = transform.localScale;

        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
