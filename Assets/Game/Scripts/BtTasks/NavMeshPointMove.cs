using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class NavMeshPointMove : ActionTask
{
    [RequiredField] public BBParameter<NavMeshMove> navMeshMove;
    [RequiredField] public BBParameter<Vector3> endPoint;
    [RequiredField] public BBParameter<float> moveSpeed;
    [RequiredField] public BBParameter<float> stopDistance;

    private void MoveToPoint() => navMeshMove.value.SetMoveDestination(endPoint.value, moveSpeed.value);

    protected override void OnExecute() => MoveToPoint();

    protected override void OnUpdate()
    {
        if (navMeshMove.value.Close(stopDistance.value) == false)
        {
            if (endPoint.value.Equals(navMeshMove.value.EndPathPosition) == false) MoveToPoint();
            return;
        }

        EndAction(true);
    }

    protected override void OnStop() => navMeshMove.value.StopMove();
}