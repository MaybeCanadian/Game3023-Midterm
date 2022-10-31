using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcPackageCraftingController : MonoBehaviour
{
    [Header("Slots")]
    [SerializeField]
    private List<AlcPackageCraftingSlot> craftingSlots;

    [Header("Crafting")]
    [SerializeField]
    private List<int> allocatedItems;

    [Header("UI References")]
    [SerializeField]
    private AlcPackageInventory inventory;
    [SerializeField]
    private AlchemyController controller;

    public Sprite GetActiveSprite(out int slotNumber)
    {
        int inSlotNum;
        Sprite tempSprite;
        tempSprite = inventory.GetActiveSprite(out inSlotNum);
        if(inSlotNum >= 0)
            allocatedItems.Add(inSlotNum);

        slotNumber = inSlotNum;
        return tempSprite;
    }

    public void RemoveItemFromCrafting(int slotNumber)
    {
        allocatedItems.Remove(slotNumber);
        inventory.ReturnItem(slotNumber, 1);
    }

    public void OnCancelButtonPressed()
    {
        foreach(AlcPackageCraftingSlot slot in craftingSlots)
        {
            slot.RemoveAllocatedItem();
        }

        allocatedItems.Clear();
    }

    public void OnConfirmButtonPressed()
    {
        List<AlchemyItem> craftingItems = new List<AlchemyItem>();

        foreach(int item in allocatedItems)
        {
            craftingItems.Add(inventory.GetAlchemyItem(item)); //we set up all the alchemy items we are using
        }

        foreach(AlchemyItem item in craftingItems) //checks we have no uncraftable items
        {
            if(item.CanBeIngredient == false) //we do a check here, there is a backup heck in the alchemy controller but good to check before sneding it off
            {
                Debug.Log("Error, something in this can't be crafted.");
                return;
            }
        }

        AlchemyItem outPutItem = controller.StartCraft(craftingItems, out int amount, out bool consumed);

        if (outPutItem)
        {
            inventory.AddItem(outPutItem, amount); //this addes our new item to the inventory
        }
        else
            Debug.Log("failed to craft.");

        if(consumed)
        {
            foreach(AlcPackageCraftingSlot slot in craftingSlots)
            {
                slot.ConsumeItem(); //this removes the items used, consumes them
            }
        }
    }
}
