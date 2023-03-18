using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : IInput
{
    private static KeyboardInput instance;
    public Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public bool getEbuttonDown() => Input.GetKeyDown(KeyCode.E);

    public static KeyboardInput getInstance()
    {
        if (instance == null)
            instance = new KeyboardInput();
        return instance;
    }
}
