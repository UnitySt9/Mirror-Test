using Mirror;
using UnityEngine;
using TMPro;

namespace _Project.Scripts
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private float movementSpeed = 5f;
    
        [SyncVar(hook = nameof(OnNameChanged))]
        public string playerName;

        public override void OnStartClient()
        {
            if (nameText != null)
            {
                nameText.text = playerName;
            }
        }

        private void Start()
        {
            if (isLocalPlayer)
            {
                string defaultName = "Player_" + Random.Range(1000, 9999);
                string name = PlayerPrefs.GetString("PlayerName", defaultName);
                CmdSetPlayerName(name);
            }
        }

        private void Update()
        {
            if (!isLocalPlayer) return;
        
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
            transform.Translate(movement * (movementSpeed * Time.deltaTime), Space.World);
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CmdSendChatMessage($"Привет от {playerName}");
            }
        }

        [Command]
        private void CmdSetPlayerName(string name)
        {
            playerName = name;
        }

        [Command]
        private void CmdSendChatMessage(string message)
        {
            RpcReceiveChatMessage(message);
        }

        [ClientRpc]
        private void RpcReceiveChatMessage(string message)
        {
            Debug.Log(message);
        }

        private void OnNameChanged(string oldName, string newName)
        {
            if (nameText != null)
            {
                nameText.text = newName;
            }
        }
    }
}
