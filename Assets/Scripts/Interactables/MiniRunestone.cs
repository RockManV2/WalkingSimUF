
using TMPro;
using UnityEngine;

public class MiniRunestone : MonoBehaviour, IInteractEventReciever
{
    [SerializeField] private GameObject _textCanvas;
    
    public void Interact(GameObject player)
    {
        if (_textCanvas.gameObject.activeInHierarchy) return;

        GameManager.Instance.RunestoneCount++;
        _textCanvas.gameObject.SetActive(true);
        SoundManager.PlaySound("pling");
    }
}
