using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Text text;

    //can be called to set the player's max health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //can be called to set the value of the slider for the player's health
    public void SetHealth(int health)
    {
        slider.value = health;
        text.text = health + "/100";
    }
}
