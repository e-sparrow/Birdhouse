using UnityEngine;

namespace ESparrow.Utils.UI.Screens.Interfaces
{
    public interface IMovableScreen : IScreen
    {
        void Move(Vector2 delta);
    }
}