﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : PowerUp
{
    public FloatValue heartContainers;
    public FloatValue playerHealth;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            heartContainers.RuntimeValue += 1;
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
