using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    public abstract class TransitionCondition<T> : ScriptableObject
    {
        public abstract bool ShouldTransition(T context);
    }
}
