
using TMPro;
using UnityEngine;

public class MiniRunestone : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _textCanvas;
    
    public void Interact(GameObject player)
    {
    Debug.Log("Bomba");
        if (_textCanvas.gameObject.activeInHierarchy) return;

        GameManager.Instance.RunestoneCount++;
        _textCanvas.gameObject.SetActive(true);
        SoundManager.PlaySound("pling");
    }
}
