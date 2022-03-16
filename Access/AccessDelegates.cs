namespace ESparrow.Utils.Access
{
    public delegate T Getter<out T>();
    public delegate T Getter<out T, in TParameter>(TParameter parameter);
    public delegate T Getter<out T, in TParameter1, in TParameter2>(TParameter1 parameter1, TParameter2 parameter2);
    public delegate T Getter<out T, in TParameter1, in TParameter2, in TParameter3>(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3);

    public delegate bool ConditionalGetter<T>(out T result);
    public delegate bool ConditionalGetter<T, in TParameter>(TParameter parameter, out T result);
    public delegate bool ConditionalGetter<T, in TParameter1, in TParameter2>(TParameter1 parameter1, TParameter2  parameter2, out T result);
    public delegate bool ConditionalGetter<T, in TParameter1, in TParameter2, in TParameter3>(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3, out T result);
    
    public delegate void Setter<in T>(T value);
}
