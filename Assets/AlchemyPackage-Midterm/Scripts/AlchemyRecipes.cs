using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alchemy Recipe", menuName = "Alchemy/New Alchemy Recipe")]
public class AlchemyRecipes : ScriptableObject
{
    public List<AlchemyItem> ingredients;

    public AlchemyItem outPutItem;
}
