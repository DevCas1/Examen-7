namespace Sjouke.CodeArchitecture.Variables
{
    [System.Serializable]
    public class IntReference
    {
        public bool UseConstant = true;
        public int ConstantValue;
        public IntVariable Variable;

        public int Value => UseConstant ? ConstantValue : Variable.Value;
    }
}