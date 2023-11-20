using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotónOpciones : MonoBehaviour
{
    public GameObject menuFlotante;

    public void Start()
    {
        menuFlotante.SetActive(false);
    }

    public void ActivarMenu()
    {
        menuFlotante.SetActive(true);
    }

    public void DesactivarMenu()
    {
        menuFlotante.SetActive(false);
    }
}
