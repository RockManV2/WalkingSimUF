
using UnityEngine;

public class WaterSource : MonoBehaviour, IInteractEventReciever
{
    public void Interact(GameObject player) =>
        player.GetComponent<PlayerResources>().AddWater(2);
}
