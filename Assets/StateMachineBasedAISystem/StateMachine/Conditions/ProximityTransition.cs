using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    [CreateAssetMenu(menuName = "AI Transitions/Proximity")]
    public class ProximityTransition : TransitionCondition<Agent>
    {
        public float detectionRange;

        public override bool ShouldTransition(Agent agent)
        {
            float distance = Vector3.Distance(agent.transform.position, Camera.main.transform.position);
            return distance <= detectionRange;
        }
    }
}
