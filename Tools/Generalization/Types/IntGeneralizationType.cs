using System;
using Birdhouse.Tools.Generalization.Types.Enums;
using Birdhouse.Tools.Generalization.Types.Interfaces;

namespace Birdhouse.Tools.Generalization.Types
{
    public class IntGeneralizationType : IGeneralizationType
    {
        public Type Type => typeof(decimal);
        public EGeneralizationType GeneralizationType => EGeneralizationType.Decimal;
    }
}
