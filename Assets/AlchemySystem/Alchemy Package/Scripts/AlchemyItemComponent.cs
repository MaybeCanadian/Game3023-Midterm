using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//I did a bit of research and decided on using structs, I read up using this page https://answers.unity.com/questions/750553/where-to-use-structs-and-classes.html
//I first tried using scriptable objects but they are hard to utilise during runtime so I didn't want to go with that. For classes I would need to initialize all the items somewhere in the scene first.
//structs can be added to the already existing items in the game then pass the needed data they contain into the alchemy controller.
[System.Serializable]
public struct AlchemyItemComponent
{
    [SerializeField, Tooltip("This name will be used to reference the item in recipes")]
    private string AlchemyName;
    [SerializeField, Tooltip("These tags will define what type of potion that might be crafted")]
    private List<AlchemyEffects> Effects;
}

