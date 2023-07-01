using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPowerUp : PowerUp
{
    public Inventory playerInventory;
    public float superValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.currentSuper += superValue;
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
