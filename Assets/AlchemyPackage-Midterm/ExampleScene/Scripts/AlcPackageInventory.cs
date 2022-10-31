using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcPackageInventory : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField]
    private List<InventoryItem> items;

    [Header("Item Slots")]
    [SerializeField]
    private List<AlcPackageInventorySlot> itemSlots;

    private void Start()
    {
        //we will start with a couple items
        UpdateSlots();
    }

    private void ResetSlots()
    {
        foreach(AlcPackageInventorySlot slot in itemSlots)
        {
            slot.SetSlotInactive();
        }
    }

    private void UpdateSlots()
    {
        ResetSlots();
        int itt = 0;
        foreach(InventoryItem item in items)
        {
            if (itemSlots[itt])
            {
                itemSlots[itt].SetSlotActive();
                itemSlots[itt].SetSlot(item.item.itemIcon, item.Count);
            }

            itt++;
        }
    }
}

[System.Serializable]
public struct InventoryItem
{
    public AlchemyItem item;
    public int Count;
}
