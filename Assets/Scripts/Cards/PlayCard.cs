using Sjouke.Serialization;
using UnityEngine;
using TMPro;

namespace Sjouke.Cards
{
    [System.Serializable]
    public class CardReference
    {
        public TextMeshPro NameText;
        public TextMeshPro DescriptionText;
        public TextMeshPro ManaText;
        public TextMeshPro DamageText;
        public TextMeshPro HealthText;
        public SpriteRenderer CardFront;
        public SpriteRenderer ArtworkPicture;
    }
    [System.Serializable]
    public class PlayCard : MonoBehaviour
    {
        [SerializeField] private PlayCardInfo _cardInfo;
        public PlayCardInfo CardInfo
        {
            get { return _cardInfo; }
            set
            {
                _cardInfo = value;
                UpdateValues();
            }
        }
        public CardReference References;
        public UnityEngine.Camera MainCamera;
        public SaveGameManager SaveGameManager;
        // A list of Effects

        private void Start() => UpdateValues();

        public void UpdateValues()
        {
            References.NameText.text = CardInfo.name;
            References.DescriptionText.text = CardInfo.Description;
            References.ManaText.text = CardInfo.ManaCost.ToString();
            References.DamageText.text = CardInfo.Damage.ToString();
            References.HealthText.text = CardInfo.Health.ToString();
            if (CardInfo.CardFront != null) References.CardFront.sprite = CardInfo.CardFront;
            References.ArtworkPicture.sprite = CardInfo.Artwork;
            if (MainCamera == null && UnityEngine.Camera.main != null) MainCamera = UnityEngine.Camera.main;
        }

        private void Update() => CheckFacingDir();

        private void CheckFacingDir()
        {
            References.CardFront.enabled = 
            References.NameText.enabled =
            References.DescriptionText.enabled =
            References.ManaText.enabled =
            References.DamageText.enabled =
            References.HealthText.enabled = IsFacingTarget(transform, MainCamera.transform, -0.1f);
        }

        /// <summary>Check if Transform origin is facing Transform target.</summary>
        /// <param name="origin">The transform to check if it is facing target.</param>
        /// <param name="target">The target origin should face.</param>
        /// <param name="tolerance">How far should origin face target to return true. (1 for facing target, -1 to face the exact opposite direciton)</param>
        /// <returns></returns>
        private bool IsFacingTarget(Transform origin, Transform target, float tolerance = 0.8f) => Vector3.Dot(origin.transform.forward, target.transform.forward) > tolerance;

        public void SellThisCard() => SaveGameManager.SellCard(CardInfo);
    }
}