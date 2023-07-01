using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable
{
    [Header("To Inventory Panel")]
    public PlayerInventory Inventory;

    [Header("Contents")]
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;

    [Header("Signals and Dialog")]
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    public AudioSource audioS;

    [Header("Animation")]
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RuntimeValue;
        if (isOpen)
        {
            anim.SetBool("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDialog;
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        AddItemToInventory();
        context.Raise();
        isOpen = true;
        anim.SetBool("opened", true);
        storedOpen.RuntimeValue = isOpen;
        if (!audioS.isPlaying)
        {
            audioS.Play();
        }
        else
        {
            audioS.Stop();
        }
    }

    public void ChestAlreadyOpen()
    {
        dialogBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }

    public void AddItemToInventory()
    {
        if (Inventory && contents)
        {
            if (Inventory.myInventory.Contains(contents))
            {
                contents.numberHeld += 1;
            }
            else
            {
                Inventory.myInventory.Add(contents);
                contents.numberHeld += 1;
            }
        }
    }
}
