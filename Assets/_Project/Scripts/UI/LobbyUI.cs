using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class LobbyUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _nameInput;
        [SerializeField] private Button _connectButton;
        [SerializeField] private NetworkManagerCustom _networkManager;

        private void Start()
        {
            _connectButton.onClick.AddListener(OnConnectClicked);
            _nameInput.text = PlayerPrefs.GetString("PlayerName", "");
        }

        private void OnConnectClicked()
        {
            string playerName = _nameInput.text;
            
            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Player_" + Random.Range(1000, 9999);
                Debug.Log($"Generated random player name: {playerName}");
            }
            
            PlayerPrefs.SetString("PlayerName", playerName);
            _networkManager.StartClient();
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _connectButton.onClick.RemoveListener(OnConnectClicked);
        }
    }
}
