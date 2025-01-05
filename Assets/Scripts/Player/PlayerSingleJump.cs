
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSingleJump : PlayerJump
{
    public override void Jump()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, _groundLayer);
        if (hit.transform == null) return;
        
        if (!_playerResources.RemoveStamina(20)) return;
        
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
    }
}
