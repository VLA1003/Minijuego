using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int puntuacionObjetivo = 50;
    public float tiempoInicial = 60f;

    public int actualPuntuacion;
    public float tiempoActual;
    public int nivelActual = 1;

    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoNivel;

    private bool isGameRunning = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        actualPuntuacion = 0;
        tiempoActual = tiempoInicial;
        ActualizarInterfaz();
    }

    void Update()
    {
        if (isGameRunning)
        {
            if (tiempoActual > 0f)
            {
                tiempoActual -= Time.deltaTime;
                ActualizarInterfaz();
            }
            else
            {
                AcabarPartida(false);
            }
        }
    }

    public void SumarPuntos(int puntos)
    {
        if (isGameRunning)
        {
            actualPuntuacion += puntos;

            if (actualPuntuacion >= puntuacionObjetivo)
            {
                SiguienteNivel();
            }
        }
    }

    public void RestarPuntos(int puntos)
    {
        if (isGameRunning)
        {
            actualPuntuacion -= puntos;

            if (actualPuntuacion >= puntuacionObjetivo)
            {
                SiguienteNivel();
            }
        }
    }

    void SiguienteNivel()
    {
        nivelActual++;
        actualPuntuacion = 0;
        tiempoActual = tiempoInicial;
        ActualizarInterfaz();
    }

    void ActualizarInterfaz()
    {
        textoPuntos.text = "" + actualPuntuacion;
        textoTiempo.text = "" + Mathf.Round(tiempoActual);
        textoNivel.text = "" + nivelActual;
    }

    void AcabarPartida(bool esVictoria)
    {
        isGameRunning = false;
        if (esVictoria)
        {
            Debug.Log("¡Has superado el nivel!");
        }
        else
        {
            Debug.Log("¡Has perdido!");
        }
    }
}
