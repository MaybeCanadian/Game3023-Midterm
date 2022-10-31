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
    private TMP_Text itemEffects;
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
    [SerializeField]
    private string activeEffects;


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
        itemEffects.text = activeEffects;

    }

    public void SetActiveItemValues(Sprite icon, string name, string description, int count, string effectDescription)
    {
        activeName = name;
        activeDescription = description;
        activeIcon = icon;
        activeCount = count;
        hasItem = true;
        activeEffects = effectDescription;

        UpdateActiveSlot();
    }

    public void UpdateValues(int count)
    {
        activeCount = count;

        UpdateActiveSlot();
    }

    public void SetSlotActive(bool input)
    {
        activeParent.SetActive(input);
    }
}
