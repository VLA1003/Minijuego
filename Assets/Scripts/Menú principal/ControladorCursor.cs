using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCursor : MonoBehaviour
{
    public Texture2D texturaCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(texturaCursor, hotSpot, cursorMode);
    }
}
