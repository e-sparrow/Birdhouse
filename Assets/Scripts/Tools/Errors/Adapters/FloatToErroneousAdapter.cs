namespace ESparrow.Utils.Tools.Errors.Adapters
{
    public class FloatToErroneousAdapter : ToErroneousAdapterBase<float>
    {
        public override float DefaultError => float.Epsilon;

        public FloatToErroneousAdapter(float value) : base(value)
        {

        }

        public override bool CompareWithError(float self, float other, float error)
        {
            throw new System.NotImplementedException();
        }
    }
}
