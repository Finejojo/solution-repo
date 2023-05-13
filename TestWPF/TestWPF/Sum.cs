using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    public class Sum : INotifyPropertyChanged
    {
        private string num1;
        private string num2;
        private string result;

        public string Num1 { get { 
                return num1;
            } 
            set {
                bool check = int.TryParse(value, out int number);
                if (check) num1 = value;
                OnPropertyChanged("Num1");
                OnPropertyChanged("Result");

            } 
        }

        public string Num2
        {
            get
            {
                return num2;
            }
            set
            {
                bool check = int.TryParse(value, out int number);
                if (check) num2 = value;
                OnPropertyChanged("Num2");
                OnPropertyChanged("Result");
            }
        }
        public string Result
        {
            get
            {
                int res = int.Parse(Num1) + int.Parse(Num2);
                return res.ToString();
            }
            set
            {
                int res = int.Parse(Num1) + int.Parse(Num2);
                result = res.ToString();
                
                OnPropertyChanged("Result");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
