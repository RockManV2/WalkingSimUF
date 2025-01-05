
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator slideAnimator;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void StartScene(string scene) =>
        StartCoroutine(LoadGame(scene));

    private IEnumerator LoadGame(string scene)
    {
        slideAnimator.SetTrigger("SlideIn");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
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
