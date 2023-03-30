﻿using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Exceptions;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Reflection.Operators.Enums;
using Birdhouse.Tools.Conditions.Enums;
using Birdhouse.Tools.Optimization.Memoization;

namespace Birdhouse.Common.Helpers
{
    public static class ConditionHelper
    {
        private static readonly IDictionary<EConditionType, EBinaryOperatorType> ConditionOperators
            = new Dictionary<EConditionType, EBinaryOperatorType>()
        {
            [EConditionType.Less] = EBinaryOperatorType.LessThan,
            [EConditionType.LessOrEqual] = EBinaryOperatorType.LessThanOrEqual,
            [EConditionType.Equal] = EBinaryOperatorType.Equality,
            [EConditionType.MoreOrEqual] = EBinaryOperatorType.GreaterThanOrEqual,
            [EConditionType.More] = EBinaryOperatorType.GreaterThan,
            [EConditionType.NotEqual] = EBinaryOperatorType.Inequality
        };

        public static bool Check<T>(T origin, T value, EConditionType type)
        {
            var buffer = MemoizationHelper.Container.GetOrCreateBuffer(typeof(ConditionHelper));
            var result = buffer.GetOrCreate(origin, value, type, CheckInternal);
            
            return result;
        }

        private static bool CheckInternal<T>(T origin, T value, EConditionType type)
        {
            var operatorType = ConditionOperators[type];
            var operators = ReflectionHelper.OperatorHelper.GetBinaryOperatorInfos(typeof(T), operatorType);
            var target = operators.FirstOrDefault();

            if (target == default)
            {
                throw new WtfException($"It's no suitable comparison operators in type {typeof(T)}");
            }

            return (bool) target.Invoke(value, origin);
        }
    }
}