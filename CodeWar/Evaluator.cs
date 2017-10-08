using System;
using System.Data;
using System.Globalization;


namespace CodeWar
{
    public class Evaluator
        {
        public double Evaluate(string expression)
            {
            if (string.IsNullOrWhiteSpace(expression)) return 0.0;
            var dt = new DataTable();
            var v = dt.Compute(expression, "");
            return Convert.ToDouble(v.ToString(),new NumberFormatInfo()
                {
                NumberDecimalDigits = 6
                });
            }
        }
}
