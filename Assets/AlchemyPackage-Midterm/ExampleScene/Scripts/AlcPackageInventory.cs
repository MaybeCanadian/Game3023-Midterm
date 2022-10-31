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

        if (activeSlot == -1)
            return;

        activeItem.UpdateValues(items[activeSlot].Count);
    } //goes through the list of items we have and shows them on the slots, the item order is the order in the list
    //if items are added or removed it should be fine.

    public void SlotPressed(int slotNumber)
    {
        ResetSelectedSlot();
        if(items.Count >= slotNumber)
        {
            Debug.Log("pressed on " + items[slotNumber].item.itemName);
            activeItem.SetActiveItemValues(items[slotNumber].item.itemIcon, items[slotNumber].item.itemName,
                items[slotNumber].item.Description, items[slotNumber].Count, items[slotNumber].item.itemUseEffect);

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

    public Sprite GetActiveSprite(out int slotNumber)
    {
        if(activeSlot != -1)
        {
            slotNumber = activeSlot;
            ChangeItemCountBy(activeSlot, -1);
            return items[activeSlot].item.itemIcon;
        }

        slotNumber = -1;
        return null;
    } //returns the currently selected sprite, used for the crafting slots so they know what to add
    //it has an out param that also sends the item slot it is holding so if we want to remove the item from the slot we can readd it to our counts.

    public void ReturnItem(int slotNumber, int amount)
    {
        if (slotNumber == -1)
            return;

        ChangeItemCountBy(slotNumber, amount);
    } //takes in a slot number and adds back the amount to that slot

    private void ChangeItemCountBy(int slotNumber, int value)
    {

        InventoryItem tempItem;
        tempItem.item = items[slotNumber].item;
        tempItem.Count = items[slotNumber].Count + value;

        items[slotNumber] = tempItem;

        UpdateSlots();
    } //this is a small helper function to assist with changing the count in the struct
    //since it is passed as a copy I need to make a new one first. Might now be the best method, could make the struct a class but then we lose the
    //editor setting

    public AlchemyItem GetAlchemyItem(int slotNumber)
    {
        if (slotNumber == -1)
            return null;

        return items[slotNumber].item;
    }

}

[System.Serializable]
public struct InventoryItem
{
    public AlchemyItem item;
    public int Count;
}
