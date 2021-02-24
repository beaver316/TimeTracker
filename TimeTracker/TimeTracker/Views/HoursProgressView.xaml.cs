using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HoursProgressView : ContentView
    {
        // we create properties that we can bind to in the xaml, without the need for viewmodel

        public static readonly BindableProperty MaxProperty = BindableProperty.Create(
            nameof(Max), typeof(double), typeof(HoursProgressView), 80.0d);

        public static readonly BindableProperty MinProperty = BindableProperty.Create(
            nameof(Min), typeof(double), typeof(HoursProgressView), 0.0d);

        public static readonly BindableProperty CurrentProperty = BindableProperty.Create(
            nameof(Current), typeof(double), typeof(HoursProgressView), 0.0d);

        public double Max
        {
            get => (double)GetValue(MaxProperty);
            set => SetValue(MaxProperty, value);
        }

        public double Min
        {
            get => (double)GetValue(MinProperty);
            set => SetValue(MinProperty, value);
        }

        public double Current
        {
            get => (double)GetValue(CurrentProperty);
            set => SetValue(CurrentProperty, value);
        }

        public HoursProgressView()
        {
            InitializeComponent();
        }
    }
}