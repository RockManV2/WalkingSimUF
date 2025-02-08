
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private void Update()
    {
        Vector3 targetPosition = transform.parent.position;

        // Rotate around the parent's position with the offset
        transform.RotateAround(targetPosition, Vector3.forward, _rotationSpeed * Time.deltaTime);
    }
}
