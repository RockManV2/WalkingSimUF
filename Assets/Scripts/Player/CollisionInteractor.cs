
using UnityEngine;

public class CollisionInteractor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) =>
        other.transform.GetComponent<ICollisionEventReciever>()?.Collide(gameObject);
}
