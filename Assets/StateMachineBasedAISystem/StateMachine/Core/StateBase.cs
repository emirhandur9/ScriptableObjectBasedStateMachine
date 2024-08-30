using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    public abstract class StateBase<T> : ScriptableObject
    {
        public virtual void EnterState(T context) { }
        public virtual void UpdateState(T context) { }
        public virtual void ExitState(T context) { }
    }
}
