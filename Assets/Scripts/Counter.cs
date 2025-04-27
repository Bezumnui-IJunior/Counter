using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _sleepSeconds = 1;
    [SerializeField] private int _increaseValue = 1;

    private bool _isIncrease;

    [CanBeNull] public event UnityAction ValueChanged;

    public int Value { get; private set; }

    public void Toggle()
    {
        if (_isIncrease)
            StopCount();
        else
            StartCount();
    }

    private void StartCount()
    {
        if (_isIncrease)
            return;

        _isIncrease = true;
        StartCoroutine(IncreaseValue());
    }

    private void StopCount()
    {
        _isIncrease = false;
    }

    private IEnumerator IncreaseValue()
    {
        WaitForSeconds wait = new(_sleepSeconds);

        while (_isIncrease)
        {
            Value += _increaseValue;
            ValueChanged?.Invoke();

            yield return wait;
        }
    }
}