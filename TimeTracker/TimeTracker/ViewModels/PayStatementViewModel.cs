using System;
using System.Collections.Generic;
using System.Text;
using TimeTracker.Models;
using TimeTracker.PageModels.Base;

namespace TimeTracker.ViewModels
{
    public class PayStatementViewModel : ExtendedBindableObject
    {
        private double _earnings;
        public double Earnings
        {
            get => _earnings;
            set => SetProperty(ref _earnings, value);
        }

        private double _totalHours;
        public double TotalHours
        {
            get => _totalHours;
            set => SetProperty(ref _totalHours, value);
        }

        private string _payRange;
        public string PayRange
        {
            get => _payRange;
            set => SetProperty(ref _payRange, value);
        }


        public PayStatementViewModel(PayStatement statement)
        {
            PayRange = statement.Start.ToString("MMM d") + " - " + statement.End.ToString("MMM d, yyyy");
            Earnings = statement.Amount;

            foreach (var item in statement.WorkItems)
            {
                TotalHours += item.Total.TotalHours;
            }
        }
    }
}
