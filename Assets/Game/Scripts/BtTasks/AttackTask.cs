using NodeCanvas.Framework;
using ParadoxNotion.Design;

public class AttackTask : ActionTask
{
    [RequiredField] public BBParameter<IAttack> Attack;
    [RequiredField] public BBParameter<BaseAttackData> AttackData;
    protected override string info => nameof(AttackTask) + $"(Delay {GetDelay()})";
    private float GetDelay() => AttackData.value == null ? 0.0f : AttackData.value.AttackStartDelay;

    protected override void OnExecute() => Attack.value.StartAttack();

    protected override void OnUpdate()
    {
        if (Attack.value.Attacking) return;
        EndAction(true);
    }

    protected override void OnStop() => Attack.value.StopAttack();
}