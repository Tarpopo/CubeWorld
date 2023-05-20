using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DamagableViewChecker : MonoBehaviour
{
    public Vector3 PointPosition => _damageableChecker.LastItemPoint;

    public bool SeeDamageable => _damageableChecker.HaveElements && Vector3.Angle(
        _damageableChecker.LastItemPoint - transform.position,
        transform.forward) <= _data.ViewAngle / 2;

    [SerializeField] private DamagableViewData _data;
    [SerializeField] private TagTriggerChecker<IDamageable> _damageableChecker;
    private SphereCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = _data.ViewDistance;
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) => _damageableChecker.OnTriggerEnter(other);

    private void OnTriggerExit(Collider other) => _damageableChecker.OnTriggerExit(other);

    private void OnDrawGizmosSelected()
    {
        if (_data == null) return;
        Handles.color = _data.ViewColor;
        Handles.DrawSolidArc(transform.position, Vector3.up,
            transform.forward.RotateAroundAxis(-_data.ViewAngle / 2, Vector3.up), _data.ViewAngle, _data.ViewDistance);
    }
}