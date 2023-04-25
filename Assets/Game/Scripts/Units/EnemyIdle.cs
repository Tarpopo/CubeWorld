using FSM;

public class EnemyIdle : State
{
    private readonly Timer _timer;
    private float _idleTime;

    public EnemyIdle(StateMachine stateMachine, float idleTime) : base(stateMachine)
    {
        _timer = new Timer();
        _idleTime = idleTime;
    }

    public override void Enter() => _timer.StartTimer(_idleTime, () => Machine.ChangeState<EnemyMove>());

    public override void LogicUpdate() => _timer.UpdateTimer();
}