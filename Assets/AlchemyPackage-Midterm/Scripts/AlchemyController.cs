using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AlchemyController : MonoBehaviour
{
    public List<AlchemyRecipes> recipes;

    [SerializeField]
    private List<AlchemyItem> ingredients;

    public bool IgnoreValidityCheck = false;

    public bool allowDefaultOutput = true;

    public AlchemyItem defaultOutPut;

    public AlchemyItem StartCraft(List<AlchemyItem> input, out int amount, out bool consumed) 
    {
        ingredients = input;

        if (!IgnoreValidityCheck)
        {
            if (!CheckForInccorectItems())
            {
                amount = 0;
                consumed = false;
                return null; //a second check to make sure nothing bad was sent.
            }
        }

        foreach(AlchemyRecipes recipe in recipes)
        {
            if (CheckRecipe(recipe))
            {
                amount = recipe.amountProduced;
                consumed = true;
                return MakeOutPut(recipe);
            }
        }

        if (allowDefaultOutput) 
        {
            amount = 1;
            consumed = true;
            return MakeDefaultOutPut();
        }

        amount = 0;
        consumed=false;
        return null;
    }

    private bool CheckRecipe(AlchemyRecipes recipe) 
    {
        return true;
    }

    private AlchemyItem MakeOutPut(AlchemyRecipes recipe)
    {
        AlchemyItem outPut = recipe.outPutItem;
         
        //this is where we set up the new item based on inputs

        return outPut;
    }

    private AlchemyItem MakeDefaultOutPut()
    {
        AlchemyItem outPut = ScriptableObject.CreateInstance<AlchemyItem>();
        outPut = defaultOutPut;

        return outPut;
    }

    private string PrintCurrentItems()
    {
        string temp = "";
        foreach(AlchemyItem item in ingredients)
        {
            temp += item.itemName + " ";
        }

        return temp;
    } //small helper that returns the list of ingredients in one string to print it

    private bool CheckForInccorectItems()
    {
        foreach(AlchemyItem item in ingredients)
        {
            if(item.CanBeIngredient == false)
            {
                return false;
            }
        }

        return true;
    }
}
