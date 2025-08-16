using Mirror;
using UnityEngine;

namespace _Project.Scripts
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerName))]
    [RequireComponent(typeof(PlayerChat))]
    public class PlayerController : NetworkBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerName _playerName;
        private PlayerChat _playerChat;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerName = GetComponent<PlayerName>();
            _playerChat = GetComponent<PlayerChat>();
        }

        public override void OnStartLocalPlayer()
        {
            _playerMovement.enabled = true;
            _playerChat.enabled = true;
            
            string defaultName = "Player_" + Random.Range(1000, 9999);
            _playerName.SetName(PlayerPrefs.GetString("PlayerName", defaultName));
        }
    }
}
