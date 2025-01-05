
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WaterMeter : MonoBehaviour
{
    [SerializeField] private Image _fill;

    private void Awake()
    {
        _fill = GetComponent<Image>();
        PlayerResources.OnPlayerWaterChanged += SetFill;
    }

    private void SetFill(int resource) =>
        _fill.fillAmount = (float)resource / 10;
        
}
