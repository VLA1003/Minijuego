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

    public AudioClip sonidoVictoria;
    public AudioClip sonidoDerrota;
    public AudioSource audioSource;
    public bool sonidoVictoriaReproducido = false;
    public bool sonidoDerrotaReproducido = false;

    public int actualPuntuacion;
    public float tiempoActual;
    public int nivelActual = 1;

    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoObjetivo;
    public TextMeshProUGUI textoTiempo;
    public GameObject pantallaVictoria;
    public GameObject pantallaDerrota;
    public GameObject controladorMusica;

    private bool isGameRunning = true;
    private bool isTimeCountingStarted = false;

    public GameObject lanzadorObjetos;
    public MovimientoJugador movimientoJugadorScript;
    
    public string escenaSiguiente;
    public string escenaMenu;

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
        pantallaVictoria.SetActive(false);
        pantallaDerrota.SetActive(false);
        controladorMusica.SetActive(true);

        audioSource = GetComponent<AudioSource>();

        movimientoJugadorScript = GameObject.Find("Jugador").GetComponent<MovimientoJugador>();

        StartCoroutine(ActivarLanzador());

        actualPuntuacion = 0;
        tiempoActual = tiempoInicial;
        isGameRunning = true;
        StartCoroutine(IniciarConteoDeTiempo());

        string nombreEscena = SceneManager.GetActiveScene().name;

        if (nombreEscena == "Nivel 1")
        {
            puntuacionObjetivo = 80;
        }
        else if (nombreEscena == "Nivel 2")
        {
            puntuacionObjetivo = 120;
        }

        ActualizarInterfaz();

    }

    IEnumerator IniciarConteoDeTiempo()
    {
        yield return new WaitForSeconds(2f);
        isTimeCountingStarted = true;
    }

    IEnumerator ActivarLanzador()
    {
        yield return new WaitForSeconds(2f);
        lanzadorObjetos.SetActive(true);
    }

    void Update()
    {
        if (isTimeCountingStarted)
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
        if (!sonidoVictoriaReproducido)
        {
            lanzadorObjetos.SetActive(false);
            movimientoJugadorScript.enabled = false;
            pantallaVictoria.SetActive(true);
            controladorMusica.SetActive(false);
            audioSource.PlayOneShot(sonidoVictoria);
            StartCoroutine(CargarEscenaSiguiente());

            sonidoVictoriaReproducido = true;
        }
    }

    void FinPartida()
    {
        if (!sonidoDerrotaReproducido)
        {
            lanzadorObjetos.SetActive(false);
            movimientoJugadorScript.enabled = false;
            pantallaDerrota.SetActive(true);
            controladorMusica.SetActive(false);
            audioSource.PlayOneShot(sonidoDerrota);
            StartCoroutine(CargarEscenaMenu());

            sonidoDerrotaReproducido = true;
        }
    }

    IEnumerator CargarEscenaSiguiente()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(escenaSiguiente);
    }

    IEnumerator CargarEscenaMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(escenaMenu);
    }

    void ActualizarInterfaz()
    {
        textoPuntos.text = "" + actualPuntuacion;
        textoObjetivo.text = "" + puntuacionObjetivo;
        textoTiempo.text = "" + Mathf.Round(tiempoActual);
    }
}
