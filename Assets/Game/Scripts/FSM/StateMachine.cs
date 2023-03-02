using System.Collections.Generic;
using System.Linq;

namespace FSM
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }
        private readonly List<State> _states;

        public StateMachine()
        {
            _states = new List<State>();
        }

        public void Initialize<V>() where V : State
        {
            CurrentState = _states.FirstOrDefault(elem => elem is V);
            CurrentState.Enter();
        }

        public void AddState(State state)
        {
            _states.Add(state);
        }

        public void ChangeState<V>() where V : State
        {
            if (CurrentState.IsStatePlay() || CurrentState is V) return;
            var newState = _states.FirstOrDefault(elem => elem is V);
            CurrentState.Exit();
            CurrentState = newState;
            newState.Enter();
        }

        public void ChangeStateImmediately<V>() where V : State
        {
            var newState = _states.FirstOrDefault(elem => elem is V);
            CurrentState.Exit();
            CurrentState = newState;
            newState.Enter();
        }
    }
}