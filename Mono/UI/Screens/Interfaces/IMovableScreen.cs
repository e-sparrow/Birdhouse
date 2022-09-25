using UnityEngine;

namespace Birdhouse.Mono.UI.Screens.Interfaces
{
    public interface IMovableScreen : IScreen
    {
        void Move(Vector2 delta);
    }
}