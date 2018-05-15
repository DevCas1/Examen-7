using UnityEngine;

public enum CardRarity { Common, Rare, Epic }

namespace Sjouke.Cards
{
    [CreateAssetMenu(menuName = "PlayCardInfo", order = 2)]
    public sealed class PlayCardInfo : ScriptableObject
    {
        public string Name;
        public CardRarity Rarity;
        public int Health;
        public int Damage;
    }
}