using System;
using UnityEngine;

namespace Birdhouse.Hypotheses.Processors
{
    public class ProcessorHypothesis 
        : MonoBehaviour
    {
        [SerializeField] private int current;
        
        private event Func<int, int> OnProcess = value => value;

        private int IncrementProcess(int source)
        {
            var result = source + 1;
            Debug.Log($"Incrementing value... Source: {source}. Result: {result}");
            return result;
        }
        
        private int MultiplyProcess(int source)
        {
            var result = source * 2;
            Debug.Log($"Multiplying value... Source: {source}. Result: {result}");
            return result;
        }
        
        private int PowProcess(int source)
        {
            var result = source * source;
            Debug.Log($"Exponentiation value... Source: {source}. Result: {result}");
            return result;
        }
        
        private int DivideProcess(int source)
        {
            var result = source / 3;
            Debug.Log($"Dividing value... Source: {source}. Result: {result}");
            return result;
        }

        [ContextMenu("Process")]
        private void Process()
        {
            current = OnProcess.Invoke(current);
        }

        private void OnEnable()
        {
            OnProcess += IncrementProcess;
            OnProcess += MultiplyProcess;
            OnProcess += PowProcess;
            OnProcess += DivideProcess;
        }

        private void OnDisable()
        {
            OnProcess -= IncrementProcess;
            OnProcess -= MultiplyProcess;
            OnProcess -= PowProcess;
            OnProcess -= DivideProcess;
        }
    }
}
