using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    [System.Serializable]
    public class StateTransition<T>
    {
        public StateBase<T> fromState;
        public StateBase<T> targetState;
        public TransitionCondition<T> condition;
    }
}
