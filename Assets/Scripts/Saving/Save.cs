using System.Collections.Generic;
using Sjouke.Cards;
using Sjouke.CodeArchitecture.Variables;
using UnityEngine;

namespace Sjouke.Serialization
{
    [System.Serializable]
    internal sealed class CardData
    {
        public string Name;
        public int Id;

        public int CardQuantity;

        public CardData(PlayCardInfo info)
        {
            Name = info.name;
            Id = info.ID;
            CardQuantity = 1;
        }
    }

    [System.Serializable]
    internal sealed class Save
    {
        //public PlayerDecks PlayerDecks;
        public List<CardData> PlayerLibrary;
        public int Gold;

        public Save(List<CardData> cardData, int gold)
        {
            PlayerLibrary = cardData;
            Gold = gold;
        }
    }
}