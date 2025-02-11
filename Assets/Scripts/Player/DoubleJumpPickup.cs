
using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour, IInteractEventReciever
{
    public void Interact(GameObject player)
    {
        player.GetComponent<PlayerMovement>().BindNewJump(PlayerJumpType.Double);
        Destroy(gameObject);
    }
}
