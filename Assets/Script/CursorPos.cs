using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPos : MonoBehaviour
{
    private void Update()
    {
        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos; 
    }
}
