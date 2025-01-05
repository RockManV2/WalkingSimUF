using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class StaminaMeter : MonoBehaviour
{
    [SerializeField] private Image _fill;

    private void Awake()
    {
        _fill = GetComponent<Image>();
        PlayerResources.OnPlayerStaminaChanged += SetFill;
    }

    private void SetFill(int resource) =>
        _fill.fillAmount = (float)resource / 100;
        
}