using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class NavMeshPointMove : ActionTask<NavMeshMove>
{
    [RequiredField] public BBParameter<Vector3> endPoint;
    [RequiredField] public BBParameter<float> moveSpeed;

    protected override void OnExecute() => agent.SetMoveDestination(endPoint.value, moveSpeed.value);

    protected override void OnUpdate()
    {
        if (agent.IsClose == false) return;
        EndAction(true);
    }

    protected override void OnStop() => agent.StopMove();
}