using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlcPackageActiveItem : MonoBehaviour
{
    [Header("Item Selected")]
    [SerializeField]
    private bool hasItem = false;
    [Header("UI References")]
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private TMP_Text itemName;
    [SerializeField]
    private TMP_Text itemDescription;
    [SerializeField]
    private TMP_Text itemCount;
    [SerializeField]
    private GameObject activeParent;
    [SerializeField]
    private AlcPackageInventory inventory;

    [Header("Active Values")]
    [SerializeField]
    private string activeName;
    [SerializeField]
    private string activeDescription;
    [SerializeField]
    private int activeCount;
    [SerializeField]
    private Sprite activeIcon;


    private void Start()
    {
        UpdateActiveSlot();
    }

    private void UpdateActiveSlot()
    {
        if(hasItem == false)
        {
            activeParent.SetActive(false);
            return;
        }

        activeParent.SetActive(true);

        itemName.text = activeName;
        itemCount.text = activeCount.ToString();
        itemDescription.text = activeDescription;
        itemIcon.sprite = activeIcon;

    }

    public void SetActiveItemValues(Sprite icon, string name, string description, int count)
    {
        activeName = name;
        activeDescription = description;
        activeIcon = icon;
        activeCount = count;
        hasItem = true;

        UpdateActiveSlot();
    }

    public void SetSlotActive(bool input)
    {
        activeParent.SetActive(input);
    }
}
