
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDoubleJump : PlayerJump
{
    private int _jumps = 2;
    
    public override void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f, _groundLayer))
            _jumps = 2;
        else
            if (_jumps <= 0)
                return;
        
        if (!_playerResources.RemoveStamina(20)) return;
        _jumps--;
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
    }
}
