
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private Animator slideAnimator;
    public int RunestoneCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        slideAnimator.SetTrigger("SlideOut");
        SoundManager.PlayMusic("ambience");
    }
}
