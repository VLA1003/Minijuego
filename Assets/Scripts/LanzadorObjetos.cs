using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzadorObjetos : MonoBehaviour
{
    public GameObject prefabPremio;
    public GameObject prefabObstaculo;
    public Transform puntoLanzamiento;
    public float fuerzaLanzamientoMinima = 5f;
    public float fuerzaLanzamientoMaxima = 10f;
    public float tiempoEntreLanzamientos = 0.5f;

    public float vidaObjetos = 3f;

    private float tiempoProximoLanzamiento;

    void Update()
    {
        if (Time.time > tiempoProximoLanzamiento)
        {
            GameObject objectToLaunch = GetRandomObject();
            LaunchObject(objectToLaunch);
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

        if (rb != null)
        {
            float launchForce = Random.Range(fuerzaLanzamientoMinima, fuerzaLanzamientoMaxima);
            rb.AddForce(new Vector2(-launchForce, 0f), ForceMode2D.Impulse);
        }

        Destroy(launchedObject, vidaObjetos);
    }
}
