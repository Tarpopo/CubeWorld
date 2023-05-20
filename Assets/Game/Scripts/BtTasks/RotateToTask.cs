using DG.Tweening;
using NodeCanvas.Framework;
using UnityEngine;

public class RotateToTask : ActionTask<Transform>
{
    public BBParameter<Vector3> _pointPosition;
    private Vector3 _position;

    protected override void OnExecute()
    {
        _position = _pointPosition.value;
        agent.DOLookAt(_position, 0.5f, AxisConstraint.Y).onComplete = Complete;
    }

    private void Complete() => EndAction(true);
}