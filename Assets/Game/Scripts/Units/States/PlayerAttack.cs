using FSM;

public class PlayerAttack : State
{
    private AnimationComponent _animationComponent;
    private TriggerChecker<IResourcePoint> _resourceChecker;

    public PlayerAttack(StateMachine stateMachine, AnimationComponent animationComponent,
        TriggerChecker<IResourcePoint> resourceChecker) : base(stateMachine)
    {
        _resourceChecker = resourceChecker;
        _animationComponent = animationComponent;
    }

    public override void Enter()
    {
        _animationComponent.PlayAnimation(_resourceChecker.First.ResourceType.Equals(ResourceType.Wood)
            ? UnitAnimations.AxeAttack
            : UnitAnimations.PickAttack);
    }
}