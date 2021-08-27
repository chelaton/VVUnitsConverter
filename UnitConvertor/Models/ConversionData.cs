namespace UnitConvertor.Models
{
    public class ConversionData
    {
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public MathOperations MathOperation { get; set; }
        public decimal Koeficient { get; set; }
    }
}
