﻿using Homework_16.Data;
using Homework_16.Models;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Homework_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new TasksNetworkCinemaDb();
            
            //tasks.AllShowtimesCurrentWeak();

            //tasks.NonBookedSeats();

            //tasks.AllMoneyEarnedByEachMovie();

            //tasks.Top3UsersWhoSpentMostMoneyInTheSpecifiedDates(DateTime.Now, DateTime.Now);

            //tasks.NoActiveLastWeekCinemas();
        }
    }
}