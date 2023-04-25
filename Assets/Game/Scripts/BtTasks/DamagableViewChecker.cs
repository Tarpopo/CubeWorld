using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class DamagableViewChecker : MonoBehaviour
{
    public Vector3 PointPosition => _damageableChecker.LastItemPoint;
    public bool SeeDamageable => _damageableChecker.HaveElements && Vector3.Angle(
        _damageableChecker.LastItemPoint - transform.position,
        transform.forward) <= _viewAngle / 2;

    [SerializeField] private Color _viewColor;
    [SerializeField] private float _viewAngle;
    [SerializeField] private float _viewDistance;
    [SerializeField] private TagTriggerChecker<IDamageable> _damageableChecker;

    private void OnTriggerEnter(Collider other) => _damageableChecker.OnTriggerEnter(other);

    private void OnTriggerExit(Collider other) => _damageableChecker.OnTriggerExit(other);

    private void OnDrawGizmosSelected()
    {
        Handles.color = _viewColor;
        Handles.DrawSolidArc(transform.position, Vector3.up,
            transform.forward.RotateAroundAxis(-_viewAngle / 2, Vector3.up), _viewAngle, _viewDistance);
    }
}