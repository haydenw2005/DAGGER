using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider;
    public Gradient gradient;
    public Image HealthFill;

    public void SetMaxHealth(int health) {
        HealthSlider.maxValue = health;
        HealthSlider.value = health;
        HealthFill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health) {
        HealthSlider.value = health;
        HealthFill.color = gradient.Evaluate(HealthSlider.normalizedValue);
    }

    
}
