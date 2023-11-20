using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNubes : MonoBehaviour
{
    public float velocidadMovimiento = 2.0f; 
    public float amplitudMovimiento = 50.0f; 

    private RectTransform rectTransform;
    private Vector3 posicionInicial;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        posicionInicial = rectTransform.anchoredPosition;
    }

    private void Update()
    {
        float verticalOffset = Mathf.Sin(Time.time * velocidadMovimiento) * amplitudMovimiento;
        rectTransform.anchoredPosition = new Vector3(posicionInicial.x, posicionInicial.y + verticalOffset, posicionInicial.z);
    }
}

