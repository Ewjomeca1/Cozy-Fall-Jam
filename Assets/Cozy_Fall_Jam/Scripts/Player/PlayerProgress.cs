using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress Instance;
    [SerializeField] private int totalDays;
    [SerializeField] private int missedDays;
    [SerializeField] private float money;
    [SerializeField] private DayCycleManager _dayCycleManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool CanAfford(float amount)
    {
        return money >= amount;
    }

    public void DeductMoney(float amount)
    {
        if (CanAfford(amount))
        {
            money -= amount;
            Debug.Log("Money deducted: " + amount);
        }
    }

    public void UpdateProgress()
    {
        totalDays++;
    }

    public void RestoreProgress()
    {
        missedDays += _dayCycleManager.CycleDays; // ou apenas 1 dia, dependendo do design final
        totalDays -= missedDays;
    }
}
