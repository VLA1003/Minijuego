using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotónJugar : MonoBehaviour
{
    public string escenaACargar;

    public void CargarEscenaClick()
    {
        // Cargar la escena por nombre
        SceneManager.LoadScene(escenaACargar);
    }
}
