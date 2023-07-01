using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FloatValue currentHealth;
    public FloatValue heartContain;
    public Inventory playerInventory;

    public float position1;
    public float position2;
    public float position3;

    public void SaveData()
    {
    }

    public void LoadData()
    {
        /*PlayerData data = SaveSystem.LoadPlayer();
        heartContain.RuntimeValue = data.heart.RuntimeValue;
        currentHealth.RuntimeValue = data.health.RuntimeValue;
        playerInventory.currentMagic = data.inventory.currentMagic;
        playerInventory.currentStamina = data.inventory.currentStamina;
        playerInventory.currentSuper = data.inventory.currentSuper;
        playerInventory.currentRun = data.inventory.currentRun;
        playerInventory.numberOfBlueKeys = data.inventory.numberOfBlueKeys;
        playerInventory.numberOfGoldKeys = data.inventory.numberOfGoldKeys;
        playerInventory.numberOfSilverKeys = data.inventory.numberOfSilverKeys;
        playerInventory.numberOfBrownKeys = data.inventory.numberOfBrownKeys;
        playerInventory.numberOfOrangeKeys = data.inventory.numberOfOrangeKeys;
        playerInventory.coins = data.inventory.coins;
        playerInventory.numberOfMask = data.inventory.numberOfMask;
        playerInventory.numberOfGem = data.inventory.numberOfGem;
        playerInventory.numberOfScroll = data.inventory.numberOfScroll;
        playerInventory.numberOfDiamond = data.inventory.numberOfDiamond;
        playerInventory.numberOfNecklace = data.inventory.numberOfNecklace;
        playerInventory.items = data.inventory.items;

        Vector3 position;
        position.x = data.position1;
        position.y = data.position2;
        position.z = data.position3;
        transform.position = position;*/
    }
}
