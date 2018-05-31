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

        private void Reset() => playCard = GetComponent<PlayCard>();
        
        public void UpdateValues()
        {
            if (playCard == null) playCard = GetComponent<PlayCard>();
            QuantityText.text = PlayerLibrary.Cards.FindAll(x => x.ID == playCard.CardInfo.ID).Count > 0 ? PlayerLibrary.Cards.FindAll(x => x.ID == playCard.CardInfo.ID).Count + "x" : 
                                                                                                         PlayerLibrary.Cards.FindAll(x => x.name == playCard.CardInfo.name).Count + "x";
        }
    }
}