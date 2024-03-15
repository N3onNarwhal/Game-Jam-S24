using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Slider _slider = null;
    [SerializeField] Gradient _gradient = null;

    [SerializeField] Image _fill = null;


    public void SetMaxStamina(int stamina)
    {
        _slider.maxValue = stamina;
        _slider.value = stamina;

        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetStamina(int stamina)
    {
        _slider.value = stamina;

        _fill.color = _gradient.Evaluate(_slider.normalizedValue);       
    }
}
