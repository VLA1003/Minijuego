using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionRebote : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Rebote!");
    }

}
