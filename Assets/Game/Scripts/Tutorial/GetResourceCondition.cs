using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class GetResourceCondition : BaseTutorial
{
    [SerializeField] private ResourceType _resourceType;
    private ICollector<ResourceType> _resourceCollector;

    public override void SetTutorialParameters() => _resourceCollector =
        Object.FindObjectsOfType<ResourceCollector>().OfType<ICollector<ResourceType>>().First();

    public override void EnableTutorial() => _resourceCollector.OnCollect += CheckComplete;

    public override void DisableTutorial() => _resourceCollector.OnCollect -= CheckComplete;

    private void CheckComplete(ResourceType resourceType)
    {
        if (_resourceType.Equals(resourceType)) CompleteTutorial();
    }
}