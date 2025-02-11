
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour, ICollisionEventReciever
{
    public void Collide(GameObject player) =>
        SceneManager.LoadScene("EndScreen");
}
