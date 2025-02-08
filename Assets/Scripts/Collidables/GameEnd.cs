
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour, ICollideable
{
    public void Collide(GameObject player) =>
        SceneManager.LoadScene("EndScreen");
}
