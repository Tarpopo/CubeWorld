using NodeCanvas.Framework;

public class AnimationAction : ActionTask<AnimationComponent>
{
    public UnitAnimations _animation;

    protected override string info => _animation + " Anim";

    protected override void OnExecute()
    {
        agent.PlayAnimation(_animation);
        EndAction(true);
    }
}