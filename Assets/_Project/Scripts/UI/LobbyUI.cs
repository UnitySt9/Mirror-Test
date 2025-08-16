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
            if (string.IsNullOrWhiteSpace(_nameInput.text))
            {
                Debug.LogWarning("Player name cannot be empty!");
                return;
            }
            
            PlayerPrefs.SetString("PlayerName", _nameInput.text);
            _networkManager.StartClient();
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _connectButton.onClick.RemoveListener(OnConnectClicked);
        }
    }
}
