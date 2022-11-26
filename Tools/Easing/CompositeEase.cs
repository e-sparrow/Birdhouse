using System.Collections.Generic;
using System.Linq;
using Birdhouse.Tools.Easing.Interfaces;

namespace Birdhouse.Tools.Easing
{
    public class CompositeEase : ICompositeEase
    {
        protected CompositeEase(IEnumerable<IEase> eases = null)
        {
            eases ??= Enumerable.Empty<IEase>();

            var pieces = eases.Select(CreatePiece);
            _pieces = new Queue<EasePiece>(pieces);

            EasePiece CreatePiece(IEase ease)
            {
                var piece = new EasePiece(ease);
                return piece;
            }
        }

        private readonly Queue<EasePiece> _pieces;
        
        public float Evaluate(float progress)
        {
            var current = 0f;
            
            var length = Length;
            var real = length * progress;
            foreach (var piece in _pieces)
            {
                if (current + piece.Length >= real)
                {
                    var delta = real - current;
                    var ratio = delta / piece.Length;
                    
                    var result = piece.Ease.Evaluate(ratio);
                    return result;
                }
                
                current += piece.Length;
            }

            var last = _pieces.Peek();

            var lastValue = last.Ease.Evaluate(1);
            return lastValue;
        }

        public void Enqueue(IEase ease, float length)
        {
            var piece = new EasePiece(ease, length);
            _pieces.Enqueue(piece);
        }

        public void EnqueueVoid(float length)
        {
            IEase ease;
            if (_pieces.TryPeek(out var last))
            {
                var lastValue = last.Ease.Evaluate(1);
                ease = EasingHelper.Easings.GetFlatEase(lastValue);
            }
            else
            {
                ease = EasingHelper.Easings.GetFlatEase(0);
            }
            
            var piece = new EasePiece(ease, length);
            _pieces.Enqueue(piece);
        }

        public IEase Dequeue()
        {
            var piece = _pieces.Dequeue();

            var result = piece.Ease;
            return result;
        }

        private float CalculateLength()
        {
            var result = _pieces.Sum(value => value.Length);
            return result;
        }

        public float Length => CalculateLength();

        private readonly struct EasePiece
        {
            public EasePiece(IEase ease, float length = 1f)
            {
                Ease = ease;
                Length = length;
            }

            public IEase Ease
            {
                get;
            }

            public float Length
            {
                get;
            }
        }
    }
}