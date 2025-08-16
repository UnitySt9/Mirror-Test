using Mirror;
using UnityEngine;

namespace _Project.Scripts
{
    public class PlayerChat : NetworkBehaviour
    {
        private PlayerName _playerName;

        private void Awake()
        {
            _playerName = GetComponent<PlayerName>();
        }

        private void Update()
        {
            if (!isLocalPlayer) return;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CmdSendChatMessage();
            }
        }

        [Command]
        private void CmdSendChatMessage()
        {
            RpcReceiveChatMessage($"Привет от {_playerName.Name}");
        }

        [ClientRpc]
        private void RpcReceiveChatMessage(string message)
        {
            Debug.Log(message);
        }
    }
}
