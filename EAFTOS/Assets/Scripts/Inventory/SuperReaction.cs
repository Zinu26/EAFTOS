using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperReaction : MonoBehaviour
{
    public Slider slider;
    public Inventory playerInventory;
    public Signal superSignal;

    public void Use(int amountToIncrease)
    {
        if (slider.value < slider.maxValue && playerInventory.currentSuper < playerInventory.maxSuper)
        {
            playerInventory.currentSuper += amountToIncrease;
            superSignal.Raise();
        }
        else
        {
            playerInventory.currentSuper = playerInventory.maxSuper;
        }
    }
}
