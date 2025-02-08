
using UnityEngine;

public class Lake : MonoBehaviour, ICollideable
{
    [SerializeField] private Transform _respawnPoint;
    
    public void Collide(GameObject player)
    {
        player.transform.position = _respawnPoint.position;
    }
}
