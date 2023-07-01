using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperManager : MonoBehaviour
{
    public Slider superSlider;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        superSlider.value = playerInventory.currentSuper;
    }

    public void AddSuper()
    {
        //magicSlider.value += 1;
        //playerInventory.currentMagic += 1;

        superSlider.value = playerInventory.currentSuper;
        if (superSlider.value > superSlider.maxValue)
        {
            superSlider.value = superSlider.maxValue;
            playerInventory.currentSuper = playerInventory.maxSuper;
        }
    }

    public void DecreaseSuper()
    {
        //magicSlider.value -= 1;
        //playerInventory.currentMagic -= 1;
        superSlider.value = playerInventory.currentSuper;
        if (superSlider.value < 0)
        {
            superSlider.value = 0;
            playerInventory.currentSuper = 0;
        }
    }
}
