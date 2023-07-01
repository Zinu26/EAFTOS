using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public Slider staminaSlider;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        staminaSlider.value = playerInventory.currentStamina;
    }


    public void AddStamina()
    {
        //magicSlider.value += 1;
        //playerInventory.currentMagic += 1;

        staminaSlider.value = playerInventory.currentStamina;
        if (staminaSlider.value > staminaSlider.maxValue)
        {
            staminaSlider.value = staminaSlider.maxValue;
            playerInventory.currentStamina = playerInventory.maxStamina;
        }
    }

    public void DecreaseStamina()
    {
        //magicSlider.value -= 1;
        //playerInventory.currentMagic -= 1;
        staminaSlider.value = playerInventory.currentStamina;
        if (staminaSlider.value < 0)
        {
            staminaSlider.value = 0;
            playerInventory.currentStamina = 0;
        }
    }
}
