using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{

    public class StateMachine<T> : ScriptableObject
    {
         public StateBase<T> initialState;
        public StateBase<T> currentState;
        public StateBase<T> states;
        public List<StateTransition<T>> transitions = new List<StateTransition<T>>();

        public void Initialize(T context)
        {
            ChangeState(context, initialState);
        }

        public void UpdateState(T context)
        {
            currentState?.UpdateState(context);
            CheckTransitions(context);
        }

        public void ChangeState(T context, StateBase<T> newState)
        {
            if (currentState != null)
            {
                currentState.ExitState(context);
            }

            currentState = newState;

            if (currentState != null)
            {
                currentState.EnterState(context);
            }
        }

        public void CheckTransitions(T context)
        {
            foreach (var transition in transitions)
            {
                if ((transition.fromState == null || currentState == transition.fromState)
                    && transition.condition.ShouldTransition(context))
                {
                    ChangeState(context, transition.targetState);
                    return;
                }
            }
        }

    }
}
