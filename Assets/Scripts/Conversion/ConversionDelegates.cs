namespace ESparrow.Utils.Conversion
{
    public delegate TTo Conversion<in TFrom, out TTo>(TFrom value);

    public delegate TTo ParametrizedConversion<in TFrom, out TTo, in TParameter>(TFrom value, TParameter parameter);
}