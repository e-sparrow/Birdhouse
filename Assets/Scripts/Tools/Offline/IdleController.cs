using UnityEngine;

namespace ESparrow.Utils.Tools.Idle
{
    public class IdleController : IdleControllerBase
    {
        public IdleController(float rewardPerSecond) : base(rewardPerSecond)
        {
        }

        protected override void Reward(float reward)
        {
            Debug.Log($"Your reward: {reward}");
        }
    }
}