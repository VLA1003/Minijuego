using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotónJugar : MonoBehaviour
{
    public string escenaACargar;

    public void CargarEscenaClick()
    {
        SceneManager.LoadScene(escenaACargar);
    }
}
