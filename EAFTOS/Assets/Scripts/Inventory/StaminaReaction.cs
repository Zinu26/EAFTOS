using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaReaction : MonoBehaviour
{
    public Slider slider;
    public Inventory playerInventory;
    public Signal staminaSignal;

    public void Use(int amountToIncrease)
    {
        if (slider.value < slider.maxValue && playerInventory.currentStamina < playerInventory.maxStamina)
        {
            playerInventory.currentStamina += amountToIncrease;
            staminaSignal.Raise();
        }
        else
        {
            playerInventory.currentStamina = playerInventory.maxStamina;
        }
    }
}
