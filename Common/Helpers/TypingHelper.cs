namespace Birdhouse.Common.Helpers
{
    public static class TypingHelper
    {
        public static object[] Args<T>(T arg)
        {
            var result = new object[]
            {
                arg
            };
            
            return result;
        }

        public static object[] Args<T1, T2>(T1 arg1, T2 arg2)
        {
            var result = new object[]
            {
                arg1, arg2
            };
            
            return result;
        }

        public static object[] Args<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
        {
            var result = new object[]
            {
                arg1, arg2, arg3
            };
            
            return result;
        }

        public static object[] Args<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var result = new object[]
            {
                arg1, arg2, arg3, arg4
            };
            
            return result;
        }

        public static object[] Args<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var result = new object[]
            {
                arg1, arg2, arg3, arg4, arg5
            };
            
            return result;
        }
    }
}