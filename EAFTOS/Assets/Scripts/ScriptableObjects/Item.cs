using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
[System.Serializable]
public class Item : ScriptableObject
{
    public Inventory playerInventory;
    public PlayerInventory Inventory;

    [Header("Item Description")]
    public string itemName;
    public Sprite itemSprite;
    public string itemDialog;
    public string itemDescription;
    public int numberHeld;
    public int price;

    public bool usable;
    public bool unique;

    public bool isGoldKey;
    public bool isBlueKey;
    public bool isSilverKey;
    public bool isBrownKey;
    public bool isOrangeKey;
    public bool isNecklace;
    public bool isScroll;
    public bool isGem;
    public bool isDiamond;
    public bool isMask;
    public UnityEvent thisEvent;


    public void Use()
    {
        thisEvent.Invoke();
    }

    public void DecreaseAmount(int amountToDecrease)
    {
        numberHeld -= amountToDecrease;
        if (numberHeld < 0)
        {
            numberHeld = 0;
        }
    }

    public void BlueKey(int amount)
    {
        if (playerInventory && this)
        {
            if (Inventory.myInventory.Contains(this))
            {
                this.numberHeld -= 1;
            }
            else
            {
                Inventory.myInventory.Remove(this);
                this.numberHeld -= 1;
            }
        }
    }

}
