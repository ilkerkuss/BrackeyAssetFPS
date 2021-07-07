using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider;

    public Gradient HealthGradient;
    public Image fill;

    // set characters maxHealth at beginning
    public void SetMaxHealth(float health)
    {
        HealthSlider.maxValue = health;
        HealthSlider.value = health;

        // healthbardaki fill imagesine gradientte belirledi�imiz renk atamas�n� yapar
        //evaluate 0-1 aral���nda soldan sa�a do�ru gradientteki renkleri belirtir.
        fill.color = HealthGradient.Evaluate(1f);

    }
    //set health value according to damage etc...
    public void SetHealth(float health)
    {
        HealthSlider.value = health;

        // slider�n de�erine g�re ayarlama yapar
        fill.color = HealthGradient.Evaluate(HealthSlider.normalizedValue);
    }



}
