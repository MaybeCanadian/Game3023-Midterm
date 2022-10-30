using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct ingredients
{
    public string itemName;
    public int itemCount;
}


[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipes/New Recipe")]
public class Recipe : ScriptableObject
{
    public List<ingredients> requiredItems;
    public string itemName; //output item
    public int itemCount; //How many of the item you get
    public float craftPrecantage = 100.0f; //THe chance the craft works, default 100%

    public bool CraftAtempt()
    {
        float randomChance = Random.Range(0.0f, 99.0f); 
        if(randomChance < craftPrecantage)
        {
            return true;
        }

        return false;
    }
}
