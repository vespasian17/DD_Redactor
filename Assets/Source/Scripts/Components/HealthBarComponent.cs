using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarComponent : MonoBehaviour
{
    public Slider HealthBarSlider;

    public void SetHealthBarMaxValue(int maxHealth)
    {
        HealthBarSlider.maxValue = maxHealth;
    }

    public void SetHealthBarValue(int health)
    {
        HealthBarSlider.value = health;
    }
}
