
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerResources))]
public abstract class PlayerJump : MonoBehaviour
{
    [SerializeField] protected LayerMask _groundLayer;
    [SerializeField] protected float _jumpForce;
    protected Rigidbody _rb;
    protected PlayerResources _playerResources;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerResources = GetComponent<PlayerResources>();
    }

    public abstract void Jump();
}