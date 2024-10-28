using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    public  int CycleDays
    {
        get { return cycleDays; }
    }
    
    [SerializeField] private int currentDay = 1;
    private const  int cycleDays = 5;
    [SerializeField] private DayTimer dayTimer;
    public RentManager rentManager;
    private void Start()
    {
        StartDay();
    }

    public void StartDay()
    {
        Debug.Log("Starting Day " + currentDay);
        dayTimer.StartTimer();
    }

    public void EndDay()
    {
        Debug.Log("Ending Day " + currentDay);
        dayTimer.ResetTimer();
        currentDay++;
        
        if (currentDay % cycleDays == 0)
        {
           CheckRentDue();
        }
    }

    private void CheckRentDue()
    {
        if (rentManager.IsRentDue())
        {
            rentManager.PayRent();
        }
        else
        {
            rentManager.HandleNonPayment();
            currentDay -= cycleDays; // Ajusta o progresso se o aluguel não for pago
        }
    }
}
