using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StorePanel : MonoBehaviour
{
    [Header("Inventory Information")]
    public GameObject storePanel;
    public PlayerInventory playerInventory;
    public Inventory inventory;
    public Signal coinSignal;
    private int num = 0;

    [Header ("Health Potion")]
    [SerializeField] private Item healthPotionSlot;
    public int healthPrice = 50;
    [SerializeField] private GameObject buyDescription1;
    [SerializeField] private Text text1;

    [Header ("Magic Potion")]
    [SerializeField] private Item magicPotionSlot;
    public int magicPrice = 75;
    [SerializeField] private GameObject buyDescription2;
    [SerializeField] private Text text2;

    [Header ("Stamina Potion")]
    [SerializeField] private Item staminaPotionSlot;
    public int staminaPrice = 100;
    [SerializeField] private GameObject buyDescription3;
    [SerializeField] private Text text3;

    [Header ("Super Potion")]
    [SerializeField] private Item superPotionSlot;
    public int superPrice = 150;
    [SerializeField] private GameObject buyDescription4;
    [SerializeField] private Text text4;

    [Header ("Sword")]
    [SerializeField] private Sprite swordSprite;
    [SerializeField] private Item swordSlot;
    [SerializeField] private KnockBack UpHitBox;
    [SerializeField] private KnockBack DownHitBox;
    [SerializeField] private KnockBack LeftHitBox;
    [SerializeField] private KnockBack RightHitBox;
    public int swordPrice = 1500;
    [SerializeField] private GameObject buyDescription5;
    [SerializeField] private Text text5;

    [Header ("Bow")]
    [SerializeField] private Sprite bowSprite;
    [SerializeField] private Item bowSlot;
    [SerializeField] private KnockBack arrow;
    public int bowPrice = 2500;
    [SerializeField] private GameObject buyDescription6;
    [SerializeField] private Text text6;

    [Header("Error")]
    [SerializeField] private GameObject errorPanel;

    private void Start()
    {
        buyDescription1.SetActive(false);
        buyDescription2.SetActive(false);
        buyDescription3.SetActive(false);
        buyDescription4.SetActive(false);
        buyDescription5.SetActive(false);
        buyDescription6.SetActive(false);
        errorPanel.SetActive(false);    
    }

    private void Update()
    {
    }

    public void SelectHealth()
    {
        buyDescription2.SetActive(false);
        buyDescription3.SetActive(false);
        buyDescription4.SetActive(false);
        buyDescription5.SetActive(false);
        buyDescription6.SetActive(false);
        num = 0;
        text1.text = "" + num;
        buyDescription1.SetActive(true);
    }

    public void SelectMagic()
    {
        buyDescription1.SetActive(false);
        buyDescription3.SetActive(false);
        buyDescription4.SetActive(false);
        buyDescription5.SetActive(false);
        buyDescription6.SetActive(false);
        num = 0;
        text2.text = "" + num;
        buyDescription2.SetActive(true);
    }
    public void SelectStamina()
    {
        buyDescription1.SetActive(false);
        buyDescription2.SetActive(false);
        buyDescription4.SetActive(false);
        buyDescription5.SetActive(false);
        buyDescription6.SetActive(false);
        num = 0;
        text3.text = "" + num;
        buyDescription3.SetActive(true);
    }
    public void SelectSuper()
    {
        buyDescription1.SetActive(false);
        buyDescription2.SetActive(false);
        buyDescription3.SetActive(false);
        buyDescription5.SetActive(false);
        buyDescription6.SetActive(false);
        num = 0;
        text4.text = "" + num;
        buyDescription4.SetActive(true);
    }
    public void SelectSword()
    {
        buyDescription1.SetActive(false);
        buyDescription2.SetActive(false);
        buyDescription3.SetActive(false);
        buyDescription4.SetActive(false);
        buyDescription6.SetActive(false);
        num = 0;
        text5.text = "" + num;
        buyDescription5.SetActive(true);
    }
    public void SelectBow()
    {
        buyDescription1.SetActive(false);
        buyDescription2.SetActive(false);
        buyDescription3.SetActive(false);
        buyDescription4.SetActive(false);
        buyDescription5.SetActive(false);
        num = 0;
        text6.text = "" + num;
        buyDescription6.SetActive(true);
    }

    public void increase()
    {
        if (num <= 99)
        {
            num += 1;
            text1.text = "" + num;
            text2.text = "" + num;
            text3.text = "" + num;
            text4.text = "" + num;
            text5.text = "" + num;
            text6.text = "" + num;
            errorPanel.SetActive(false);
            if (errorPanel == false)
            {
                num = 0;
                text1.text = "" + num;
                text2.text = "" + num;
                text3.text = "" + num;
                text4.text = "" + num;
                text5.text = "" + num;
                text6.text = "" + num;
            }
        }
        else if(num >= 99)
        {
            num = 0;
            num += 1;
            text1.text = "" + num;
            text2.text = "" + num;
            text3.text = "" + num;
            text4.text = "" + num;
            text5.text = "" + num;
            text6.text = "" + num;
            errorPanel.SetActive(false);
            if (errorPanel == false)
            {
                num = 0;
                text1.text = "" + num;
                text2.text = "" + num;
                text3.text = "" + num;
                text4.text = "" + num;
                text5.text = "" + num;
                text6.text = "" + num;
            }
        }
    }

    public void decrease()
    {
        if (num >= 1)
        {
            num -= 1;
            text1.text = "" + num;
            text2.text = "" + num;
            text3.text = "" + num;
            text4.text = "" + num;
            text5.text = "" + num;
            text6.text = "" + num;
            errorPanel.SetActive(false);
            if (errorPanel == false)
            {
                num = 0;
                text1.text = "" + num;
                text2.text = "" + num;
                text3.text = "" + num;
                text4.text = "" + num;
                text5.text = "" + num;
                text6.text = "" + num;
            }
        }
        else if(num <= 1)
        {
            num = 100;
            num -= 1;
            text1.text = "" + num;
            text2.text = "" + num;
            text3.text = "" + num;
            text4.text = "" + num;
            text5.text = "" + num;
            text6.text = "" + num;
            errorPanel.SetActive(false);
            if (errorPanel == false)
            {
                num = 0;
                text1.text = "" + num;
                text2.text = "" + num;
                text3.text = "" + num;
                text4.text = "" + num;
                text5.text = "" + num;
                text6.text = "" + num;
            }
        }
    }

    public void back()
    {
        buyDescription1.SetActive(false);
        buyDescription2.SetActive(false);
        buyDescription3.SetActive(false);
        buyDescription4.SetActive(false);
        buyDescription5.SetActive(false);
        buyDescription6.SetActive(false);
        storePanel.SetActive(false);
    }

    public void No()
    {
        errorPanel.SetActive(false);
        buyDescription1.SetActive(false);
        buyDescription2.SetActive(false);
        buyDescription3.SetActive(false);
        buyDescription4.SetActive(false);
        buyDescription5.SetActive(false);
        buyDescription6.SetActive(false);
        num = 0;
        text1.text = "" + num;
        text2.text = "" + num;
        text3.text = "" + num;
        text4.text = "" + num;
        text5.text = "" + num;
        text6.text = "" + num;
    }


    public void buyHealth()
    {
        if (inventory.coins >= healthPrice * num)
        {
            healthPrice *= num;
            healthPotionSlot.numberHeld += num;
            inventory.coins -= healthPrice;
            errorPanel.SetActive(false);
            buyDescription1.SetActive(false);
            coinSignal.Raise();
        }
        else
        {
            errorPanel.SetActive(true);
            num = 0;
            text1.text = "" + num;
        }
    }

    public void buyMagic()
    {
        if (inventory.coins >= magicPrice * num)
        {
            magicPrice *= num;
            magicPotionSlot.numberHeld += num;
            inventory.coins -= magicPrice;
            errorPanel.SetActive(false);
            buyDescription2.SetActive(false);
            coinSignal.Raise();
        }
        else
        {
            errorPanel.SetActive(true);
            num = 0;
            text2.text = "" + num;
        }
    }

    public void buyStamina()
    {
        if (inventory.coins >= staminaPrice * num)
        {
            staminaPrice *= num;
            staminaPotionSlot.numberHeld += num;
            inventory.coins -= staminaPrice;
            errorPanel.SetActive(false);
            buyDescription3.SetActive(false);
            coinSignal.Raise();
        }
        else
        {
            errorPanel.SetActive(true);
            num = 0;
            text3.text = "" + num;
        }
    }

    public void buySuper()
    {
        if (inventory.coins >= superPrice * num)
        {
            superPrice *= num;
            superPotionSlot.numberHeld += num;
            inventory.coins -= superPrice;
            errorPanel.SetActive(false);
            buyDescription4.SetActive(false);
            coinSignal.Raise();
        }
        else
        {
            errorPanel.SetActive(true);
            num = 0;
            text4.text = "" + num;
        }
    }

    public void buySword()
    {
        if (inventory.coins >= swordPrice * num)
        {
            swordPrice *= num;
            UpHitBox.damage += 3f;
            DownHitBox.damage += 3f;
            LeftHitBox.damage += 3f;
            RightHitBox.damage += 3f;
            swordSlot.itemSprite = swordSprite;
            inventory.coins -= swordPrice;
            errorPanel.SetActive(false);
            buyDescription5.SetActive(false);
            coinSignal.Raise();
        }
        else
        {
            errorPanel.SetActive(true);
            num = 0;
            text5.text = "" + num;
        }
    }

    public void buyBow()
    {
        if (inventory.coins >= bowPrice * num)
        {
            bowPrice *= num;
            arrow.damage += 5;
            bowSlot.itemSprite = bowSprite;
            inventory.coins -= bowPrice;
            errorPanel.SetActive(false);
            buyDescription6.SetActive(false);
            coinSignal.Raise();
        }
        else
        {
            errorPanel.SetActive(true);
            num = 0;
            text6.text = "" + num;
        }
    }



}
