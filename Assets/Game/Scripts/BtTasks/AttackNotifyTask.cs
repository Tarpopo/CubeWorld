using NodeCanvas.Framework;
using ParadoxNotion.Design;

public class AttackNotifyTask : ActionTask
{
    [RequiredField] public BBParameter<AttackNotifier> notifyer;
    [RequiredField] public BBParameter<NotifierData> notifyerData;

    protected override string info => $"AttackNotify(Delay {GetDelay()})";

    private float GetDelay() => notifyerData.value == null ? 0.0f : notifyerData.value.NotifyDelay;

    protected override void OnUpdate()
    {
        if (elapsedTime < notifyer.value.NotifyDelay) return;
        EndAction(true);
        notifyer.value.Notify();
    }
}