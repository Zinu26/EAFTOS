using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DoorType
{
    GoldKey,
    BrownKey,
    SilverKey,
    BlueKey,
    OrangeKey,
    Necklace,
    enemy,
    button,
    Diamond,
    Gem,
    Scroll,
    Mask
}

public class LockDoor : Interactable
{

    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public Item thisItem;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public bool isOpen;
    public DoorBoolValue storedOpen;


    private void Start()
    {
        doorSprite = GetComponent<SpriteRenderer>();
        open = storedOpen.RuntimeValue;
        if (storedOpen.RuntimeValue == true)
        {
            AlreadyOpen();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange && thisDoorType == DoorType.GoldKey)
            {
                if (playerInventory.numberOfGoldKeys > 0 && thisItem.isGoldKey)
                {
                    thisItem.numberHeld--;
                    playerInventory.numberOfGoldKeys--;
                    Open();
                }
                if (storedOpen.RuntimeValue == true)
                {
                    AlreadyOpen();
                }
            }
            else if (playerInRange && thisDoorType == DoorType.SilverKey)
            {
                if (playerInventory.numberOfSilverKeys > 0 && thisItem.isSilverKey)
                {
                    thisItem.numberHeld--;
                    playerInventory.numberOfSilverKeys--;
                    Open();
                }
                if (storedOpen.RuntimeValue == true)
                {
                    AlreadyOpen();
                }
            }
            else if (playerInRange && thisDoorType == DoorType.BlueKey)
            {
                if (playerInventory.numberOfBlueKeys > 0 && thisItem.isBlueKey)
                {
                    thisItem.numberHeld--;
                    playerInventory.numberOfBlueKeys--;
                    Open();
                }
                if (storedOpen.RuntimeValue == true)
                {
                    AlreadyOpen();
                }
            }
            else if (playerInRange && thisDoorType == DoorType.BrownKey)
            {
                if (playerInventory.numberOfBrownKeys > 0 && thisItem.isBrownKey)
                {
                    thisItem.numberHeld--;
                    playerInventory.numberOfBrownKeys--;
                    Open();
                }
                if (storedOpen.RuntimeValue == true)
                {
                    AlreadyOpen();
                }
            }
            else if (playerInRange && thisDoorType == DoorType.OrangeKey)
            {
                if (playerInventory.numberOfOrangeKeys > 0 && thisItem.isOrangeKey)
                {
                    thisItem.numberHeld--;
                    playerInventory.numberOfOrangeKeys--;
                    Open();
                }
                if (storedOpen.RuntimeValue == true)
                {
                    AlreadyOpen();
                }
            }
            else if (playerInRange && thisDoorType == DoorType.Necklace)
            {
                if (playerInventory.numberOfNecklace > 0 && thisItem.isNecklace)
                {
                    thisItem.numberHeld--;
                    playerInventory.numberOfNecklace--;
                    Open();
                }
                if (storedOpen.RuntimeValue == true)
                {
                    AlreadyOpen();
                }
            }
            else if (playerInRange && thisDoorType == DoorType.Scroll)
            {
                if (playerInventory.numberOfScroll > 0 && thisItem.isScroll)
                {
                    thisItem.numberHeld--;
                    playerInventory.numberOfScroll--;
                    Open();
                }
                if (storedOpen.RuntimeValue == true)
                {
                    AlreadyOpen();
                }
            }
            else if (playerInRange && thisDoorType == DoorType.Gem)
            {
                if (playerInventory.numberOfGem > 0 && thisItem.isGem)
                {
                    thisItem.numberHeld--;
                    playerInventory.numberOfGem--;
                    Open();
                }
                if (storedOpen.RuntimeValue == true)
                {
                    AlreadyOpen();
                }
            }
            else if (playerInRange && thisDoorType == DoorType.Diamond)
            {
                if (playerInventory.numberOfDiamond > 0 && thisItem.isDiamond)
                {
                    thisItem.numberHeld--;
                    playerInventory.numberOfDiamond--;
                    Open();
                }
                if (storedOpen.RuntimeValue == true)
                {
                    AlreadyOpen();
                }
            }
            else if (playerInRange && thisDoorType == DoorType.Mask)
            {
                if (playerInventory.numberOfMask > 0 && thisItem.isMask)
                {
                    thisItem.numberHeld--;
                    playerInventory.numberOfMask--;
                    Open();
                }
                if (storedOpen.RuntimeValue == true)
                {
                    AlreadyOpen();
                }
            }
        }
    }

    public void Open()
    {
        doorSprite.enabled = false;
        open = true;
        physicsCollider.enabled = false;
        isOpen = true;
        storedOpen.RuntimeValue = isOpen;
    }

    public void AlreadyOpen()
    {
        doorSprite.enabled = false;
        open = true;
        physicsCollider.enabled = false;
        isOpen = true;
    }

    public void Close()
    {

    }
}
