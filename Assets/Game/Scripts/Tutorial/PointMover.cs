using UnityEngine;

public class PointMover : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _followPoint;
    [SerializeField] private Transform _icon;
    [SerializeField] private float _rotationSpeed;

    public void SetFollowPoint(Transform point) => _followPoint = point;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        if (_playerTransform == null || _followPoint == null) return;
        var playerToEnemy = _followPoint.position - _playerTransform.position;
        Ray ray = new Ray(_playerTransform.position, playerToEnemy);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        var minDistance = Mathf.Infinity;
        var planeIndex = 0;
        for (int i = 0; i < 4; i++)
        {
            if (planes[i].Raycast(ray, out var distance) == false) continue;
            if (distance < minDistance)
            {
                minDistance = distance;
                planeIndex = i;
            }
        }

        minDistance = Mathf.Clamp(minDistance, 0, playerToEnemy.magnitude);
        var worldPosition = ray.GetPoint(minDistance);
        _icon.position = _camera.WorldToScreenPoint(worldPosition);
        _icon.rotation = Quaternion.RotateTowards(_icon.rotation, GetIconRotation(planeIndex), _rotationSpeed);
    }

    private Quaternion GetIconRotation(int planeIndex)
    {
        return planeIndex switch
        {
            0 => Quaternion.Euler(0f, 0f, 90f),
            1 => Quaternion.Euler(0f, 0f, -90f),
            2 => Quaternion.Euler(0f, 0f, 180f),
            3 => Quaternion.Euler(0f, 0f, 0f),
            _ => Quaternion.identity
        };
    }
}