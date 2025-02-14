using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockMouseOnMenu : MonoBehaviour
{
    private void Start()
    {
        UnlockMouse();
    }

    private void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
