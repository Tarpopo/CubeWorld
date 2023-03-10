using UnityEngine;

public class TransformRotate : MonoBehaviour, IRotateMove
{
    [SerializeField] private Transform _transform;
    private bool _active;

    public void Rotate(Quaternion quaternion)
    {
        if (_active) _transform.rotation = quaternion;
    }

    private void OnEnable() => _active = true;

    private void OnDisable() => _active = false;
}