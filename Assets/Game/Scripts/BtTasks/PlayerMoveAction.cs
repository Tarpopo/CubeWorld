using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class PlayerMoveAction : ActionTask
{
    [RequiredField] public BBParameter<NavMeshMove> navMeshMove;
    [RequiredField] public BBParameter<Transform> transform;
    [RequiredField] public BBParameter<float> moveSpeed;
    [RequiredField] public BBParameter<Vector2> moveDirection;

    protected override void OnUpdate()
    {
        navMeshMove.value.Move(transform.value.position + transform.value.forward * (moveSpeed.value * Time.deltaTime),
            moveSpeed.value);
        var joystickDirection = Quaternion.AngleAxis(Helpers.Camera.transform.rotation.eulerAngles.y, Vector3.up) *
                                new Vector3(moveDirection.value.x, 0, moveDirection.value.y);
        transform.value.forward = joystickDirection.normalized;
    }

    protected override void OnStop() => navMeshMove.value.StopMove();
}