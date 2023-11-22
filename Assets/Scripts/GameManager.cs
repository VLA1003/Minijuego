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
        QualitySettings.vSyncCount = 1;
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
        isGameRunning = true;
        ActualizarInterfaz();
    }

    void Update()
    {
        if (tiempoActual > 0f)
        {
            tiempoActual -= Time.deltaTime;
            ActualizarInterfaz();
        }
        else
        {
            if (actualPuntuacion >= puntuacionObjetivo)
            {
                SiguienteNivel();
            }
            else
            {
                FinPartida();
            }
        }
    }

    public void SumarPuntos(int puntos)
    {
        if (isGameRunning)
        {
            actualPuntuacion += puntos;
        }
    }

    public void RestarPuntos(int puntos)
    {
        if (isGameRunning)
        {
            actualPuntuacion -= puntos;
        }
    }

    void SiguienteNivel()
    {
        Debug.Log("Has ganado GILIPOLLAS");
        nivelActual++;
        actualPuntuacion = 0;
        tiempoActual = tiempoInicial;
        ActualizarInterfaz();
    }

    void FinPartida()
    {
        Debug.Log("Has perdido GILIPOLLAS");
    }

    void ActualizarInterfaz()
    {
        textoPuntos.text = "" + actualPuntuacion;
        textoTiempo.text = "" + Mathf.Round(tiempoActual);
        textoNivel.text = "" + nivelActual;
    }
}
