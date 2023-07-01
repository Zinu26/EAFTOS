using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle,
    ability
}
public class PlayerMovement : MonoBehaviour
{ 
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public AudioSource audioSrc;

    [Header("Save")]
    public string Scene;
    public DataPlayer data;
    public List<ScriptableObject> objects = new List<ScriptableObject>();

    [Header("Player Health")]
    public FloatValue currentHealth;
    public FloatValue heartContain;
    public Signal playerHealthSignal;

    public VectorValue startingPosition;

    [Header("Player Inventory Stuff")]
    public Inventory playerInventory;
    public SpriteRenderer receiveItemSprite;
    public Signal playerHit;

    [Header("IFrame Stuff")]
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer mySprite;

    [Header("Bow & Arrow")]
    public GameObject projectile;
    public Item bow;
    public Signal reduceMagic;

    [Header("Projectile")]
    public GameObject ballProjectile;
    public Item ring;
    public Signal reduceStamina;

    [Header("Firing Ability")]
    public Item book;
    public GameObject fireProjectile;
    public Signal reduceSuper;

    [Header("Sword")]
    public Item sword;

    [Header("Necklace")]
    public Item necklace;
    public float runCost;
    public Signal reduceRun;

    [Header("Items")]
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
    public Item magicPotion;
    public Item staminaPotion;
    public Item healthPotion;
    public Item superPotion;



    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        audioSrc = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == PlayerState.interact)
        {
            return;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
            if (Input.GetButtonDown("attack") && currentState != PlayerState.attack
                && currentState != PlayerState.stagger)
            {
                if (playerInventory.CheckForItem(sword))
                {
                    StartCoroutine(AttackCo());
                    if(!audioSrc.isPlaying)
                    {
                    audioSrc.Play();
                    }
                    else
                    {
                    audioSrc.Stop();
                    }
                }
            }
            else if (Input.GetButtonDown("bow") && currentState != PlayerState.attack
                && currentState != PlayerState.stagger)
            {
                if (playerInventory.CheckForItem(bow))
                {
                    StartCoroutine(SecondAttackCo());
                if (!audioSrc.isPlaying)
                {
                    audioSrc.Play();
                }
                else
                {
                    audioSrc.Stop();
                }
            }
            }
            else if (Input.GetButtonDown("ring") && currentState != PlayerState.attack
                && currentState != PlayerState.stagger)
            {
                if (playerInventory.CheckForItem(ring))
                {
                    StartCoroutine(ThirdAttackCo());
                if (!audioSrc.isPlaying)
                {
                    audioSrc.Play();
                }
                else
                {
                    audioSrc.Stop();
                }
            }
            }
            else if (Input.GetButtonDown("fire") && currentState != PlayerState.attack
                && currentState != PlayerState.stagger)
            {
                if (playerInventory.CheckForItem(book))
                {
                    StartCoroutine(FireCo());
                if (!audioSrc.isPlaying)
                {
                    audioSrc.Play();
                }
                else
                {
                    audioSrc.Stop();
                }
            }
            }
            else if(Input.GetKey(KeyCode.LeftAlt) && currentState != PlayerState.attack
                && currentState != PlayerState.stagger)
            {
                if (playerInventory.CheckForItem(necklace))
                {
                    if (playerInventory.currentRun > 0)
                    {
                        UpdateAnimationAndRun();
                    }
                    else
                    {
                        UpdateAnimationAndMove();
                    }
                }
            }
            else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
            {
                UpdateAnimationAndMove();
            }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.5f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private IEnumerator SecondAttackCo()
    {
        animator.SetBool("throwing", true);
        currentState = PlayerState.attack;
        yield return null;
        MakeArrow();
        animator.SetBool("throwing", false);
        yield return new WaitForSeconds(.5f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private IEnumerator ThirdAttackCo()
    {
        animator.SetBool("throw", true);
        currentState = PlayerState.attack;
        yield return null;
        MakeBall();
        animator.SetBool("throw", false);
        yield return new WaitForSeconds(.5f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private IEnumerator FireCo()
    {
        animator.SetBool("heal", true);
        currentState = PlayerState.attack;
        yield return null;
        MakeFire();
        animator.SetBool("heal", false);
        yield return new WaitForSeconds(.5f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private void GoRun()
    {
        if(playerInventory.currentRun > 0)
        {
            playerInventory.ReduceRun(runCost);
            reduceRun.Raise();
        }
    }

    private void MakeFire()
    {
        if (playerInventory.currentSuper > 0)
        {
            Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            FireProjectile fire = Instantiate(fireProjectile, transform.position, Quaternion.identity).GetComponent<FireProjectile>();
            fire.Setup(temp, ChooseProjectileDirection());
            playerInventory.ReduceSuper(fire.superCost);
            reduceSuper.Raise();
        }
    }


    private void MakeBall()
    {
        if (playerInventory.currentStamina > 0)
        {
            Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            BallProjectile ball = Instantiate(ballProjectile, transform.position, Quaternion.identity).GetComponent<BallProjectile>();
            ball.Setup(temp, ChooseProjectileDirection());
            playerInventory.ReduceStamina(ball.staminaCost);
            reduceStamina.Raise();
        }
    }

    private void MakeArrow()
    {
        if (playerInventory.currentMagic > 0)
        {
            Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.Setup(temp, ChooseProjectileDirection());
            playerInventory.ReduceMagic(arrow.magicCost);
            reduceMagic.Raise();
        }
    }

    Vector3 ChooseProjectileDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    public void RaiseItem()
    {
        if (playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("receive item", true);
                currentState = PlayerState.interact;
                receiveItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("receive item", false);
                currentState = PlayerState.idle;
                receiveItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }

    void UpdateAnimationAndRun()
    {
        if (change != Vector3.zero)
        {
            Run();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }


    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    
    void Run()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * 3 * Time.deltaTime);
        GoRun();
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime);

    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        playerHit.Raise();
        if (myRigidbody != null)
        {
            StartCoroutine(FlashCo());
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    private IEnumerator FlashCo()
    {
        int temp = 0;
        triggerCollider.enabled = false;
        while (temp < numberOfFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider.enabled = true;
    }

    public void SaveData()
    {
        //playerData
        data.Scene = Scene;
        data.health = currentHealth.RuntimeValue;
        data.heart = heartContain.RuntimeValue;

        data.position1 = transform.position.x;
        data.position2 = transform.position.y;
        data.position3 = transform.position.z;

        //playerInventory
        data.magic = playerInventory.currentMagic;
        data.stamina = playerInventory.currentStamina;
        data.super = playerInventory.currentSuper;
        data.run = playerInventory.currentRun;
        data.BlueKeys = playerInventory.numberOfBlueKeys;
        data.GoldKeys = playerInventory.numberOfGoldKeys;
        data.SilverKeys = playerInventory.numberOfSilverKeys;
        data.OrangeKeys = playerInventory.numberOfOrangeKeys;
        data.BrownKeys = playerInventory.numberOfBrownKeys;
        data.coins = playerInventory.coins;
        data.Masks = playerInventory.numberOfMask;
        data.Gems = playerInventory.numberOfGem;
        data.Scrolls = playerInventory.numberOfScroll;
        data.Diamonds = playerInventory.numberOfDiamond;
        data.Necklaces = playerInventory.numberOfNecklace;
        data.items = playerInventory.items;

        //inventory
        data.BlueKey.numberHeld = BlueKey.numberHeld;
        data.GoldKey.numberHeld = GoldKey.numberHeld;
        data.SilverKey.numberHeld = SilverKey.numberHeld;
        data.OrangeKey.numberHeld = OrangeKey.numberHeld;
        data.BrownKey.numberHeld = BrownKey.numberHeld;
        data.Mask.numberHeld = Mask.numberHeld;
        data.Scroll.numberHeld = Scroll.numberHeld;
        data.Gem.numberHeld = Gem.numberHeld;
        data.Diamond.numberHeld = Diamond.numberHeld;
        data.Necklace.numberHeld = Necklace.numberHeld;
        data.sword.numberHeld = sword.numberHeld;
        data.bow.numberHeld = bow.numberHeld;
        data.ring.numberHeld = ring.numberHeld;
        data.book.numberHeld = book.numberHeld;
        data.necklace.numberHeld = necklace.numberHeld;
        data.magicPotion.numberHeld = magicPotion.numberHeld;
        data.staminaPotion.numberHeld = staminaPotion.numberHeld;
        data.healthPotion.numberHeld = healthPotion.numberHeld;
        data.superPotion.numberHeld = superPotion.numberHeld;
    }

    public void LoadData()
    {
        //playerData
        SceneManager.LoadScene(data.Scene);

        heartContain.RuntimeValue = data.heart;
        currentHealth.RuntimeValue = data.health;

        Vector3 position;
        position.x = data.position1;
        position.y = data.position2;
        position.z = data.position3;
        transform.position = position;

        startingPosition.initialValue.x = position.x;
        startingPosition.initialValue.y = position.y;

        //playerInventory
        playerInventory.currentMagic = data.magic;
        playerInventory.currentStamina = data.stamina;
        playerInventory.currentSuper = data.super;
        playerInventory.currentRun = data.run;
        playerInventory.numberOfBlueKeys = data.BlueKeys;
        playerInventory.numberOfGoldKeys = data.GoldKeys;
        playerInventory.numberOfSilverKeys = data.SilverKeys;
        playerInventory.numberOfBrownKeys = data.BrownKeys;
        playerInventory.numberOfOrangeKeys = data.OrangeKeys;
        playerInventory.coins = data.coins;
        playerInventory.numberOfMask = data.Masks;
        playerInventory.numberOfGem = data.Gems;
        playerInventory.numberOfScroll = data.Scrolls;
        playerInventory.numberOfDiamond = data.Diamonds;
        playerInventory.numberOfNecklace = data.Necklaces;
        playerInventory.items = data.items;

        //inventory
        BlueKey.numberHeld = data.BlueKey.numberHeld;
        GoldKey.numberHeld = data.GoldKey.numberHeld;
        SilverKey.numberHeld = data.SilverKey.numberHeld;
        OrangeKey.numberHeld = data.OrangeKey.numberHeld;
        BrownKey.numberHeld = data.BrownKey.numberHeld;
        Mask.numberHeld = data.Mask.numberHeld;
        Scroll.numberHeld = data.Scroll.numberHeld;
        Gem.numberHeld = data.Gem.numberHeld;
        Diamond.numberHeld = data.Diamond.numberHeld;
        Necklace.numberHeld = data.Necklace.numberHeld;
        sword.numberHeld = data.sword.numberHeld;
        bow.numberHeld = data.bow.numberHeld;
        ring.numberHeld = data.ring.numberHeld;
        book.numberHeld = data.book.numberHeld;
        necklace.numberHeld = data.necklace.numberHeld;
        magicPotion.numberHeld = data.magicPotion.numberHeld;
        staminaPotion.numberHeld = data.staminaPotion.numberHeld;
        healthPotion.numberHeld = data.healthPotion.numberHeld;
        superPotion.numberHeld = data.superPotion.numberHeld;
    }

}
