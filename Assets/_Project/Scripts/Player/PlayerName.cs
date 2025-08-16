using Mirror;
using TMPro;
using UnityEngine;

namespace _Project.Scripts
{
    public class PlayerName : NetworkBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        
        [SyncVar(hook = nameof(OnNameChanged))]
        private string _name;

        public string Name => _name;

        public void SetName(string name)
        {
            if (isLocalPlayer)
            {
                CmdSetPlayerName(name);
            }
        }

        [Command]
        private void CmdSetPlayerName(string name)
        {
            _name = name;
        }

        private void OnNameChanged(string oldName, string newName)
        {
            _name = newName;
            UpdateNameDisplay();
        }

        private void UpdateNameDisplay()
        {
            if (_nameText != null)
            {
                _nameText.text = _name;
            }
        }
    }
}
