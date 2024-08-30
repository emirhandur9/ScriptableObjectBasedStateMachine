using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    [CreateAssetMenu(menuName = "AI Transitions/Wait For Seconds")]
    public class WaitForSecondsTransition : TransitionCondition<Agent>
    {
        public float waitTime;
        private float startTime;

        public override bool ShouldTransition(Agent agent)
        {
            if (startTime == 0)
                startTime = Time.time;

            if(Time.time - startTime >= waitTime)
            {
                startTime = 0;
                return true;
            }
            return false;
        }
    }
}
