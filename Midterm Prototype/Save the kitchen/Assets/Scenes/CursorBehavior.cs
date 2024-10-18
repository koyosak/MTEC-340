using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    void OnMouseDown()
    {
        // Destroy the sprite when clicked
        Destroy(gameObject);
    }
}
