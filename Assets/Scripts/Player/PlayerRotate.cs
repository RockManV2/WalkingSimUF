
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;               
    [SerializeField] private PlayerInput _playerInput;            
    [SerializeField] private float _mouseSensitivity = 100f;
    private float _xRotation;
    
    private void Start() =>
        Cursor.lockState = CursorLockMode.Locked;

    private void OnEnable() =>
        _playerInput.actions["Look"].performed += Look;
    
    private void OnDisable() =>
        _playerInput.actions["Look"].performed -= Look;
    
    private void Look(InputAction.CallbackContext context)
    {
        float mouseX = context.ReadValue<Vector2>().x * _mouseSensitivity * Time.deltaTime;
        float mouseY = context.ReadValue<Vector2>().y * _mouseSensitivity * Time.deltaTime;
        
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}