using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthReaction : MonoBehaviour
{ 
    public Slider slider;
    public FloatValue playerHealth;
    public FloatValue heartContainer;
    public Signal healthSignal;

    public void Use(int amountToIncrease)
    {
        if (playerHealth.RuntimeValue < heartContainer.RuntimeValue * 2)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            healthSignal.Raise();
        }
        else
        {
            playerHealth.RuntimeValue = heartContainer.RuntimeValue * 2;
        }
    }
}
