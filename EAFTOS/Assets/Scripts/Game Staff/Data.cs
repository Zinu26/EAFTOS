using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data : MonoBehaviour
{
    public FloatValue health;
    public FloatValue heart;
    public Inventory inventory;
    public float position1;
    public float position2;
    public float position3;

    public Data(PlayerMovement player)
    {
        heart.RuntimeValue = player.heartContain.RuntimeValue;
        health.RuntimeValue = player.currentHealth.RuntimeValue;
        inventory.currentMagic = player.playerInventory.currentMagic;
        inventory.currentStamina = player.playerInventory.currentStamina;
        inventory.currentSuper = player.playerInventory.currentSuper;
        inventory.currentRun = player.playerInventory.currentRun;
        inventory.numberOfGoldKeys = player.playerInventory.numberOfGoldKeys;
        inventory.numberOfSilverKeys = player.playerInventory.numberOfSilverKeys;
        inventory.numberOfBlueKeys = player.playerInventory.numberOfBlueKeys;
        inventory.numberOfBrownKeys = player.playerInventory.numberOfBrownKeys;
        inventory.numberOfOrangeKeys = player.playerInventory.numberOfOrangeKeys;
        inventory.numberOfNecklace = player.playerInventory.numberOfNecklace;
        inventory.numberOfScroll = player.playerInventory.numberOfScroll;
        inventory.numberOfDiamond = player.playerInventory.numberOfDiamond;
        inventory.numberOfGem = player.playerInventory.numberOfGem;
        inventory.numberOfMask = player.playerInventory.numberOfMask;
        inventory.coins = player.playerInventory.coins;
        inventory.items = player.playerInventory.items;

        position1 = player.transform.position.x;
        position2 = player.transform.position.y;
        position3 = player.transform.position.z;
    }
}
