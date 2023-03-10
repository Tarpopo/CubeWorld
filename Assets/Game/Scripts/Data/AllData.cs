using UnityEngine;

[CreateAssetMenu(menuName = "Data/AllData")]
public class AllData : ScriptableObject
{
    [SerializeField] private ResourceFactoryData[] _factoriesData;
    [SerializeField] private ResourcePointData[] _resourcePointsData;
    [SerializeField] private PlayerData _playerData;
}