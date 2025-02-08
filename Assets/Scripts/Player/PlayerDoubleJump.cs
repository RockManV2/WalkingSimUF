
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDoubleJump : PlayerJump
{
    private int _jumps = 2;

    public override void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f, _groundLayer))
        {
            _jumps = 2;
        }
        else if (_jumps <= 0)
            return;

        if (!_playerResources.RemoveStamina(20)) return;
        _jumps--;
        _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        _rb.AddForce((transform.up + (transform.forward / 2)).normalized * _jumpForce, ForceMode.Impulse);
    }
}
