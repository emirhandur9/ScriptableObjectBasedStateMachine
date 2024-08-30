using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    [CreateAssetMenu(menuName = "AI Transitions/Reached Destination")]
    public class ReachedDestinationTransition : TransitionCondition<Agent>
    {
        public Transform destination;

        public override bool ShouldTransition(Agent agent)
        {
            float distance = Vector3.Distance(agent.transform.position, destination.position);
            return distance <= 0.1f; // Tolerans
        }
    }
}
