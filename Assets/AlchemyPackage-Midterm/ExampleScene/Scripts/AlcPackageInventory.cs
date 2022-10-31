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
    [SerializeField]
    private GameObject inventoryParent;

    [Header("Active Item")]
    [SerializeField]
    private AlcPackageActiveItem activeItem;
    [SerializeField]
    private int activeSlot = -1;

    private void Start()
    {
        activeSlot = -1;
        UpdateSlots();
    }

    private void ResetSlots()
    {
        foreach(AlcPackageInventorySlot slot in itemSlots)
        {
            slot.SetSlotInactive();
        }
    } //resets all slots to be empty and not shown, this makes sure we dont have any extra slots if we removed items

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
    } //goes through the list of items we have and shows them on the slots, the item order is the order in the list
    //if items are added or removed it should be fine.

    public void SlotPressed(int slotNumber)
    {
        ResetSelectedSlot();
        if(items.Count >= slotNumber)
        {
            Debug.Log("pressed on " + items[slotNumber].item.itemName);
            activeItem.SetActiveItemValues(items[slotNumber].item.itemIcon, items[slotNumber].item.itemName,
                items[slotNumber].item.Description, items[slotNumber].Count);

            activeSlot = slotNumber;
        }
    } //this is called by the slots when they are pressed, it lets us know what to shown in the active slot

    private void ResetSelectedSlot()
    {
        if (activeSlot == -1)
            return;
        itemSlots[activeSlot].SetSelected(false);
    } //gets rid of the selected marker when we chose a new item

    public void CloseInventoryUI()
    {
        ResetSelectedSlot();
        activeSlot = -1;
        activeItem.SetSlotActive(false);
        inventoryParent.SetActive(false);
    } //this deselects the item we had when we close the UI
}

[System.Serializable]
public struct InventoryItem
{
    public AlchemyItem item;
    public int Count;
}
