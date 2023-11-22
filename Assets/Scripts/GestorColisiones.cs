using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorColisiones : MonoBehaviour
{
    public int puntosPremio = 10;
    public int puntosObstaculo = 5;

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
        GameManager.Instance.SumarPuntos(puntosPremio);
        Destroy(prizeObject);
    }

    void ColisionObstaculo(GameObject obstacleObject)
    {
        GameManager.Instance.RestarPuntos(puntosObstaculo);
        Destroy(obstacleObject);
    }
}
