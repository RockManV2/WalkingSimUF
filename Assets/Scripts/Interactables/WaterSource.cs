
using UnityEngine;

public class WaterSource : MonoBehaviour, IInteractable
{
    public void Interact(GameObject player) =>
        player.GetComponent<PlayerResources>().AddWater(2);
}
