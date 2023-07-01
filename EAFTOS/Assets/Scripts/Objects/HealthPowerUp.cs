using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    public FloatValue playerHealth;
    public FloatValue heartContainer;
    public float healthValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += healthValue;
            if (playerHealth.initialValue > heartContainer.RuntimeValue * 2f)
            {
                playerHealth.initialValue = heartContainer.RuntimeValue * 2f;
            }
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
