using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
[System.Serializable]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;

    [Header("Type of Item")]
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

    [Header("Events")]
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
}
