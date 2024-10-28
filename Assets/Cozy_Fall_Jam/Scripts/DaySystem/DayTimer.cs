using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimer : MonoBehaviour
{
    [SerializeField] private float timeLimit = 300f; // Tempo do dia em segundos
    [SerializeField] private float currentTime;
    [SerializeField] private DayCycleManager _dayCycleManager;

    public void StartTimer()
    {
        currentTime = timeLimit;
        StartCoroutine(UpdateTimer());
    }

    private System.Collections.IEnumerator UpdateTimer()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            yield return null;
        }
        
        _dayCycleManager.EndDay();
    }

    public void ResetTimer()
    {
        StopAllCoroutines();
        currentTime = timeLimit;
    }
}
