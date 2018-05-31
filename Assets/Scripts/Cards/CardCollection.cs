using System.Collections.Generic;

namespace Sjouke.Cards
{
    [UnityEngine.CreateAssetMenu(fileName = "New Deck Collection", menuName = "Runtime Collections/Player Deck Collection\t(Deck)", order = 4), System.Serializable]
    public sealed class CardCollection : CodeArchitecture.RuntimeCollections.RuntimeCollection<PlayCardInfo>
    {
        private new string name;
    }
}