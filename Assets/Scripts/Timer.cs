using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _countDownTime;
    private float _currentTime;

    private void Start()
    {
        _currentTime = _countDownTime + Time.time;
        Debug.Log("Current time : " + _currentTime);
    }

    void Update()
    {
        float timeLeft = _currentTime - Time.time;
        int secondsLeft = Mathf.FloorToInt(timeLeft % 60);

        Debug.Log("Current time : " + timeLeft);
        if (timeLeft <= 0)
        {
            // Todo : Implement a function when timeleft = 0 
        }
    }
}
