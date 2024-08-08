using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MortgageCalculator
{


    internal class MortgageCalculator
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Mortgage Calculator");
            Console.Write("Enter loan amount (principal): ");
            double principal = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter annual interest rate (as a decimal): ");
            double annualInterestRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter loan term in years: ");
            int years = Convert.ToInt32(Console.ReadLine());

            // Calculate monthly interest rate and number of payments
            double monthlyInterestRate = annualInterestRate / 12.0;
            int numberOfPayments = years * 12;

            // Calculate monthly mortgage payment
            double monthlyPayment = principal * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfPayments)) /
                                    (Math.Pow(1 + monthlyInterestRate, numberOfPayments) - 1);

            // Remaining Balance
            // Output the monthly payment
            Console.WriteLine($"\nMonthly Payment: {monthlyPayment:C}");

            // Calculate remaining balance after each payment
            double remainingBalance = principal;
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Payment Schedule:");
            Console.WriteLine("Month\t\tPayment\t\tRemaining Balance");
            Console.WriteLine("----------------------------------------");
            var grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddRow(new Text[]{
            new Text("Month", new Style(Color.Red, Color.Black)).LeftJustified(),
            new Text("Monthly Payment", new Style(Color.Green, Color.Black)).Centered(),
            new Text("Remaining Balance", new Style(Color.Blue, Color.Black)).RightJustified()
});
            for (int month = 1; month <= numberOfPayments; month++)
            {
                // Calculate interest for the current month
                double interestPayment = remainingBalance * monthlyInterestRate;

                // Calculate principal payment for the current month
                double principalPayment = monthlyPayment - interestPayment;

                // Update remaining balance
                remainingBalance -= principalPayment;

                // Output payment details for the current month
                // Using an interpolated string for embedding expressions inside the string and allignment purposes the \t\t



                // Add row
                grid.AddRow(new string[] { month.ToString(), monthlyPayment.ToString("c"), remainingBalance.ToString("c") });
                
                
                // Add header row 


                // Write to Console
               
            }
            AnsiConsole.Write(grid);


            // Output the result
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Mortgage Summary:");
            Console.WriteLine($"Principal Amount: {principal:C}");
            Console.WriteLine($"Annual Interest Rate: {annualInterestRate:P}");
            Console.WriteLine($"Loan Term: {years} years");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Monthly Payment: {monthlyPayment:C}");
            // Wait for user to acknowledge the results
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();

        }

           


            }
        }

      
 

