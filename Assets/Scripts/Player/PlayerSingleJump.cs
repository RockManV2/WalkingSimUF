
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSingleJump : PlayerJump
{
    public override void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f, _groundLayer) == false) return;
        if (!_playerResources.RemoveStamina(20)) return;
        
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
    }
}
