namespace ESparrow.Utils.Identification.Routine
{
    public class StringUnifier : UnifierBase<string>
    {
        public override string Unify(string value)
        {
            return value.ToUpper();
        }
    }
}