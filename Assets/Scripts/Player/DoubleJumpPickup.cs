
using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour, IInteractable
{
    public void Interact(GameObject player)
    {
        player.GetComponent<PlayerMovement>().BindNewJump(PlayerJumpType.Double);
        Destroy(gameObject);
    }
}
