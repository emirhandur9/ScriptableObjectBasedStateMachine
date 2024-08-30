using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    [CreateAssetMenu(menuName = "AI Transitions/Health Below Threshold")]
    public class HealthBelowThresholdTransition : TransitionCondition<Agent>
    {
        public float healthThreshold;

        public override bool ShouldTransition(Agent agent)
        {
            return agent.Health <= healthThreshold;
        }
    }
}
