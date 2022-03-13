using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider HungerSlider;
    public Gradient gradient;
    public Image HungerFill;

    public void SetMaxHunger(int hunger) {
        HungerSlider.maxValue = hunger;
        HungerSlider.value = hunger;
        HungerFill.color = gradient.Evaluate(1f);
    }
    public void SetHunger(int hunger) {
        HungerSlider.value = hunger;
        HungerFill.color = gradient.Evaluate(HungerSlider.normalizedValue);
    }

    
}
