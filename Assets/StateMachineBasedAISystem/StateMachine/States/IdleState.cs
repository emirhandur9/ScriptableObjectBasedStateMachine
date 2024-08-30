using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    [CreateAssetMenu(menuName = "AI States/Idle")]
    public class IdleState : StateBase<Agent>
    {
        public override void EnterState(Agent agent)
        {
            Debug.Log("Entering Idle State");
            agent.navMeshAgent.speed = 0;
            agent.navMeshAgent.isStopped = true;

        }

        public override void UpdateState(Agent agent)
        {

        }

        public override void ExitState(Agent agent)
        {
            Debug.Log("Exiting Idle State");
            agent.navMeshAgent.isStopped = false;
        }
    }
}
