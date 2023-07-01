using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Interactable
{
    public GameObject StorePanel;
    public StorePanel panel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            StorePanel.SetActive(true);
        }
    }
}
