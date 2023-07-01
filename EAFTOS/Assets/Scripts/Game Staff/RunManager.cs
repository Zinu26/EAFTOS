using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunManager : MonoBehaviour
{
    public Slider runMeter;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        InitRun();
    }

    private void Update()
    {
    }

    public void InitRun()
    {
        runMeter.maxValue = playerInventory.maxRun;
        runMeter.value = playerInventory.maxRun;
        playerInventory.currentRun = playerInventory.maxRun;
    }

    public void AddRun()
    {
        runMeter.value = playerInventory.currentRun;
        if (runMeter.value < 100) 
        {
            while(runMeter.value != runMeter.maxValue)
            {
                runMeter.value = runMeter.value + 10;
                playerInventory.currentRun = playerInventory.currentRun + 10;
            }
        }
    }

    public void DecreaseRun()
    {
        runMeter.value = playerInventory.currentRun;
        if(runMeter.value < 0)
        {
            runMeter.value = 0;
            playerInventory.currentRun = 0;
        }
    }
}
