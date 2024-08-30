using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    [CreateAssetMenu(menuName = "AI Transitions/Target In Sight")]
    public class TargetInSightTransition : TransitionCondition<Agent>
    {
        public float viewAngle;
        public float viewDistance;

        public override bool ShouldTransition(Agent agent)
        {
            var target = Player.Instance.transform;

            Vector3 directionToTarget = (target.position - agent.transform.position).normalized;
            float angle = Vector3.Angle(agent.transform.forward, directionToTarget);
            return angle <= viewAngle / 2;
        }
    }
    
}
