using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchemyController : MonoBehaviour
{
    public static AlchemyController Instance { get; private set; }
    public List<AlchemySlot> craftingSlots;
    public List<AlchemyItem> currentCraftingGroup;
    public int MaxCraftingArea = 0;


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


    public bool AddItemToCraftingGroup(AlchemyItem inItem, Sprite Icon) 
        //use this function to add something to the crafting grid. It will return true/false if there is space
    {
        if (currentCraftingGroup.Count < MaxCraftingArea)
        {
            currentCraftingGroup.Add(inItem);
            foreach(AlchemySlot slots in craftingSlots)
            {
                if(slots.GetActive() == false)
                {
                    slots.SetSlotActive(Icon);
                    break;
                }
            }
            return true;
        }

        Debug.Log("Slots are full");
        return false;
    }


    //used this site to get some ideas for how to return the item https://forum.unity.com/threads/create-new-scriptable-object-at-runtime.620458/
    public AlchemyItem StartCraft()
    {

        //we return the alchemy item of what we have crafted.
        return null;
    }

    public void CancelCraft()
    {   
        
    }
}
