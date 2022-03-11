using System.Collections.Generic;

namespace ESparrow.Utils.CodeGen.Interfaces
{
    public interface ICodeBlock
    {
        ICodeBlock Put(ICodeBlock block);

        IEnumerable<IInstruction> Instructions
        {
            get;
        }
    }
}
