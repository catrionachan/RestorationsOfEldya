using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Health bar class
public class HealthBar : MonoBehaviour
{
    //public variables for the slider
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //method sets maximum health at the beginning of the character spawn
    public void SetMaxHealth(float health) 
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);

    }

    //update health method for when the health decreases
    public void SetHealth(float health) 
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
      

}
