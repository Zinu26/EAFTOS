using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject newG;
    public GameObject loadG;
    public GameObject resetG;
    public PlayerMovement player;

    public DataPlayer data;
    public FloatValue playerHealth;
    public FloatValue playerHeartContain;
    public VectorValue playerPosition;
    public Inventory playerInventory;

    public List<DoorBoolValue> doors = new List<DoorBoolValue>();
    public List<BoolValue> boolValue = new List<BoolValue>();

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


    // Start is called before the first frame update
    void Start()
    {
        loadG.SetActive(false);
        newG.SetActive(false);
        resetG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NewGame()
    {
        if (data.health != 10)
        {
            newG.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Opening");
            Data();
        }
    }

    public void LoadG()
    {
        if (data.health == 10)
        {
            loadG.SetActive(true);
        }
        else
        {
            player.LoadData();
        }
    }

    public void YesToNewGame()
    {
        SceneManager.LoadScene("Opening");
        Data();
    }

    public void NoToNewGame()
    {
        newG.SetActive(false);
        loadG.SetActive(false);
        resetG.SetActive(false);

    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ResetSave()
    {
        resetG.SetActive(true);
    }

    public void ResetData()
    {
        resetG.SetActive(false);
        Data();
    }

    public void DeleteBoolValue()
    {
        for (int i = 0, j = 0; i <= boolValue.Count || j <= doors.Count; i++, j++)
        {
            boolValue[i].RuntimeValue = boolValue[i].initialValue;
            doors[j].RuntimeValue = doors[j].initialValue;
        }
    }

    public void DeleteDoorBoolValue()
    {
    }

    public void Data()
    {
        data.Scene = null;
        data.health = playerHealth.initialValue;
        playerHealth.RuntimeValue = playerHealth.initialValue;
        data.heart = playerHeartContain.initialValue;
        playerHeartContain.RuntimeValue = playerHeartContain.initialValue;
        data.magic = playerInventory.maxMagic;
        playerInventory.currentMagic = playerInventory.maxMagic;
        data.stamina = playerInventory.maxStamina;
        playerInventory.currentStamina = playerInventory.maxStamina;
        data.super = playerInventory.maxSuper;
        playerInventory.currentSuper = playerInventory.maxSuper;
        data.run = playerInventory.maxRun;
        playerInventory.currentRun = playerInventory.maxRun;
        data.BlueKeys = 0;
        playerInventory.numberOfBlueKeys = 0;
        data.GoldKeys = 0;
        playerInventory.numberOfGoldKeys = 0;
        data.SilverKeys = 0;
        playerInventory.numberOfSilverKeys = 0;
        data.OrangeKeys = 0;
        playerInventory.numberOfOrangeKeys = 0;
        data.BrownKeys = 0;
        playerInventory.numberOfBrownKeys = 0;
        data.coins = 0;
        playerInventory.coins = 0;
        data.Masks = 0;
        playerInventory.numberOfMask = 0;
        data.Gems = 0;
        playerInventory.numberOfGem = 0;
        data.Scrolls = 0;
        playerInventory.numberOfScroll = 0;
        data.Diamonds = 0;
        playerInventory.numberOfDiamond = 0;
        data.Necklaces = 0;
        playerInventory.numberOfNecklace = 0;
        data.items = null;
        playerInventory.items = null;

        data.BlueKey.numberHeld = 0;
        data.GoldKey.numberHeld = 0;
        data.SilverKey.numberHeld = 0;
        data.OrangeKey.numberHeld = 0;
        data.BrownKey.numberHeld = 0;
        data.Mask.numberHeld = 0;
        data.Scroll.numberHeld = 0;
        data.Gem.numberHeld = 0;
        data.Diamond.numberHeld = 0;
        data.Necklace.numberHeld = 0;
        data.sword.numberHeld = 0;
        data.bow.numberHeld = 0;
        data.ring.numberHeld = 0;
        data.book.numberHeld = 0;
        data.necklace.numberHeld = 0;
        data.magicPotion.numberHeld = 0;
        data.staminaPotion.numberHeld = 0;
        data.healthPotion.numberHeld = 0;
        data.superPotion.numberHeld = 0;

        BlueKey.numberHeld = 0;
        GoldKey.numberHeld = 0;
        SilverKey.numberHeld = 0;
        OrangeKey.numberHeld = 0;
        BrownKey.numberHeld = 0;
        Mask.numberHeld = 0;
        Scroll.numberHeld = 0;
        Gem.numberHeld = 0;
        Diamond.numberHeld = 0;
        Necklace.numberHeld = 0;
        sword.numberHeld = 0;
        bow.numberHeld = 0;
        ring.numberHeld = 0;
        book.numberHeld = 0;
        necklace.numberHeld = 0;
        magicPotion.numberHeld = 0;
        staminaPotion.numberHeld = 0;
        healthPotion.numberHeld = 0;
        superPotion.numberHeld = 0;

        player.BlueKey.numberHeld = 0;
        player.GoldKey.numberHeld = 0;
        player.SilverKey.numberHeld = 0;
        player.OrangeKey.numberHeld = 0;
        player.BrownKey.numberHeld = 0;
        player.Mask.numberHeld = 0;
        player.Scroll.numberHeld = 0;
        player.Gem.numberHeld = 0;
        player.Diamond.numberHeld = 0;
        player.Necklace.numberHeld = 0;
        player.sword.numberHeld = 0;
        player.bow.numberHeld = 0;
        player.ring.numberHeld = 0;
        player.book.numberHeld = 0;
        player.necklace.numberHeld = 0;
        player.magicPotion.numberHeld = 0;
        player.staminaPotion.numberHeld = 0;
        player.healthPotion.numberHeld = 0;
        player.superPotion.numberHeld = 0;

        data.position1 = playerPosition.defaultValue.x;
        playerPosition.initialValue.x = playerPosition.defaultValue.x;
        data.position2 = playerPosition.defaultValue.y;
        playerPosition.initialValue.y = playerPosition.defaultValue.y;
        data.position3 = 0;
        DeleteBoolValue();
    }

}
