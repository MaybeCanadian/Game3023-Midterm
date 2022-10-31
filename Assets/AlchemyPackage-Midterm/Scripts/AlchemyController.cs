using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor.Rendering;
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
        ingredients.Clear();
        ingredients = input;
        
        if(input.Count <= 0)
        {
            consumed = false;
            amount = 0;
            return null;
        }

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
        return false;
    }

    private AlchemyItem MakeOutPut(AlchemyRecipes recipe)
    {
        AlchemyItem outPut = recipe.outPutItem;
         
        //this is where we set up the new item based on inputs

        return outPut;
    }

    private AlchemyItem MakeDefaultOutPut()
    {
        AlchemyItem outPut = Instantiate<AlchemyItem>(defaultOutPut);
        if (!outPut)
            Debug.Log("Can't make the alchemy item");
        outPut.itemName = "test";
        outPut.UseEffects = DetermineNewEffects();
        outPut.SetEffectText();

        return outPut;
    }

    private List<Effect> DetermineNewEffects()
    {
        List<Effect> newEffects = new List<Effect>();

        List<Effect> allEffects = new List<Effect>();

        foreach(AlchemyItem item in ingredients)
        {
            foreach(Effect effect in item.CraftingEffects)
            {
                allEffects.Add(effect);
            }
        }

        string[] EffectTypeNames = System.Enum.GetNames(typeof(EffectTypes));

        float StrngthTotal = 0;
        float DurationTotal = 0;

        foreach(string effecttype in EffectTypeNames)
        {
            Debug.Log(effecttype);

            StrngthTotal = 0;
            DurationTotal = 0;

            Effect TempEffect = new Effect();

            foreach (Effect effect in allEffects)
            {
                if(effect.effectType.ToString() == effecttype)
                {
                    TempEffect.effectType = effect.effectType;
                    StrngthTotal += effect.strength;
                    DurationTotal = Mathf.Max(DurationTotal, effect.duration);
                }
            }

            Debug.Log(StrngthTotal);
            Debug.Log(DurationTotal);
            if(StrngthTotal != 0 && DurationTotal > 0)
            {
                Debug.Log(effecttype);
                TempEffect.strength = StrngthTotal;
                TempEffect.duration = DurationTotal;

                newEffects.Add(TempEffect);
            } 
            
        }

        return newEffects;
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
