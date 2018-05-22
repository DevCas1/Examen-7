using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sjouke.Cards
{
    [System.Serializable]
    public sealed class References
    {
        public PlayCard[] Cards = new PlayCard[5];
    }

    [System.Serializable]
    public sealed class Probabilities
    {
        public CardRarity AssociatedRarity;
        public double ReceiveProbability;
    }

    public sealed class CardPackChooser : MonoBehaviour
    {
        [Tooltip("The library containing all obtainable cards.")]
        public CardLibrary AvailableCards;
        [Tooltip("The library for the received cards to store in.")]
        public CardLibrary PlayerLibrary;
        public References References;
        public Probabilities[] Probabilities;

        public void GetPack()
        {
            var receivedCards =References.Cards;

            foreach (var card in receivedCards)
            {
                var tempCardInfo = AvailableCards.Items[Mathf.RoundToInt((float)GetProbability())];
                card.CardInfo = tempCardInfo;
                card.gameObject.SetActive(true);
                if (!PlayerLibrary.Items.Contains(tempCardInfo))
                    PlayerLibrary.Add(tempCardInfo);
            }
        }

        private double GetProbability()
        {
            double total = Probabilities.Sum(probability => probability.ReceiveProbability);

            double randomPoint = Random.value * total;

            for (int index = 0; index < Probabilities.Length; index++)
            {
                if (randomPoint < Probabilities[index].ReceiveProbability) return index;

                randomPoint -= Probabilities[index].ReceiveProbability;
            }
            return Probabilities.Length - 1;
        }
    }
}