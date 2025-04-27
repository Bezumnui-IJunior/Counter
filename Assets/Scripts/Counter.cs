using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _sleepSeconds = 1;
    [SerializeField] private int _increaseValue = 1;

    private bool _isIncrease;
    private Coroutine _coroutine;
    private WaitForSeconds _delay;

    private void Awake()
    {
        _delay = new WaitForSeconds(_sleepSeconds);
    }

    public event Action ValueChanged;

    public int Value { get; private set; }

    public void Toggle()
    {
        if (_coroutine != null)
            StopCount();
        else
            StartCount();
    }

    private void StartCount()
    {
        _coroutine = StartCoroutine(IncreasingValue());
    }

    private void StopCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = null;
    }

    private IEnumerator IncreasingValue()
    {
        while (enabled)
        {
            Value += _increaseValue;
            ValueChanged?.Invoke();

            yield return _delay;
        }
    }
}