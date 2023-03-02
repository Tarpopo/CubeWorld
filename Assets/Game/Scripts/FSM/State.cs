namespace FSM
{
    public abstract class State
    {
        protected readonly StateMachine Machine;

        protected State(StateMachine stateMachine)
        {
            Machine = stateMachine;
        }

        public virtual bool IsStatePlay()
        {
            return false;
        }

        public virtual void Enter()
        {
        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }
    }
}