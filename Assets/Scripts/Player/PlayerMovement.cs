
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerResources))]
[RequireComponent(typeof(PlayerSingleJump))]
[RequireComponent(typeof(PlayerDoubleJump))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
    private float _playerSpeed;
    private PlayerInput _playerInput;
    private Vector2 _movementDirection;
    private PlayerResources _playerResources;
    
    private PlayerJump _playerJump;
    private PlayerSingleJump _playerSingleJump;
    private PlayerDoubleJump _playerDoubleJump;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerResources = GetComponent<PlayerResources>();
        _playerSingleJump = GetComponent<PlayerSingleJump>();
        _playerDoubleJump = GetComponent<PlayerDoubleJump>();
        _playerJump = _playerSingleJump;
        _playerSpeed = _walkSpeed;
        _playerJump = _playerSingleJump;
    }
    
    private void OnEnable()
    {
        _playerInput.actions["Move"].performed += Move;
        _playerInput.actions["Move"].canceled += Move;
        _playerInput.actions["Sprint"].performed += StartSprint;
        _playerInput.actions["Sprint"].canceled += CancelSprint;
        _playerInput.actions["Jump"].performed += Jump;
        PlayerResources.OnPlayerStaminaZero += CancelSprint;
    }

    private void OnDisable()
    {
        _playerInput.actions["Move"].performed -= Move;
        _playerInput.actions["Move"].canceled -= Move;
        _playerInput.actions["Sprint"].performed -= StartSprint;
        _playerInput.actions["Sprint"].canceled -= CancelSprint;
        _playerInput.actions["Jump"].performed -= Jump;
        PlayerResources.OnPlayerStaminaZero -= CancelSprint;
    }

    private void Update()
    {
        Vector3 forwardForce = transform.forward * _movementDirection.y;
        Vector3 rightForce = transform.right * _movementDirection.x;
        
        Vector3 totalMoveForce = (forwardForce + rightForce).normalized * (_playerSpeed * Time.deltaTime);
        
        transform.position += totalMoveForce;
        _animator.SetFloat("SpeedX", _movementDirection.x);
        _animator.SetFloat("SpeedY", _movementDirection.y);
    }

    public void BindNewJump(PlayerJumpType type)
    {
        _playerJump = type switch
        {
            PlayerJumpType.Single => _playerSingleJump,
            PlayerJumpType.Double => _playerDoubleJump,
            _ => _playerJump
        };
    }

    private void Move(InputAction.CallbackContext context) =>
        _movementDirection = (context.ReadValue<Vector2>());

    private void StartSprint(InputAction.CallbackContext _)
    {
        _playerSpeed = _sprintSpeed;
        _playerResources.StaminaTick.Add("Sprint", 5);
    }

    private void CancelSprint(InputAction.CallbackContext _)
    {
        _playerSpeed = _walkSpeed;
        _playerResources.StaminaTick.Remove("Sprint");
    }
    
    private void CancelSprint(int stamina)
    {
        _playerSpeed = _walkSpeed;
        _playerResources.StaminaTick.Remove("Sprint");
    }

    private void Jump(InputAction.CallbackContext _) =>
        _playerJump.Jump();
}
