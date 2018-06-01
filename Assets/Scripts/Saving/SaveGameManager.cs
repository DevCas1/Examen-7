using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Sjouke.Cards;
using Sjouke.CodeArchitecture.Button;
using Sjouke.CodeArchitecture.Events;
using Sjouke.CodeArchitecture.Variables;

namespace Sjouke.Serialization
{
    public class SaveGameManager : MonoBehaviour
    {
        public CardLibrary AllCards;
        public CardLibrary playerLibrary;
        public IntVariable gold;
        [Space(5)]
        public GameEvent OnSave;
        public GameEvent OnLoad;
        public IntVariable InitialGoldAmount;

        private const string _saveFileString = "/save.jelle";

        public void SaveGame()
        {
            try
            {
                Save save = CreateGameSave();
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream file = File.Create(Application.persistentDataPath + _saveFileString))
                {
                    formatter.Serialize(file, ToJSONSave(save));
                }
                if (OnSave != null) OnSave.Raise();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error in SaveGameManager (SaveGame - {e.GetType()}): {e.Message}");
            }
        }

        private Save CreateGameSave() => new Save(ToCardData(playerLibrary), gold.Value);

        public void OnGameStart()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream file = File.Open(Application.persistentDataPath + _saveFileString, FileMode.Open))
                {
                    Save save = FromJSONSave((string)formatter.Deserialize(file));
                    playerLibrary.Cards = FromCardData(save.PlayerLibrary);
                    gold.Value = save.Gold;
                }
                if (OnLoad != null) OnLoad.Raise();
            }
            catch
            {
                playerLibrary.Cards = new List<PlayCardInfo>();
                gold.Value = InitialGoldAmount.Value;
            }
        }

        public void SellCard(PlayCardInfo card)
        {
            if (playerLibrary.Cards.FindAll(x => x.ID == card.ID).Count == 0) return;

            playerLibrary.Cards.Remove(playerLibrary.Cards.First(x => x.ID == card.ID));
            gold.Value += card.GoldValue;
            SaveGame();
        }

        public void LoadGame()
        {
            try
            {
                // Reset Game Objects

                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + _saveFileString, FileMode.Open);
                Save save = FromJSONSave((string)formatter.Deserialize(file));
                file.Close();
                playerLibrary.Cards = FromCardData(save.PlayerLibrary);
                gold.Value = save.Gold;
                if (OnLoad != null) OnLoad.Raise();
            }
            catch (Exception e)
            {
                if (!File.Exists(Application.persistentDataPath + _saveFileString)) Debug.LogError("No Save game found!");
                Debug.LogError($"Error in SaveGameManager (LoadGame - {e.GetType()}): {e.Message}");
            }
        }

        internal List<CardData> ToCardData(CardLibrary library)
        {
            List<CardData> datas = new List<CardData>();
            foreach (var card in library.Cards)
            {
                if (datas.Exists(x => x.Name == card.name))
                    datas.Find(x => x.Name == card.name).CardQuantity++;
                else
                    datas.Add(new CardData(card));
            }
            return datas;
        }

        internal List<PlayCardInfo> FromCardData(List<CardData> cardDatas)
        {
            List<PlayCardInfo> datas = new List<PlayCardInfo>();
            foreach (var card in cardDatas)
            {
                for (int index = 0; index < card.CardQuantity; index++)
                {
                    datas.Add(AllCards.Cards.Find(x => x.ID == card.Id) ?? AllCards.Cards.Find(x => x.name == card.Name));
                }
            }
            return datas;
        }

        internal string ToJSONSave(CardLibrary library, IntVariable gold) => JsonUtility.ToJson(new Save(ToCardData(library), gold.Value));

        internal string ToJSONSave(Save save) => JsonUtility.ToJson(new Save(save.PlayerLibrary, save.Gold));

        internal Save FromJSONSave(string jsonSave) => JsonUtility.FromJson<Save>(jsonSave);
    }
}