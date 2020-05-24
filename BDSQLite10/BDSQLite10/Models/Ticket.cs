using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lab9BD.Models
{
    public class Ticket : INotifyPropertyChanged
    {
        private string arrival;
        private string departure;
        private int price;
        public int Id { get; set; }

        public string Arrival
        {
            get { return arrival; }
            set
            {
                arrival = value;
                OnPropertyChanged("Title");
            }
        }
        public string Departure
        {
            get { return departure; }
            set
            {
                departure = value;
                OnPropertyChanged("Company");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
