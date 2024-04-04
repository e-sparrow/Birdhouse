namespace Birdhouse.Tools.Colors
{
    public struct HSV
    {
        public HSV(float hue = 0f, float saturation = 0f, float value = 0f)
        {
            Hue = hue;
            Saturation = saturation;
            Value = value;
        }
        
        public float Hue;
        public double Saturation;
        public double Value;
    }
}