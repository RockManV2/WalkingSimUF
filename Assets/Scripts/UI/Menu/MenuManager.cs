
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator slideAnimator;

    public void StartGame() =>
        StartCoroutine(LoadGame());

    private IEnumerator LoadGame()
    {
        slideAnimator.SetTrigger("SlideIn");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }
    
    public void ExitGame()
    {
        #if !UNITY_EDITOR
        Application.Quit();
        #else
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
