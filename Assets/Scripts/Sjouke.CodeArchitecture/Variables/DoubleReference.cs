namespace Sjouke.CodeArchitecture.Variables
{
    [System.Serializable]
    public class DoubleReference
    {
        public bool UseConstant = true;
        public double ConstantValue;
        public DoubleVariable Variable;

        public double Value => UseConstant ? ConstantValue : Variable.Value;
    }
}