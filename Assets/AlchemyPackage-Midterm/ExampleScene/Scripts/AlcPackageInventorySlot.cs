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
        Debug.Log("slot pressed");
    }
}
