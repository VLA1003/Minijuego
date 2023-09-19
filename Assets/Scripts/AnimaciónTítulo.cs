using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimaciónTítulo : MonoBehaviour
{
    public GameObject logotipo;
    TextMeshProUGUI textoLogo;

    void Start()
    {
        textoLogo = GetComponent<TextMeshProUGUI>();
        var color = textoLogo.color;
        var colorDesvanecer = color;

        LeanTween.moveLocalY(logotipo, 500, 0);
        LeanTween.moveLocalY(logotipo, 25, 1).setOnComplete(Funcion1);
    }
    void Funcion1()
    {
        LeanTween.print("funcion1empezada");
    }
}
