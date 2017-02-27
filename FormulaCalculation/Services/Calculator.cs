using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using FormulaCalculation.Interfaces;

namespace FormulaCalculation.Services
{
    public class Calculator : ICalculator
    {
        public Calculator()
        {
        }

        public string Calculate(dynamic op, dynamic parm1, dynamic parm2)
        {
            double ans = 0.00;
            if (op != null && IsNumeric(parm1) && IsNumeric(parm2))
            {
                switch ((string) op)
                {
                    case "+":
                    {
                        ans = parm1 + parm2;
                        break;
                    }

                    case "-":
                    {
                        ans = parm1 - parm2;
                        break;
                    }

                    case "*":
                    {
                        ans = parm1 * parm2;
                        break;
                    }

                    case "/":
                    {
                        ans = Math.Round((double)parm1 / (double)parm2,2);
                        break;
                    }
                    default:
                        return "Operation not accepted";
                }
                return $"{parm1} {op} {parm2} = {ans}";
            }

            return "Parm is not a Number";
        }

        public static bool IsNumeric(object expression)
        {
            if (expression == null)
                return false;

            double number;
            return Double.TryParse(Convert.ToString(expression, CultureInfo.InvariantCulture), System.Globalization.NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
        }
    }
}