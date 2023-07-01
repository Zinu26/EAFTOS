using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [Header("Content")]
    public LootTable thisLoot;

    public AudioSource audioSrc;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    public void Smash()
    {
        anim.SetBool("smash", true);
        StartCoroutine(breakCo());
        audioSrc.Play();
    }

    IEnumerator breakCo()
    {
        MakeLoot();
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }

    private void MakeLoot()
    {
        if (thisLoot != null)
        {
            PowerUp current = thisLoot.LootPowerup();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
