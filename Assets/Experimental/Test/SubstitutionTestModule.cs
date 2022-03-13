using System;
using System.Collections.Generic;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Tools.Substitution;
using ESparrow.Utils.Tools.Substitution.Enums;
using ESparrow.Utils.Tools.Substitution.Methods;
using ESparrow.Utils.Tools.Substitution.Operators.Adapters;
using UnityEngine;

namespace ESparrow.Utils.Test
{
    [Serializable]
    public class SubstitutionTestModule : TestModuleBase
    {
        [SerializeField] private bool capacious;
        [SerializeField] private int capacity;
        [SerializeField] private ESubstitutionType substitutionType;
        
        [SerializeField] private List<int> list;
        [SerializeField] private int next;
        
        public override void Test()
        {
            var substitutionOperator = list.AsSubstitutionOperator();
            var method = SubstitutionHelper.CreateSubstitutionMethod(substitutionOperator, substitutionType);
            var capaciousMethod = SubstitutionHelper.CreateCapaciousSubstitutionMethod(capacity, substitutionOperator, substitutionType);
            var controller = new SubstitutionController<int>(capacious ? capaciousMethod : method);
            
            controller.Add(next);
        }
    }
}