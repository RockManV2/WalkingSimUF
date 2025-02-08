
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class Runestone : MonoBehaviour, IInteractable
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private string[] text1;
    [SerializeField] private string[] text2;
    [SerializeField] private GameObject _powerup;
    private KeywordRecognizer _recognizer;

    private void Start()
    {
        _recognizer = new KeywordRecognizer(new[] { "Super Jump"});
        _recognizer.OnPhraseRecognized += OnPhraseRecognized;
    }

    public void Interact(GameObject player)
    {
        int count = GameManager.Instance.RunestoneCount;
        
        if(count < 3)
            StartCoroutine(DisplayTextInSequence(text1));
        else
        {
            StartCoroutine(DisplayTextInSequence(text2));
            _recognizer.Start();
        }
        
        SoundManager.PlaySound("pling");
    }

    private IEnumerator DisplayTextInSequence(string[] text)
    {
        foreach (string txt in text)
        {
            textMesh.text = txt;
            SoundManager.PlaySound("pling");
            yield return new WaitForSeconds(4);
        }
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Instantiate(_powerup, transform.position + transform.forward * 3, transform.rotation);
    }
}
