using TMPro;
using UnityEngine;

namespace Sjouke.Cards
{
    [RequireComponent(typeof(PlayCard))]
    public sealed class LibraryInfo : MonoBehaviour
    {
        public TextMeshPro QuantityText;
        public CardLibrary PlayerLibrary;
        private PlayCard playCard;

        private bool isNull = false;

        private void Reset() => playCard = GetComponent<PlayCard>();

        public void UpdateValues()
        {
            if (playCard == null) playCard = GetComponent<PlayCard>();
            int quantity = PlayerLibrary.Cards.FindAll(x => x.ID == playCard.CardInfo.ID).Count;
            QuantityText.text = PlayerLibrary.Cards.FindAll(x => x.ID == playCard.CardInfo.ID).Count + "x";

            Color newColor = quantity > 0 ? Color.white : new Color(1, 1, 1, 0.33f);
            playCard.References.NameText.color = newColor;
            playCard.References.DescriptionText.color = newColor;
            playCard.References.ManaText.color = newColor;
            playCard.References.DamageText.color = newColor;
            playCard.References.HealthText.color = newColor;
            playCard.References.CardFront.color = newColor;
            playCard.References.ArtworkPicture.color = newColor;
        }
    }
}