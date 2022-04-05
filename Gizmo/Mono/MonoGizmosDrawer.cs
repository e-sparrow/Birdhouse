using ESparrow.Utils.Gizmo.Enums;
using ESparrow.Utils.Nodes.Splitters;
using ESparrow.Utils.Nodes.Splitters.Interfaces;
using ESparrow.Utils.Patterns.Listening.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Gizmo.Mono
{
    [AddComponentMenu("Gizmo/Mono/Drawer")]
    public class MonoGizmosDrawer : MonoBehaviour
    {
        public readonly ISplitter<IGizmo> Splitter = new Splitter<IGizmo>();

        private void DrawDefault(IGizmo gizmo)
        {
            if (!gizmo.IsActive) return;
            if (gizmo.Type != EGizmoDrawType.Default) return;
            
            gizmo.Draw();
        }

        private void DrawSelected(IGizmo gizmo)
        {
            if (!gizmo.IsActive) return;
            if (gizmo.Type != EGizmoDrawType.Selected) return;
            
            gizmo.Draw();
        }
        
        private void OnDrawGizmos()
        {
            Splitter.Fire(DrawDefault);
        }

        private void OnDrawGizmosSelected()
        {
            Splitter.Fire(DrawSelected);
        }
    }
}