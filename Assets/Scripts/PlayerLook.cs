using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 50f;   
    public Transform cam;

    private float xRotation = 0f;
    private Vector2 lookInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Locked cursor to middle of the screen 
        Cursor.visible = false; //Hide cursor
    }

    
    void Update()
    {
        HandleMouseLook();
    }

    public void OnLook(InputValue value)
    { 
    lookInput = value.Get<Vector2>();  
    }

    void HandleMouseLook()
    { 
    float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
    float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90); //Cant look more than 90 degrees up or down
        
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
}
