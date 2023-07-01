using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Inventory : ScriptableObject
{

    [Header("Inventory Content")]
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfGoldKeys;
    public int numberOfSilverKeys;
    public int numberOfBlueKeys;
    public int numberOfBrownKeys;
    public int numberOfOrangeKeys;
    public int numberOfNecklace;
    public int numberOfScroll;
    public int numberOfDiamond;
    public int numberOfGem;
    public int numberOfMask;
    public int coins;
    public float maxMagic = 20;
    public float currentMagic;
    public float maxStamina = 30;
    public float currentStamina;
    public float maxSuper = 50;
    public float currentSuper;
    public float maxRun = 100;
    public float currentRun;

    public void OnEnable()
    {
    }

    public void ReduceRun(float runCost)
    {
        currentRun -= runCost;
    }

    public void ReduceStamina(float staminaCost)
    {
        currentStamina -= staminaCost;
    }

    public void ReduceSuper(float superCost)
    {
        currentSuper -= superCost;
    }

    public void ReduceMagic(float magicCost)
    {
        currentMagic -= magicCost;
    }

    public bool CheckForItem(Item item)
    {
        if (items.Contains(item))
        {
            return true;
        }
        return false;
    }

    public void DecreaseAmount(Item itemToDecrease)
    {
        if(itemToDecrease.isBlueKey)
        {
            numberOfBlueKeys--;
        }
    }

    public void AddItem(Item itemToAdd)
    {
        if (itemToAdd.isGoldKey)
        {
            numberOfGoldKeys++;
        }
        else if (itemToAdd.isSilverKey)
        {
            numberOfSilverKeys++;
        }
        else if (itemToAdd.isBlueKey)
        {
            numberOfBlueKeys++;
        }
        else if (itemToAdd.isBrownKey)
        {
            numberOfBrownKeys++;
        }
        else if (itemToAdd.isOrangeKey)
        {
            numberOfOrangeKeys++;
        }
        else if (itemToAdd.isNecklace)
        {
            numberOfNecklace++;
        }
        else if (itemToAdd.isScroll)
        {
            numberOfScroll++;
        }
        else if (itemToAdd.isGem)
        {
            numberOfGem++;
        }
        else if (itemToAdd.isDiamond)
        {
            numberOfDiamond++;
        }
        else if (itemToAdd.isMask)
        {
            numberOfMask++;
        }
        else
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}

