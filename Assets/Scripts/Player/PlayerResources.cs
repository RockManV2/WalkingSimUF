using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public static PlayerResourceEvent OnPlayerWaterChanged;
    public static PlayerResourceEvent OnPlayerFoodChanged;
    public static PlayerResourceEvent OnPlayerStaminaChanged;
    public static PlayerResourceEvent OnPlayerStaminaZero;

    public delegate void PlayerResourceEvent(int resource);

    private int _food = 5;
    private int _water = 5;

    private int _stamina = 100;
    public readonly Dictionary<string, int> StaminaTick = new();

    private void Start()
    {
        OnPlayerWaterChanged.Invoke(_water);
        OnPlayerFoodChanged.Invoke(_food);
        OnPlayerStaminaChanged.Invoke(_stamina);
        
        StartCoroutine(OnStaminaTick());
    }

    public void AddWater(int amount)
    {
        _water += amount;
        _water = Mathf.Clamp(_water, 0, 10);
        OnPlayerWaterChanged?.Invoke(_water);
    }

    public void AddFood(int amount)
    {
        _food += amount;
        _food = Mathf.Clamp(_food, 0, 10);
        OnPlayerFoodChanged?.Invoke(_food);
    }

    public bool RemoveStamina(int amount)
    {
        if (_stamina < amount) return false;
        _stamina -= amount;
        OnPlayerStaminaChanged?.Invoke(_stamina);
        return true;
    }

    private IEnumerator OnStaminaTick()
    {
        if (StaminaTick.Count == 0)
            _stamina = Math.Clamp(_stamina + ((_food + _water) / 2), 0, 100);
            
        foreach (KeyValuePair<string, int> pair in StaminaTick)
        {
            if (_stamina < pair.Value)
            {
                _stamina = 0;
                OnPlayerStaminaZero?.Invoke(_stamina);
                break;
            }
            _stamina -= pair.Value;
        }
        
        OnPlayerStaminaChanged?.Invoke(_stamina);

        yield return new WaitForSeconds(1);
        StartCoroutine(OnStaminaTick());
    }
}