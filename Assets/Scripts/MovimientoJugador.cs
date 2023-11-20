using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidadMovimiento = 5f;

    private bool bocaAbierta = false;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AbrirBoca();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CerrarBoca();
        }
    }

    void AbrirBoca()
    {
        bocaAbierta = true;
    }

    void CerrarBoca()
    {
        bocaAbierta = false;
        Debug.Log("Boca cerrada");
    }
}
