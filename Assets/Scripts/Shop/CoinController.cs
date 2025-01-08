using TMPro;
using UnityEngine;

namespace Runner
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinText;

        private PlayerDataWrapper PlayerData { get; set; }
        private void Start()
        {
            Refresh();
        }

        public void Refresh()
        {
            PlayerData = GameInstaller.Instance.SaveManager.PlayerData;
            SetPlayerCoins();
        }

        private void SetPlayerCoins()
        {
            _coinText.text = PlayerData.Coin.ToString();
        }
    }
}