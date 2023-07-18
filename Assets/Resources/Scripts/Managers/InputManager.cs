using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public VirtualJoystick joystick;
    public KeyboardController keyboard;

    public PlayerUnit unit;

    private float cameraRadian;

    [SerializeField]
    private Camera camera;

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

    void Start()
    {
        cameraRadian = camera.transform.eulerAngles.y;
    }

    void Update()
    {
        if (joystick.Direction != Vector3.zero)
        {
            Vector3 direction = IsometricVectorConverter.RotateVector3(
                joystick.Direction,
                cameraRadian
            );
            unit.Movement(direction);
        }
        if (keyboard.Direction != Vector3.zero)
        {
            Vector3 direction = IsometricVectorConverter.RotateVector3(
                keyboard.Direction,
                cameraRadian
            );
            unit.Movement(direction);
        }
    }
}
