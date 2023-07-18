using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    private float xDir = 0f;
    private float zDir = 0f;

    public Vector3 Direction;

    void Update()
    {
        Direction = Vector3.zero;

        HandleKeyPress(KeyCode.A, new Vector3(-1, 0, 0));
        HandleKeyPress(KeyCode.D, new Vector3(1, 0, 0));
        HandleKeyPress(KeyCode.W, new Vector3(0, 0, 1));
        HandleKeyPress(KeyCode.S, new Vector3(0, 0, -1));

        HandleKeyPress(KeyCode.LeftArrow, new Vector3(-1, 0, 0));
        HandleKeyPress(KeyCode.RightArrow, new Vector3(1, 0, 0));
        HandleKeyPress(KeyCode.UpArrow, new Vector3(0, 0, 1));
        HandleKeyPress(KeyCode.DownArrow, new Vector3(0, 0, -1));
    }

    private void HandleKeyPress(KeyCode key, Vector3 direction)
    {
        if (Input.GetKey(key))
        {
            Direction += direction;
        }
    }
}
