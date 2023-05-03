using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class NavMeshPointMove : ActionTask<NavMeshMove>
{
    [RequiredField] public BBParameter<Vector3> endPoint;
    [RequiredField] public BBParameter<float> moveSpeed;
    [RequiredField] public BBParameter<float> stopDistance;

    private void MoveToPoint() => agent.SetMoveDestination(endPoint.value, moveSpeed.value);

    protected override void OnExecute() => MoveToPoint();

    protected override void OnUpdate()
    {
        if (agent.Close(stopDistance.value) == false)
        {
            if (endPoint.value.Equals(agent.EndPathPosition) == false) MoveToPoint();
            return;
        }

        EndAction(true);
    }

    protected override void OnStop() => agent.StopMove();
}