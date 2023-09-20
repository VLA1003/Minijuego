using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject obstaculoPrefab;
    public GameObject premioPrefab;    
    public Transform origenDisparo;
    public float frecuenciaDisparo;
    public float fuerzaMinima = 5f;
    public float fuerzaMaxima = 8f;

    private float tiempoDesdeUltimoDisparo = 0f;

    private void Update()
    {
        tiempoDesdeUltimoDisparo += Time.deltaTime;

        if (tiempoDesdeUltimoDisparo >= frecuenciaDisparo)
        {
            tiempoDesdeUltimoDisparo = 0f;

            GameObject proyectilPrefab = Random.Range(0f, 1f) < 0.5f ? obstaculoPrefab : premioPrefab;

            GameObject proyectil = Instantiate(proyectilPrefab, origenDisparo.position, Quaternion.identity);

            Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
            if (rb)
            {
                Vector2 direccionDisparo = -origenDisparo.right;
                float fuerzaDisparo = Random.Range(fuerzaMinima, fuerzaMaxima);
                rb.AddForce(direccionDisparo * fuerzaDisparo, ForceMode2D.Impulse);
            }

            float vidaProyectil = 5.0f;
            Destroy(proyectil, vidaProyectil);
        }
    }
}
