using NodeCanvas.Framework;
using ParadoxNotion.Design;

public class AttackTask : ActionTask
{
    [RequiredField] public BBParameter<IAttack> Attack;

    protected override void OnExecute() => Attack.value.StartAttack();

    protected override void OnUpdate()
    {
        if (Attack.value.Attacking) return;
        EndAction(true);
    }

    protected override void OnStop() => Attack.value.StopAttack();
}