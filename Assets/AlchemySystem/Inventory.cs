using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<ItemSlot> itemSlots = new List<ItemSlot>();

    [SerializeField]
    GameObject inventoryPanel;

    [SerializeField]
    private bool InCraftingMode = false;

    void Start()
    {
        //Read all itemSlots as children of inventory panel
        itemSlots = new List<ItemSlot>(
            inventoryPanel.transform.GetComponentsInChildren<ItemSlot>()
            );
    }


    //the inventory can be set in crafting mode, this makes it so you dont use things while in crafting mode but can use them when in status
    public void SetCraftingModeON()
    {
        if (InCraftingMode == false)
        {
            InCraftingMode = true;
            foreach (ItemSlot slot in itemSlots)
            {
                slot.SetInCraftingMode(true);
            }
        }
    }

    public void SetCraftingModeOff()
    {
        if (InCraftingMode == true)
        {
            InCraftingMode = false;
            foreach (ItemSlot slot in itemSlots)
            {
                slot.SetInCraftingMode(false);
            }
        }
    }
}
