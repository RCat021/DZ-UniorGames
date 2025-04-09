using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterToogle : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private bool _isCounterActive = false;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounter();
        }
    }

    private void ToggleCounter()
    {
        _isCounterActive = !_isCounterActive;

        if (_isCounterActive)
            _counter.ActiveCounter();
        else
            _counter.DisactiveCounter();
    }
}
