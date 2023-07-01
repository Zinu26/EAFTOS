using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public FloatValue health;
    public FloatValue heart;
    public float magic;
    public float stamina;
    public float super;
    public float run;
    public int GoldKeys;
    public int SilverKeys;
    public int BlueKeys;
    public int BrownKeys;
    public int OrangeKeys;
    public int Necklace;
    public int Scroll;
    public int Diamond;
    public int Gem;
    public int Mask;
    public int coins;
    public List<Item> items;
    public float position1;
    public float position2;
    public float position3;


    public PlayerData(PlayerMovement player)
    {
        heart.RuntimeValue = player.heartContain.RuntimeValue;
        health.RuntimeValue = player.currentHealth.RuntimeValue;
        magic = player.playerInventory.currentMagic;
        stamina = player.playerInventory.currentStamina;
        super = player.playerInventory.currentSuper;
        run = player.playerInventory.currentRun;
        GoldKeys = player.playerInventory.numberOfGoldKeys;
        SilverKeys = player.playerInventory.numberOfSilverKeys;
        BlueKeys = player.playerInventory.numberOfBlueKeys;
        BrownKeys = player.playerInventory.numberOfBrownKeys;
        OrangeKeys = player.playerInventory.numberOfOrangeKeys;
        Necklace = player.playerInventory.numberOfNecklace;
        Scroll = player.playerInventory.numberOfScroll;
        Diamond = player.playerInventory.numberOfDiamond;
        Gem = player.playerInventory.numberOfGem;
        Mask = player.playerInventory.numberOfMask;
        coins = player.playerInventory.coins;
        items = player.playerInventory.items;

        position1 = player.transform.position.x;
        position2 = player.transform.position.y;
        position3 = player.transform.position.z;
    }

}
