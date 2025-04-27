using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TextMeshProUGUI _textMesh;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _counter.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged()
    {
        _textMesh.text = _counter.Value.ToString();
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= OnValueChanged;
    }
}