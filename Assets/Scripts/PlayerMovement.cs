using Mirror;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    private Camera mainCamera;

    #region Server
    [Command]
    private void CmdMove(Vector3 position)
    {
        bool MovementCondition = NavMesh.SamplePosition(
            position,
            out NavMeshHit hit,
            1f,
            NavMesh.AllAreas
        );

        if (!MovementCondition)
        {
            return;
        }

        agent.SetDestination(hit.position);
    }
    #endregion
    #region Client
    public override void OnStartAuthority()
    {
        //base.OnStartAuthority();
        mainCamera = Camera.main;
    }

    [ClientCallback]
    void Update()
    {
        if (!hasAuthority) { return; }
        if (!Input.GetMouseButtonDown(1)) { return; }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) { return; }

        CmdMove(hit.point);
    }
    #endregion
}
