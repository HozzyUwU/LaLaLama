using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    public void SetMaxValue(float _maxValue)
    {
        _slider.maxValue = _maxValue;
        _slider.value = _maxValue;
        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetValue(float _value)
    {
        _slider.value = _value;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
