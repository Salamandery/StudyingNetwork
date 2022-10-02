using Mirror;
using UnityEngine;

public class NetworkManagerBehaviour : NetworkManager
{
    public override void OnClientConnect()
    {
        base.OnClientConnect();

        Debug.Log("Connected to the server");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        NetworkPlayerBehaviour player = conn.identity.GetComponent<NetworkPlayerBehaviour>();
        player.SetDisplayName($"Player {numPlayers}");
        Color color = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
        player.SetTeamColor(color);

        Debug.Log($"A Player was connected to the server!" +
            $"\n {numPlayers} players.");
    }
}
