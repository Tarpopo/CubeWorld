using System;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class SpendResourceTutorial : BaseTutorial
{
    [SerializeField] private ResourceType _resourceType;
    private IResourceContainer _resourceContainer;

    public override void SetTutorialParameters() => _resourceContainer = Object.FindObjectOfType<Player>();

    public override void EnableTutorial() => _resourceContainer.OnRemoveResource += CheckComplete;

    public override void DisableTutorial() => _resourceContainer.OnRemoveResource -= CheckComplete;

    private void CheckComplete(ResourceType resourceType)
    {
        if (_resourceType.Equals(resourceType)) CompleteTutorial();
    }
}