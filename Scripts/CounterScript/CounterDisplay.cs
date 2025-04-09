using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _counter.OnCountChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        _counter.OnCountChanged -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        _text.text = _counter.CurrentCount.ToString();
    }
}
