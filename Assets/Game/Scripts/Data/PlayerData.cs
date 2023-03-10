using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PLayerData")]
[InlineEditor]
public class PlayerData : ScriptableObject
{
    public float MoveSpeed = 0.1f;
    public float ResourceTakeDelay = 0.25f;
    public float ResourceCheckRadius = 2;
}