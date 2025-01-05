
using TMPro;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Runestone : MonoBehaviour, IInteractable
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private string text1;
    [SerializeField] private string text2;
    [SerializeField] private GameObject _powerup;
    private KeywordRecognizer _recognizer;

    private void Start()
    {
        _recognizer = new KeywordRecognizer(new[] { "Double Jump"});
        _recognizer.OnPhraseRecognized += OnPhraseRecognized;
    }

    public void Interact(GameObject player)
    {
        int count = GameManager.Instance.RunestoneCount;
        
        if(count < 3)
            textMesh.text = text1;
        else
        {
            textMesh.text = text2;
            _recognizer.Start();
        }
        
        SoundManager.PlaySound("pling");
    }


    private void OnPhraseRecognized(PhraseRecognizedEventArgs args) =>
        Instantiate(_powerup, transform.position + transform.forward * 3, transform.rotation);
}
