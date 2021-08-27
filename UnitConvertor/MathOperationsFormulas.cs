namespace UnitConvertor
{
    public class MathOperationsFormulas
    {
        public decimal Add(decimal number, decimal koef) { return number + koef; }
        public decimal Subtract(decimal number, decimal koef) { return number - koef; }
        public decimal CtoF(decimal number) { return ((number*9)/5) + 32; }
        public decimal FtoC(decimal number) { return ((number - 32) / 1.8m); }
    }
}
