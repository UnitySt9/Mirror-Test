using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class LobbyUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField] private Button connectButton;
        [SerializeField] private NetworkManagerCustom networkManager;

        private void Start()
        {
            if (connectButton != null)
            {
                connectButton.onClick.AddListener(OnConnectClicked);
            }
            else
            {
                Debug.LogError("Connect Button not assigned in LobbyUI");
            }

            nameInput.text = PlayerPrefs.GetString("PlayerName", "");
        }

        private void OnConnectClicked()
        {
            if (string.IsNullOrWhiteSpace(nameInput.text))
            {
                Debug.LogWarning("Player name cannot be empty!");
                return;
            }
            PlayerPrefs.SetString("PlayerName", nameInput.text);
            networkManager.StartClient();
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (connectButton != null)
            {
                connectButton.onClick.RemoveListener(OnConnectClicked);
            }
        }
    }
}
