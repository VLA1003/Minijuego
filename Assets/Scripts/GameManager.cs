using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private bool isGameRunning = true;

    public GameObject lanzadorObjetos;
    public MovimientoJugador movimientoJugadorScript;
    
    public string escenaSiguiente;

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
        movimientoJugadorScript = GameObject.Find("Jugador").GetComponent<MovimientoJugador>();
        StartCoroutine(ActivarLanzador());
        actualPuntuacion = 0;
        tiempoActual = tiempoInicial;
        isGameRunning = true;
        ActualizarInterfaz();
    }

    IEnumerator ActivarLanzador()
    {
        yield return new WaitForSeconds(2f);
        lanzadorObjetos.SetActive(true);
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
        lanzadorObjetos.SetActive(false);
        movimientoJugadorScript.enabled = false;
        StartCoroutine(CargarEscenaSiguiente());
        Debug.Log("Has ganado GILIPOLLAS");
    }

    void FinPartida()
    {
        lanzadorObjetos.SetActive(false);
        movimientoJugadorScript.enabled = false;
        Debug.Log("Has perdido GILIPOLLAS");
    }

    IEnumerator CargarEscenaSiguiente()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(escenaSiguiente);
    }

    void ActualizarInterfaz()
    {
        textoPuntos.text = "" + actualPuntuacion;
        textoTiempo.text = "" + Mathf.Round(tiempoActual);
    }
}
