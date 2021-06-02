using System;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.UI.ViewControllers
{
    [AddComponentMenu("ESparrow/Utils/UI/ViewControllers/ViewControllersBinder")]
    public class ViewControllersBinder : MonoBehaviour
    {
        [SerializeField] private List<KeyViewControllerPair> keyControllerPairs;

        private void Update()
        {
            foreach (var pair in keyControllerPairs)
            {
                if (Input.GetKeyDown(pair.key))
                {
                    pair.viewController.Toggle();
                }
            }
        }

        [Serializable]
        private struct KeyViewControllerPair
        {
            public KeyCode key;
            public ViewControllerBase viewController;
        }
    }
}
