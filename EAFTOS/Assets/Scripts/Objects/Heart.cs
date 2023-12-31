﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    public FloatValue playerHealth;
    public FloatValue heartContainer;
    public float amountToIncrease;

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
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            if (playerHealth.RuntimeValue < heartContainer.RuntimeValue * 2)
            {
                playerHealth.RuntimeValue += amountToIncrease;
                if(playerHealth.RuntimeValue > heartContainer.RuntimeValue * 2)
                {
                    playerHealth.RuntimeValue = heartContainer.RuntimeValue * 2;
                }
            }

            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
