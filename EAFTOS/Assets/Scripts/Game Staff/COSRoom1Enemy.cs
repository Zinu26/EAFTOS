﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COSRoom1Enemy : COSRoom1
{
    public LockDoor[] doors;

    public void CheckEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy && i < enemies.Length - 1)
            {
                return;
            }
        }
        OpenDoors();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], true);
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    ChangeActivation(enemies[i], false);
                }
                for (int i = 0; i < pots.Length; i++)
                {
                    ChangeActivation(pots[i], false);
                }
            }
        }
    }


    public void CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
    }
}
