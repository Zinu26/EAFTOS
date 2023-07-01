using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class DataPlayer : ScriptableObject
{
    public string Scene;

    [Header("Player Data")]
    public float health;
    public float heart;
    public float position1;
    public float position2;
    public float position3;

    [Header("Player Inventory Data")]
    public List<Item> items;
    public float magic;
    public float stamina;
    public float super;
    public float run;
    public int GoldKeys;
    public int SilverKeys;
    public int BlueKeys;
    public int BrownKeys;
    public int OrangeKeys;
    public int Necklaces;
    public int Scrolls;
    public int Diamonds;
    public int Gems;
    public int Masks;
    public int coins;

    [Header("Inventory Data")]

    public Item BlueKey;
    public Item GoldKey;
    public Item SilverKey;
    public Item BrownKey;
    public Item OrangeKey;
    public Item Mask;
    public Item Scroll;
    public Item Gem;
    public Item Diamond;
    public Item Necklace;
    public Item sword;
    public Item bow;
    public Item ring;
    public Item book;
    public Item necklace;
    public Item magicPotion;
    public Item staminaPotion;
    public Item healthPotion;
    public Item superPotion;

    public DataPlayer(PlayerMovement player)
    {
        Scene = player.Scene;

        //Player Data
        heart = player.heartContain.RuntimeValue;
        health = player.currentHealth.RuntimeValue;

        //Player Inventory Data
        magic = player.playerInventory.currentMagic;
        stamina = player.playerInventory.currentStamina;
        super = player.playerInventory.currentSuper;
        run = player.playerInventory.currentRun;
        GoldKeys = player.playerInventory.numberOfGoldKeys;
        SilverKeys = player.playerInventory.numberOfSilverKeys;
        BlueKeys = player.playerInventory.numberOfBlueKeys;
        BrownKeys = player.playerInventory.numberOfBrownKeys;
        OrangeKeys = player.playerInventory.numberOfOrangeKeys;
        Necklaces = player.playerInventory.numberOfNecklace;
        Scrolls = player.playerInventory.numberOfScroll;
        Diamonds = player.playerInventory.numberOfDiamond;
        Gems = player.playerInventory.numberOfGem;
        Masks = player.playerInventory.numberOfMask;
        coins = player.playerInventory.coins;
        items = player.playerInventory.items;



        //Inventory Data


        BlueKey.numberHeld = player.BlueKey.numberHeld;
        GoldKey.numberHeld = player.GoldKey.numberHeld;
        SilverKey.numberHeld = player.SilverKey.numberHeld;
        OrangeKey.numberHeld = player.OrangeKey.numberHeld;
        BrownKey.numberHeld = player.BrownKey.numberHeld;
        Mask.numberHeld = player.Mask.numberHeld;
        Scroll.numberHeld = player.Scroll.numberHeld;
        Gem.numberHeld = player.Gem.numberHeld;
        Diamond.numberHeld = player.Diamond.numberHeld;
        Necklace.numberHeld = player.Necklace.numberHeld;
        sword.numberHeld = player.sword.numberHeld;
        bow.numberHeld = player.bow.numberHeld;
        ring.numberHeld = player.ring.numberHeld;
        book.numberHeld = player.book.numberHeld;
        necklace.numberHeld = player.necklace.numberHeld;
        magicPotion.numberHeld = player.magicPotion.numberHeld;
        staminaPotion.numberHeld = player.staminaPotion.numberHeld;
        healthPotion.numberHeld = player.healthPotion.numberHeld;
        superPotion.numberHeld = player.superPotion.numberHeld;


        position1 = player.transform.position.x;
        position2 = player.transform.position.y;
        position3 = player.transform.position.z;

    }
}
