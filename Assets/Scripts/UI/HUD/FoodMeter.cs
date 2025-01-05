using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FoodMeter : MonoBehaviour
{
    [SerializeField] private Image _fill;

    private void Awake()
    {
        _fill = GetComponent<Image>();
        PlayerResources.OnPlayerFoodChanged += SetFill;
    }
    
    private void SetFill(int resource) =>
        _fill.fillAmount = (float)resource / 10;
}