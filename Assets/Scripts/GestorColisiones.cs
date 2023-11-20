using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorColisiones : MonoBehaviour
{
    public int puntosPremio = 10; // Cantidad de puntos al colisionar con un premio
    public int puntosObstaculo = 5; // Cantidad de puntos restados al colisionar con un obstáculo

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si la colisión es con un premio
        if (other.CompareTag("Premio"))
        {
            HandlePrizeCollision(other.gameObject);
        }
        // Verifica si la colisión es con un obstáculo
        else if (other.CompareTag("Obstaculo"))
        {
            HandleObstacleCollision(other.gameObject);
        }
    }

    void HandlePrizeCollision(GameObject prizeObject)
    {
        // Código para gestionar la colisión con un premio
        // Por ejemplo, aumentar la puntuación del jugador
        GameManager.Instance.SumarPuntos(puntosPremio);

        // Destruir el objeto colisionado
        Destroy(prizeObject);
    }

    void HandleObstacleCollision(GameObject obstacleObject)
    {
        // Código para gestionar la colisión con un obstáculo
        // Por ejemplo, restar puntos al jugador
        GameManager.Instance.RestarPuntos(puntosObstaculo);

        // Destruir el objeto colisionado
        Destroy(obstacleObject);
    }
}
