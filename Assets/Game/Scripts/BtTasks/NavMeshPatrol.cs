using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class NavMeshPatrol : ActionTask<NavMeshMove>
{
    [RequiredField] public BBParameter<PointGetter> pointsGetter;
    [RequiredField] public BBParameter<float> moveSpeed;
    private Transform _point;

    protected override void OnExecute()
    {
        _point = pointsGetter.value.GetPoint();
        agent.SetMoveDestination(_point.position, moveSpeed.value);
    }

    protected override void OnUpdate()
    {
        if (agent.IsClose == false) return;
        EndAction(true);
    }

    protected override void OnStop() => pointsGetter.value.ReturnPoint(_point);
}