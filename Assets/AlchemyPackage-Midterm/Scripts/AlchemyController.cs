using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class AlchemyController : MonoBehaviour
{
    static public AlchemyController instance;
    [SerializeField]
    private List<AlchemyRecipes> recipes;
    [SerializeField]
    private List<AlchemyItem> ingredients;
    [Header("Flags")]
    [Tooltip("Should the items allowed as ingredient tag be checked?"), SerializeField]
    private bool IgnoreValidityCheck = false;
    [Tooltip("Should a non recipe craft make a default output or nothing"), SerializeField]
    private bool allowDefaultOutput = true;
    [SerializeField]
    private AlchemyItem defaultOutPut;

    private void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    } //sets up the instance

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
                float randomChance = UnityEngine.Random.Range(0, 100);
                if(recipe.successChance < randomChance)
                {
                    amount = 0;
                    consumed = true;
                    Debug.Log("oops, crafting failed.");
                    return null;
                }

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
    } //this is the function we want to call when we are ready to craft
    //it has a few things it needs, first it takes in a list of the alchemy item componets we are using to craft. This will determine the out put.
    //we also give it and out veraible for amount and consumed, amount is incase the recipe makes more than 1 item. Cosnumed is if the items are supposed to be consumed after.
    //consumed is defined inside the recipe.

    private bool CheckRecipe(AlchemyRecipes recipe) 
    {
        Debug.Log("Checking recipe: " + recipe.name);
        Debug.Log("Have " + PrintCurrentItems());
        Debug.Log("Want " + recipe.PrintRecipe());
        if (ingredients.Count != recipe.ingredients.Count)
        {
            return false;
        }

        List<AlchemyItem> tempList = new List<AlchemyItem>();

        foreach(AlchemyItem item in ingredients)
        {
            tempList.Add(item);
        }

        foreach(AlchemyItem RecipeItem in recipe.ingredients)
        {
            if (tempList.Contains(RecipeItem))
            {
                tempList.Remove(RecipeItem);
            }
            else
            {
                return false;
            }
        }

        return true;
    } //this takes in a recipe and compares the ingredients the script has and outputs wheather they match the recipe or not.
    //as of now it checks top down meaning if two recipes have the same ingreidents it will output the higher of the two.

    private AlchemyItem MakeOutPut(AlchemyRecipes recipe)
    {
        AlchemyItem outPut = recipe.outPutItem;
         
        //this is where we set up the new item based on inputs

        return outPut;
    } //This just takes in the recipe and outputs the resulting alchemy item. It can be expaned upon if needed.

    private AlchemyItem MakeDefaultOutPut()
    {
        AlchemyItem outPut = Instantiate<AlchemyItem>(defaultOutPut);
        if (!outPut)
            Debug.Log("Can't make the alchemy item");
        outPut.itemName = "Crafted Potion";
        outPut.UseEffects = DetermineNewEffects();
        outPut.SetEffectText();

        return outPut;
    } //this creates a default crafted item and sets it up with the new stats based on the ingredients.

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

            
            if(StrngthTotal != 0 && DurationTotal > 0)
            {
                //Debug.Log(effecttype);
                TempEffect.strength = StrngthTotal;
                TempEffect.duration = DurationTotal;

                newEffects.Add(TempEffect);
            } 
            
        }

        return newEffects;
    } //determine effects is used by the make default output script to first make a combined list of all effects
    //and seccond it removed duplicates by adding the effects together.
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
    } //this is a check to make sure no items tagged as not ingredients are in the list, if they are and the check for
    //validity is checked it will send back a failed craft attempt but not use the items.
}
