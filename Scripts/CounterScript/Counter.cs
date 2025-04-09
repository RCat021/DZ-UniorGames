using System.Collections;
using UnityEngine;
using System;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : MonoBehaviour
{

    [SerializeField] private int _step = 1;
    [SerializeField] private float _timerStep = 0.5f;

    public int CurrentCount { get; private set; } = 0;

    private bool _isCounterActive = true;
    private Coroutine _coroutine;

    public event Action OnCountChanged;

    public void IncreaseCount(int count)
    {
        CurrentCount += count;
        OnCountChanged?.Invoke();
    }

    public void ActiveCounter()
    {
        _coroutine = StartCoroutine(UpdateCounterRoutine());
    }
    public void DisactiveCounter()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator UpdateCounterRoutine()
    {
        var waitDuration = new WaitForSeconds(_timerStep);

        while (_isCounterActive)
        {
            IncreaseCount(_step);
            yield return waitDuration;
        }
    }
}
