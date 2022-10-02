using Mirror;
using TMPro;
using UnityEngine;

public class NetworkPlayerBehaviour : NetworkBehaviour
{
    [SerializeField]
    private TMP_Text textDisplayName;
    [SerializeField]
    private Renderer rendererColor;

    [SyncVar(hook = nameof(HandlerTextDisplayName))]
    [SerializeField]
    private string displayName;
    [SyncVar(hook = nameof(HandlerTeamColor))]
    [SerializeField]
    private Color teamColor;

    #region Server
    [Server]
    public void SetDisplayName(string displayName)
    {
        this.displayName = displayName;
    }

    [Server]
    public void SetTeamColor(Color teamColor)
    {
        this.teamColor = teamColor;
    }

    [Command]
    private void CmdSetDisplayName(string newDisplayName)
    {
        RpcLogNewName(newDisplayName);
        SetDisplayName(newDisplayName);
    }
    #endregion

    #region Client
    private void HandlerTeamColor(Color color, Color newColor)
    {
        rendererColor.material.SetColor("_Color", newColor);
    }

    private void HandlerTextDisplayName(string displayName, string newTextDisplay)
    {
        textDisplayName.text = newTextDisplay;
    }

    [ContextMenu("Set My Name")]
    public void SetMyName()
    {
        CmdSetDisplayName("Guest");
    }

    [ClientRpc]
    private void RpcLogNewName(string newDisplayName)
    {

    }
    #endregion
    void Start()
    {
        //rendererColor = gameObject.GetComponent<Renderer>();
    }
}
