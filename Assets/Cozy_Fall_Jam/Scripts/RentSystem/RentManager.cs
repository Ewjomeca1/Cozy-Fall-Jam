using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentManager : MonoBehaviour
{
    [SerializeField] private float rentCost = 100f;
    private bool rentDue = true;

    public bool IsRentDue()
    {
        return rentDue;
    }

    public void PayRent()
    {
        if (PlayerProgress.Instance.CanAfford(rentCost))
        {
            PlayerProgress.Instance.DeductMoney(rentCost);
            rentDue = false;
            Debug.Log("Rent paid successfully.");
        }
        else
        {
            rentDue = true;
            Debug.Log("Not enough money for rent.");
        }
    }

    public void HandleNonPayment()
    {
        Debug.Log("Rent not paid. Progress reset.");
        PlayerProgress.Instance.RestoreProgress();
    }

    private void Start()
    {
        rentDue = true;
    }
}
