using UnityEngine;

public enum CardRarity { Common = 0, Rare = 1, Epic = 2 }

namespace Sjouke.Cards
{
    [CreateAssetMenu(menuName = "PlayCard Info", order = 2)]
    public sealed class PlayCardInfo : ScriptableObject
    {
        public CardRarity Rarity;
        private new string name;
        [Multiline] public string Description;
        public int ManaCost;
        public int Health;
        public int Damage;
        public Sprite CardFront;
        public Sprite Artwork;
        public int GoldValue = 1;
        public int ID;
    }
}