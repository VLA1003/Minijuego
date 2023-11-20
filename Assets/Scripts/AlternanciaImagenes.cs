using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlternanciaUIImages : MonoBehaviour
{
    public float velocidadCambio = 0.2f;
    public Sprite sprite1;
    public Sprite sprite2;

    private Image image;
    private bool alternar = false;

    void Start()
    {
        image = GetComponent<Image>();

        if (sprite1 != null)
        {
            image.sprite = sprite1;
        }

        InvokeRepeating("AlternarImagen", 0.5f, velocidadCambio);
    }

    void AlternarImagen()
    {
        if (alternar)
        {
            image.sprite = sprite1;
        }
        else
        {
            image.sprite = sprite2;
        }
        alternar = !alternar;
    }
}
