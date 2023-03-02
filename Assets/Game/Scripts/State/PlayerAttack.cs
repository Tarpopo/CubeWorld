using FSM;

public class PlayerAttack : State
{
    private AnimationComponent _animationComponent;
    private TriggerChecker<IResource> _resourceChecker;

    public PlayerAttack(StateMachine stateMachine, AnimationComponent animationComponent,
        TriggerChecker<IResource> resourceChecker) : base(stateMachine)
    {
        _resourceChecker = resourceChecker;
        _animationComponent = animationComponent;
    }

    public override void Enter()
    {
        switch (_resourceChecker.Elements[0].ResourceType)
        {
            case ResourceType.Wood:
                _animationComponent.PlayAnimation(UnitAnimations.AxeAttack);

                break;
            case ResourceType.Metal:
                _animationComponent.PlayAnimation(UnitAnimations.PickAttack);

                break;
            case ResourceType.Kristal:
                _animationComponent.PlayAnimation(UnitAnimations.PickAttack);
                break;
        }
    }
}