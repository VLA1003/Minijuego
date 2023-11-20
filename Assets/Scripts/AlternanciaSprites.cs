using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternanciaSprites : MonoBehaviour
{
    public float velocidadCambio = 0.2f;
    public Sprite sprite1;
    public Sprite sprite2;

    private SpriteRenderer spriteRenderer;
    private bool alternar = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (sprite1 != null)
        {
            spriteRenderer.sprite = sprite1;
        }

        InvokeRepeating("AlternarSprite", 0.5f, velocidadCambio);
    }

    void AlternarSprite()
    {
        if (alternar)
        {
            spriteRenderer.sprite = sprite1;
        }
        else
        {
            spriteRenderer.sprite = sprite2;
        }
        alternar = !alternar;
    }
}
