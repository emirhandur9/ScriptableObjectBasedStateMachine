using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EmirhanDur.AISystem
{
    [CreateAssetMenu(menuName = "AI States/Walking")]
    public class WalkingState : StateBase<Agent>
    {
        public float walkSpeed = 2f;
        public float walkRadius = 10f;
        public string animName;

        public override void EnterState(Agent agent)
        {
            Debug.Log("Entering Walking State");
            agent.navMeshAgent.speed = walkSpeed;
            agent.animator.SetBool(animName, true);
            MoveToRandomPosition(agent);
        }

        public override void UpdateState(Agent agent)
        {
            if (agent.navMeshAgent.remainingDistance <= agent.navMeshAgent.stoppingDistance)
            {
                MoveToRandomPosition(agent);
            }
        }

        public override void ExitState(Agent agent)
        {
            agent.animator.SetBool(animName, false);
            Debug.Log("Exiting Walking State");
        }

        private void MoveToRandomPosition(Agent agent)
        {
            Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
            randomDirection += agent.transform.position;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1))
            {
                Vector3 finalPosition = hit.position;
                agent.navMeshAgent.SetDestination(finalPosition);
                agent.navMeshAgent.speed = walkSpeed;
            }
        }
    }
}
