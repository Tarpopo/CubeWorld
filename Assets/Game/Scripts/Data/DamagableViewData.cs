using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/" + nameof(DamagableViewData))]
[InlineEditor]
public class DamagableViewData : ScriptableObject
{
    public Color ViewColor => _viewColor;
    public float ViewAngle => _viewAngle;
    public float ViewDistance => _viewDistance;
    [SerializeField] private Color _viewColor;
    [SerializeField] private float _viewAngle;
    [SerializeField] private float _viewDistance;
}