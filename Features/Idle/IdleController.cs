using UnityEngine;

namespace Birdhouse.Mechanics.Idle
{
    public class IdleController : IdleControllerBase
    {
        public IdleController()
        {
            
        }

        protected override void Reward(float seconds)
        {
            Debug.Log($"Your reward: {seconds}");
        }
    }
}