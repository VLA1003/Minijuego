using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorColisiones : MonoBehaviour
{
    public int puntosPremio = 10; // Cantidad de puntos al colisionar con un premio
    public int puntosObstaculo = 5; // Cantidad de puntos restados al colisionar con un obst�culo

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si la colisi�n es con un premio
        if (other.CompareTag("Premio"))
        {
            HandlePrizeCollision(other.gameObject);
        }
        // Verifica si la colisi�n es con un obst�culo
        else if (other.CompareTag("Obstaculo"))
        {
            HandleObstacleCollision(other.gameObject);
        }
    }

    void HandlePrizeCollision(GameObject prizeObject)
    {
        // C�digo para gestionar la colisi�n con un premio
        // Por ejemplo, aumentar la puntuaci�n del jugador
        GameManager.Instance.SumarPuntos(puntosPremio);

        // Destruir el objeto colisionado
        Destroy(prizeObject);
    }

    void HandleObstacleCollision(GameObject obstacleObject)
    {
        // C�digo para gestionar la colisi�n con un obst�culo
        // Por ejemplo, restar puntos al jugador
        GameManager.Instance.RestarPuntos(puntosObstaculo);

        // Destruir el objeto colisionado
        Destroy(obstacleObject);
    }
}
