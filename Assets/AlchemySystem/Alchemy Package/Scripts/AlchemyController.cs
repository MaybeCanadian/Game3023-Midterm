using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyController : MonoBehaviour
{
    public static AlchemyController Instance { get; private set; }

    private void Awake()
    {
        if(Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        MaxCraftingArea = 0;
        foreach(AlchemySlot slot in craftingSlots)
        {
            if(slot)
            {
                MaxCraftingArea++;
            }
            else
            {
                craftingSlots.Remove(slot);
            }
        }
    }

    public List<AlchemyItem> currentCraftingGroup;
    public List<AlchemySlot> craftingSlots;

    public int MaxCraftingArea = 0;


    public void AddItemToCraftingGroup(AlchemyItem inItem)
    {
        currentCraftingGroup.Add(inItem);
    }


    
}
