using UnityEngine;

public class TransformRotate : MonoBehaviour, IRotateMove
{
    [SerializeField] private Transform _transform;
    public void Rotate(Quaternion quaternion) => _transform.rotation = quaternion;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
}