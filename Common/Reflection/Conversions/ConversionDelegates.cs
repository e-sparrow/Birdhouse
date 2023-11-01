namespace Birdhouse.Common.Reflection.Conversions
{
    public delegate object Conversion(object value);
    
    public delegate TTo SpecificConversion<in TFrom, out TTo>(TFrom value);
    public delegate TTo ParametrizedConversion<in TFrom, out TTo, in TParameter>(TFrom value, TParameter parameter);
}