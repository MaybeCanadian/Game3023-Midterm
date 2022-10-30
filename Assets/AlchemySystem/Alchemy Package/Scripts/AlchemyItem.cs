using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Effect
{
    public EffectTypes effectType;
    public float Duration; //how long the effect should last. This info will be outputed for later use.
    public float strength; //for healing potions this will be how much they could heal. Though up to dev
}


[CreateAssetMenu(fileName = "New Alchemy Item", menuName = "Items/Alchemy/New Alchemy Item")]
public class AlchemyItem : ScriptableObject //the alchemy item will be what interacts with the alchemy system
{
    public Effect baseEffect; //all effects can be found in the enum, more can be added or removed to suit the dev usage. 
}
