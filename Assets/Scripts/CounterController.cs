using UnityEngine;

[RequireComponent(typeof(Counter))]
public class CounterController : MonoBehaviour
{
    private Counter _counter;

    private void Awake()
    {
        _counter = GetComponent<Counter>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counter.Toggle();
        }
    }
}