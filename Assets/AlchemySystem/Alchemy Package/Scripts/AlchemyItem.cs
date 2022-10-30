using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Effect
{
    public EffectTypes effectType;
    public float Duration;
    public float strength; //for healing potions this will be how much they could heal. Though up to dev
}


[CreateAssetMenu(fileName = "New Alchemy Item", menuName = "Items/Alchemy/New Alchemy Item")]
public class AlchemyItem : ScriptableObject //the alchemy item will be what interacts with the alchemy system
{
    public string itemName;
    public Effect baseEffect;
}
