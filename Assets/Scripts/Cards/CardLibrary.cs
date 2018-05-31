using System.Collections.Generic;
using UnityEngine;

namespace Sjouke.Cards
{
    [CreateAssetMenu(order = 4)]
    public sealed class CardLibrary : ScriptableObject
    {
        public List<PlayCardInfo> Cards = new List<PlayCardInfo>();
    }
}