using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    public void SetActive(Sprite image)
    {
        icon.sprite = image;
    }

    public void SetInActive()
    {
        icon.sprite = null;
    }
}
