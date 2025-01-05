
using UnityEngine;

public class FruitTree : MonoBehaviour, IInteractable
{
    public void Interact(GameObject player)
    {
        PlayerResources playerResources = player.GetComponent<PlayerResources>();
        playerResources.AddFood(2);
        playerResources.AddWater(1);
        SoundManager.PlaySound("bite");
    }
}