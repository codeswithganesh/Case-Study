using CarConnect.Exceptions;
using CarConnect.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Service
{
    
    
    internal class ReportGeneratorService
    {
        readonly ReportGeneratorRepository _reportGeneratorRepository;
        public ReportGeneratorService()
        {
            _reportGeneratorRepository = new ReportGeneratorRepository();
        }
        public void ReservationHistoryBCustomer()
        {
            try
            {
                Console.WriteLine("Enter the Username");
                string username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    throw new InvalidInputException("Username cannot be empty.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                List<object[]> list = _reportGeneratorRepository.ReservationHistoryBCustomer(username);
                if (list == null || list.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No reservation history found for the given username.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                foreach (object[] item in list)
                {
                    Console.WriteLine($"Name::{item[0]}\tModel::{item[1]}\tStartDate::{item[2]}\tEndDate::{item[3]}\tTotalCost::{item[4]}\tStatus::{item[5]}");
                }
            }
            catch (InvalidInputException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void ReservationHistoryBModel()
        {
            try
            {
                Console.WriteLine("Enter the Model");
                string model = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(model))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    throw new InvalidInputException("Model cannot be empty.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                List<object[]> list = _reportGeneratorRepository.ReservationHistoryBModel(model);
                if (list == null || list.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No reservation history found for the given model.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                foreach (object[] item in list)
                {
                    
                    Console.WriteLine($"Name::{item[0]}\tModel::{item[1]}\tStartDate::{item[2]}\tEndDate::{item[3]}\tTotalCost::{item[4]}\tStatus::{item[5]}");
                }
            }
            catch (InvalidInputException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        //public void ReservationHistoryBDate()
        //{
        //    List<Object[]> list = new List<Object[]>();
        //    Console.WriteLine("Enter the Start Date");
        //    DateTime start = DateTime.Parse(Console.ReadLine());
        //    Console.WriteLine("Enter the End Date");
        //    DateTime end = DateTime.Parse(Console.ReadLine());
        //    list = _reportGeneratorRepository.ReservationHistoryBDate(start,end);
        //    foreach (object[] item in list)
        //    {
        //        Console.WriteLine($"Name::{item[0]}\tModel::{item[1]}\tStartDate::{item[2]}\tEndDate::{item[3]}\tTotalCost::{item[4]}\tStatus:{item[5]}");


        //    }

        //}
        public void RevenueReport()
        {
            try
            {
                List<object[]> list = _reportGeneratorRepository.RevenueReport();
                if (list == null || list.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No revenue data found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                foreach (object[] item in list)
                {
                    Console.WriteLine($"Model::{item[0]} \tTotal Revenue::{item[1]}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void VehicleUtilizationReport()
        {
            try
            {
                List<object[]> list = _reportGeneratorRepository.VehicleUtilizationReport();
                if (list == null || list.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No vehicle utilization data found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                foreach (object[] item in list)
                {
                    Console.WriteLine($"Model::{item[0]}\tTotalMinutesBooked::{item[1]}\tTotalDaysBooked::{item[2]}\tUtilizationPercentage::{item[3]}%");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }


    }

