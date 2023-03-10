using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;

public interface IMoveTransformTween
{
    Tween GetMoveTween(Vector3 endValue, float duration);

    Tween GetLocalMoveTween(Vector3 endValue, float duration);

    Tween GetAxisMoveTween(Axis axis, float value, float duration);

    Tween GetLocalAxisMoveTween(Axis axis, float value, float duration);

    public void SetPosition(Vector3 value);

    public void SetAxisPosition(Axis axis, float value);

    public void SetLocalAxisPosition(Axis axis, float value);

    public void SetLocalPosition(Vector3 value);
}