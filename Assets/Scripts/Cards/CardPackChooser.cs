using System;
using System.Linq;
using UnityEngine;

namespace Sjouke.Cards
{
    [Serializable]
    public sealed class References
    {
        public PlayCard[] Cards = new PlayCard[5];
    }

    [Serializable]
    public sealed class Probabilities
    {
        [Tooltip("The 'weight' of this option in the random calculation. A higher value means it is more likely to be chosen.")]
        public int Weight;
    }

    public sealed class CardPackChooser : MonoBehaviour
    {
        public bool TestChances = false;
        public int TestIterations = 1000;
        [Space(20)]
        [Tooltip("The library containing all obtainable cards, seperated by rarity. (Least rare first, most rare last)")]
        public CardLibrary[] AvailableCards = new CardLibrary[Enum.GetValues(typeof(CardRarity)).Length];
        [Tooltip("The library for the received cards to store in.")]
        public CardLibrary PlayerLibrary;
        public References References;
        public Probabilities[] Probabilities = new Probabilities[Enum.GetValues(typeof(CardRarity)).Length];

        private void Reset() => Probabilities = new Probabilities[Enum.GetValues(typeof(CardRarity)).Length];

        private void Start()
        {
            if (!TestChances) return;
            TestIterate();
        }

        private void TestIterate()
        {
            int[] chances = new int[3];
            float[] chancePrecentages = new float[chances.Length];
            for (int index = 0; index < TestIterations; index++)
                chances[GetProbability()]++;

            for (int index = 0; index < chances.Length; index++)
                chancePrecentages[index] = chances[index] / (float)TestIterations * 100f;

            Debug.Log($"{transform.name} Test iterations ({TestIterations})- Common: {chances[0]} times ({chancePrecentages[0]}%) | Rare: {chances[1]} times ({chancePrecentages[1]}%) | Epic: {chances[2]} times ({chancePrecentages[2]}%)");
        }

        public void GetPack()
        {
            var receivedCards = References.Cards;

            foreach (var card in receivedCards)
            {
                int chosenRarity = GetProbability();
                PlayCardInfo tempCardInfo = AvailableCards[chosenRarity].Items[UnityEngine.Random.Range(0, AvailableCards[chosenRarity].Items.Count)];
                card.CardInfo = tempCardInfo;
                card.gameObject.SetActive(true);
                if (!PlayerLibrary.Items.Contains(tempCardInfo))
                    PlayerLibrary.Add(tempCardInfo);
            }
        }

        private int GetProbability()
        {
            int total = Probabilities.Sum(probability => probability.Weight);

            int randomPoint = UnityEngine.Random.Range(0, total + 1);
            int current = 0;

            for (int index = 0; index < Probabilities.Length; index++)
            {
                if (randomPoint > current && randomPoint <= current + Probabilities[index].Weight) return index;
                current += Probabilities[index].Weight;
            }
            return 0;
        }
    }
}