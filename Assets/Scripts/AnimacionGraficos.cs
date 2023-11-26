using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionGraficos : MonoBehaviour
{
    public float tiempoDeAparicion = 1f;

    private Image imagen;
    private float tiempoTranscurrido = 0f;
    private bool estaApareciendo = false;

    void Start()
    {
        imagen = GetComponent<Image>();
        Color color = imagen.color;
        color.a = 0f;
        imagen.color = color;
    }

    void Update()
    {
        if (!estaApareciendo)
        {
            tiempoTranscurrido += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, tiempoTranscurrido / tiempoDeAparicion);
            Color color = imagen.color;
            color.a = alpha;
            imagen.color = color;

            if (tiempoTranscurrido >= tiempoDeAparicion)
            {
                estaApareciendo = true;
            }
        }
    }
}
