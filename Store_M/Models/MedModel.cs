using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_M.Models
{
    class MedModel:INotifyPropertyChanged
    {
        private string nAme;
        private string izm;
        private int cams;
        private int go;
        private int still;
        private DateTime date;
        public string Name
        {
            get {return nAme;}
            set
            { 
                if (nAme == value)
                    return;
                nAme = value;
                OnPropertyChanged("Name");
            }
        }
        public string Izm
        {
            get { return izm; }
            set {
                if (izm == value)
                    return;
                izm = value;
                OnPropertyChanged("Izm");
            }
        }
        public int Cams
        {
            get { return cams; }
            set
            {
                if (cams == value)
                    return;
                cams = value;
                OnPropertyChanged("Cams");
            }
        }
        public int Go
        {
            get { return go; }
            set
            {
                if (go == value)
                    return;
                go = value;
                OnPropertyChanged("Go");
            }
        }
        public int Still
        {
            get { return still; }
            set
            {
                if (still == value)
                    return;
                still = value;
                OnPropertyChanged("Still");
            }
        }
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date == value)
                    return;
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = " ")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
