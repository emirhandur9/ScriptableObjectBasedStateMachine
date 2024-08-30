using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    [CreateAssetMenu(menuName = "AI States/Fleeing")]
    public class FleeingState : StateBase<Agent>
    {
        public float fleeSpeed = 5f;

        public override void EnterState(Agent agent)
        {
            Debug.Log("Entering Fleeing State");
        }

        public override void UpdateState(Agent agent)
        {
        }

        public override void ExitState(Agent agent)
        {
            Debug.Log("Exiting Fleeing State");
        }
    }
}
