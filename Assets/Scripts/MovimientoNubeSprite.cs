using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNubeSprite : MonoBehaviour
{
    public float velocidadMovimiento = 2f;
    public float amplitudMovimiento = 2f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float desplazamientoVertical = Mathf.Sin(Time.time * velocidadMovimiento) * amplitudMovimiento;
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y + desplazamientoVertical, posicionInicial.z);
    }
}
