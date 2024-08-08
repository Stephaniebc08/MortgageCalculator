using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    public interface InterfaceMortgageCalculator
    {
        decimal CalculateMonthlyPayment(decimal principal, int termInMonths, decimal annualInterestRate);
        decimal CalculateTotalPayments(decimal principal, int termInMonths, decimal annualInterestRate);

        // Method to render calculation results as IRenderable
        IRenderable RenderCalculationResults(decimal principal, int termInMonths, decimal annualInterestRate);

        public interface IExpandable;

        public interface IRenderable;

        public interface IAlignable;

    }
}
