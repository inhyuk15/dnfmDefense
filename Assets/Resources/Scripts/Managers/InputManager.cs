using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public VirtualJoystick joystick;
    public PlayerUnit unit;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (joystick.Direction != Vector3.zero)
        {
            // Debug.Log($"changed joystick direction ${joystick.Direction}");
            unit.Movement(joystick.Direction);
        }
        else
        {
            // Debug.Log("not changed joystick direction");
        }
    }
}
