using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlcPackageInventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TMP_Text countText;
    [SerializeField]
    private int count;
    [SerializeField]
    private GameObject slotObject;
    [SerializeField]
    private GameObject selectedMarker;
    [SerializeField]
    private AlcPackageInventory inventory;
    [SerializeField]
    private int SlotNumber = 0;

    private void Start()
    {
        UpdateCount();
    }

    public void SetSlot(Sprite slotIcon, int slotCount)
    {
        icon.sprite = slotIcon;
        count = slotCount;
        UpdateCount();
    }

    private void UpdateCount()
    {
        if (count <= 0)
            SetSlotInactive();
        else
            SetSlotActive();

        countText.text = count.ToString();
    }

    public void SetSlotInactive()
    {
        slotObject.SetActive(false);
    }

    public void SetSlotActive()
    {
        slotObject.SetActive(true);
    }

    public void OnSlotPressed()
    {
        selectedMarker.SetActive(true);
        inventory.SlotPressed(SlotNumber);
    }

    public void SetSelected(bool input)
    {
        selectedMarker.SetActive(input);
    }
}
