using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicReaction : MonoBehaviour
{
    public Slider slider;
    public Inventory playerInventory;
    public Signal magicSignal;

    public void Use(int amountToIncrease)
    {
        if (slider.value < slider.maxValue && playerInventory.currentMagic < playerInventory.maxMagic)
        {
            playerInventory.currentMagic += amountToIncrease;
            magicSignal.Raise();
        }
        else
        {
            playerInventory.currentMagic = playerInventory.maxMagic;
        }
    }
}
