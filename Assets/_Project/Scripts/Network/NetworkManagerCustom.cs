using Mirror;
using UnityEngine;

namespace _Project.Scripts
{
    public class NetworkManagerCustom : NetworkManager
    {
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            GameObject player = Instantiate(playerPrefab);
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
}
