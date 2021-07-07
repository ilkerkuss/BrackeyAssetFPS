using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider StamSlider;

    public Gradient StamGradient;
    public Image StamFill;

    public void SetStamina(float stamina)
    {
        StamSlider.value = stamina;

        StamFill.color = StamGradient.Evaluate(1f);
    }

    public void SetMaxStamina(float stamina)
    {
        StamSlider.maxValue = stamina;
        StamSlider.value = stamina;

        StamFill.color = StamGradient.Evaluate(StamSlider.normalizedValue);

    }
 
}
