
using UnityEngine;

public class CollisionInteractor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) =>
        other.transform.GetComponent<ICollideable>()?.Collide(gameObject);
}
