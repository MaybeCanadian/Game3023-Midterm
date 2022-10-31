using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//this script can always be added as a component of a larger item script.
//this is what the alchemy system will look for when doing all calculations
[CreateAssetMenu(fileName = "New Alchemy Item", menuName = "Items/Base Items/New Alchemy Item")]
public class AlchemyItem : ScriptableObject
{
    public string itemName = "";
    public string Description = "";
    public List<Effect> ItemEffects;
    public Sprite itemIcon;
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
    HealthGain,
    ManaGain,
    StaminaGain
}
