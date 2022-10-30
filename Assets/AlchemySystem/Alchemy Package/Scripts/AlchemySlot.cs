using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchemySlot : MonoBehaviour
{
    [SerializeField]
    private Image icon = null;

    [SerializeField]
    private bool isActive = false;

    public void SetSlotActive(Sprite input)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = input;
        isActive = true;
    }

    public void SetSlotInactive()
    {
        icon.gameObject.SetActive(false);
        isActive = false;
    }

    public bool GetActive()
    {
        return isActive;
    }
}
