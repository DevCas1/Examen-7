using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sjouke.CodeArchitecture.RuntimeCollections;

namespace Sjouke.Cards
{
    [CreateAssetMenu(menuName = "Runtime Collections/PlayCard\tCollection")]
    public class Deck : RuntimeCollection<PlayCard>
    {
        
    }
}