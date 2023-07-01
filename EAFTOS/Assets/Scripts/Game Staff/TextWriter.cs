using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Slider runMeter;
    private float Value;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;

    public void AddWriter(Slider runMeter, Inventory playerInventory, float timePerCharacter)
    {
        this.runMeter = runMeter;
        this.Value = playerInventory.currentRun;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
    }

    private void Update()
    {
        if(runMeter != null)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;
                if(characterIndex >= Value)
                {
                    runMeter = null;
                    return;
                }
            }
        }
    }
}
