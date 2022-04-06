namespace ESparrow.Utils.Helpers
{
    public static class TypingHelper
    {
        public static object[] Args<T>(T arg)
        {
            return new object[] { arg };
        }

        public static object[] Args<T1, T2>(T1 arg1, T2 arg2)
        {
            return new object[] { arg1, arg2 };
        }

        public static object[] Args<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
        {
            return new object[] { arg1, arg2, arg3 };
        }

        public static object[] Args<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return new object[] { arg1, arg2, arg3, arg4 };
        }

        public static object[] Args<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return new object[] { arg1, arg2, arg3, arg4, arg5 };
        }
    }
}