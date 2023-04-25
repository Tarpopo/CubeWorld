using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointGetter : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    private HashSet<Transform> _freePoints;

    private void Awake() => _freePoints = new HashSet<Transform>(_points);

    public Transform GetPoint()
    {
        var point = _freePoints.ElementAt(Random.Range(0, _freePoints.Count));
        _freePoints.Remove(point);
        return point;
    }

    public void ReturnPoint(Transform point) => _freePoints.Add(point);
}