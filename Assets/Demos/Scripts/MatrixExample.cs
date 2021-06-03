using UnityEngine;
using ESparrow.Utils.Extensions;

namespace Demos
{
    [AddComponentMenu("Demos/MatrixExample")]
    public class MatrixExample : MonoBehaviour
    {
        private void Update()
        {
            var matrix = transform.GetTRSMatrix();
            transform.SetTRSMatrix(matrix);
                
            Debug.Log(transform.position == matrix.GetPosition() && transform.rotation == matrix.GetRotation() && transform.localScale == matrix.GetScale());
        }
    }
}
