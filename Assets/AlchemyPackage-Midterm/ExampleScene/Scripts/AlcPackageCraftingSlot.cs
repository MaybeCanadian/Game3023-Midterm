using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlcPackageCraftingSlot : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private GameObject itemParent;
    [SerializeField]
    private AlcPackageInventory inventory;

    [Header("Slot Items")]
    [SerializeField]
    private Sprite itemIconSprite;
    [SerializeField]
    private bool HasItem = false;

    [SerializeField]
    private int itemSlotNumber = -1;

    private void Start()
    {
        SetSlotActive(false);
        HasItem = false;
        itemIconSprite = null;

        UpdateSlot();
    }

    private void UpdateSlot()
    {
        if(HasItem == false)
        {
            SetSlotActive(false);
            return;
        }

        SetSlotActive(true);
        itemIcon.sprite = itemIconSprite;
    }

    public void OnSlotPressed()
    {
        if(HasItem)
        {
            RemoveAllocatedItem();
        }
        else
        {
            Sprite tempSprite = inventory.GetActiveSprite(out itemSlotNumber);

            if (tempSprite != null)
            {
                itemIconSprite = tempSprite;
                HasItem = true;
            }
        }

        UpdateSlot();
    }

    public void SetSlotActive(bool input)
    {
        itemParent.SetActive(input);
    }

    private void RemoveAllocatedItem()
    {
        inventory.ReturnItem(itemSlotNumber, 1);
        HasItem = false;
        UpdateSlot();
    }
}
