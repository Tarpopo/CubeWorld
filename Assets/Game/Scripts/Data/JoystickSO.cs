using UnityEngine;

[CreateAssetMenu(menuName = "Data/" + nameof(JoystickSO))]
public class JoystickSO : ScriptableObject
{
    public float RadiusInsideCircle => radiusInsideCircle;
    [SerializeField] private float radiusInsideCircle = 50;
}