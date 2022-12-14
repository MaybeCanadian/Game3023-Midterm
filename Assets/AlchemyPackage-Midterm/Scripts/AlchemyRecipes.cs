using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alchemy Recipe", menuName = "Alchemy/New Alchemy Recipe")]
public class AlchemyRecipes : ScriptableObject
{
    public List<AlchemyItem> ingredients;

    public AlchemyItem outPutItem;

    public float successChance = 100;

    public int amountProduced = 1;

    public string PrintRecipe()
    {
        string temp = "";

        foreach(AlchemyItem item in ingredients)
        {
            temp += item.itemName + " ";
        }

        return temp;
    }
}
