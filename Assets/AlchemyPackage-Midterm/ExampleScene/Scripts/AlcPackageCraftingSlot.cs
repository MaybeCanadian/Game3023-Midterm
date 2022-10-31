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
    private TMP_Text itemCountText;
    [SerializeField]
    private GameObject itemParent;

    [Header("Slot Items")]
    private AlchemyItem item;
    [SerializeField]
    private int itemCount = 0;
    [SerializeField]
    private Sprite itemIconSprite;
    [SerializeField]
    private bool HasItem = false;

    private void Start()
    {
        SetSlotActive(false);
        itemCount = 0;
        HasItem = false;
        itemIconSprite = null;

        UpdateSlot();
    }

    private void UpdateSlot()
    {
        if(itemCount <= 0)
        {
            SetSlotActive(false);
            return;
        }

        itemIcon.sprite = itemIconSprite;
        itemCountText.text = itemCount.ToString();
    }

    public void OnSlotPressed()
    {
        if(HasItem)
        {
            itemCount--;
            if(itemCount <= 0)
            {
                SetSlotActive(false);
                HasItem = false;
            }
        }
        else
        {
            SetSlotActive(true);
            itemCount = 1;
            HasItem = true;
        }

        UpdateSlot();
    }

    public void SetSlotActive(bool input)
    {
        itemParent.SetActive(input);
    }
}
