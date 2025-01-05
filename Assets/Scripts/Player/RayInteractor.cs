
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class RayInteractor : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private Transform _playerCameraTransform;
    [SerializeField] private LayerMask _playerLayer;
    private void Awake() =>
        _playerInput = GetComponent<PlayerInput>();
    
    private void OnEnable() =>
        _playerInput.actions["Interact"].performed += Interact;

    private void OnDisable() =>
        _playerInput.actions["Interact"].performed -= Interact;
    

    private void Interact(InputAction.CallbackContext _)
    {
        Physics.Raycast(_playerCameraTransform.position, _playerCameraTransform.forward, out RaycastHit hit, 10, ~_playerLayer);
        if (hit.transform == null) return;
        
        hit.transform.GetComponent<IInteractable>()?.Interact(gameObject);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(_playerCameraTransform.position, _playerCameraTransform.forward * 10, Color.red);

    }
}
