using UnityEngine;
using TMPro;

namespace Sjouke.Cards
{
    [System.Serializable]
    public sealed class CardReference
    {
        public TextMeshPro NameText;
        public TextMeshPro DescriptionText;
        public TextMeshPro ManaText;
        public TextMeshPro DamageText;
        public TextMeshPro HealthText;
        public SpriteRenderer ArtworkPicture;
    }

    public sealed class PlayCard : MonoBehaviour
    {
        public PlayCardInfo CardInfo;
        public CardReference References;
        // A list of Effects

        private void Start() => SetValues();

        public void SetValues()
        {
            References.NameText.text = CardInfo.name;
            References.DescriptionText.text = CardInfo.Description;
            References.ManaText.text = CardInfo.ManaCost.ToString();
            References.DamageText.text = CardInfo.Damage.ToString();
            References.HealthText.text = CardInfo.Health.ToString();
            References.ArtworkPicture.sprite = CardInfo.Artwork;
        }
    }
}