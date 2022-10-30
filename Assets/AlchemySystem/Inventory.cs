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

    public void StartCrafting()
    {
        AlchemyController.Instance.StartCraft();
    }

    public void CancelCrafting()
    {
        Debug.Log("removing");
        foreach(AlchemyItem alcItem in AlchemyController.Instance.CancelCraft())
        {
            GetItem(alcItem); //we return back the item parent.
        }
    }

    public void GetItem(AlchemyItem itemType)  //we need to make sure we have a getitem function to be able to return the items back after we dont need them anymore
    {
        ItemSlot firstEmpty = null;

        foreach(ItemSlot slot in itemSlots)
        {
            if(slot.item.alchemy == itemType)
            {
                slot.Count++;
                return;
            }

            if(slot.item == null && firstEmpty == null)
            {
                firstEmpty = slot;
            }
        }

        //https://docs.unity3d.com/Manual/class-ScriptableObject.html for the functions
        firstEmpty.item = ScriptableObject.CreateInstance<>
        firstEmpty.Count = 1;
    }
    
}
