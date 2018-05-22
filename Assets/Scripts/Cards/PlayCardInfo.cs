using UnityEngine;

public enum CardRarity { Common, Rare, Epic }

namespace Sjouke.Cards
{
    [CreateAssetMenu(menuName = "PlayCardInfo", order = 2)]
    public sealed class PlayCardInfo : ScriptableObject
    {
        public CardRarity Rarity;
        private new string name;
        public string Description;
        public int ManaCost;
        public int Health;
        public int Damage;
        public Sprite Artwork;
    }
}