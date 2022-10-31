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
}
