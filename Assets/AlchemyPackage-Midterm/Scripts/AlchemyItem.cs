using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//this script can always be added as a component of a larger item script.
//this is what the alchemy system will look for when doing all calculations
[CreateAssetMenu(fileName = "New Alchemy Item", menuName = "Alchemy/New Alchemy Item")]
public class AlchemyItem : ScriptableObject
{
    public string itemName = "";
    [TextArea]
    public string Description = "";
    public List<Effect> UseEffects;
    [TextArea]
    public string itemUseEffect = "";
    public List<Effect> CraftingEffects;
    public Sprite itemIcon;
    public bool Consumable = true;

    public bool CanBeIngredient = true;

    public void Use()
    {
        Debug.Log("doing stuff");
    }

    public void SetEffectText()
    {
        string temp = "";

        foreach(Effect effect in UseEffects)
        {
            string line = "";
            if(effect.strength < 0)
            {
                line += "Lose " + effect.strength + " " + effect.effectType.ToString();
            }
            else
            {
                line += "Gain " + effect.strength + " " + effect.effectType.ToString();
            }

            temp += line + "\n";
        }

        itemUseEffect = temp;
    }
}

[System.Serializable]
public struct Effect
{
    [Tooltip("what the item will do to the player")]
    public EffectTypes effectType;
    [Tooltip("how much of an effect does it have")]
    public float strength;
    [Tooltip("for how long should the effect last for?")]
    public float duration;
}

[System.Serializable]
public enum EffectTypes
{
    Health,
    Mana,
    Stamina
}
