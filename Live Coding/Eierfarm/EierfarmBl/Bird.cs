using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public abstract class Bird : IEggProducer, IDisposable, INotifyPropertyChanged // INotifyPropertyChanged speziell für WPF entworfen
    {

        /// <summary>
        /// Tritt auf, wenn sich der Wert einer Property ändert.
        /// </summary>
        //public event EventHandler<BirdEventArgs> PropertyChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                //this.PropertyChanged(this, new BirdEventArgs(propName));
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public Bird(string name)
        {
            this.Name = name;
        }

        public ObservableCollection<Egg> Eggs { get; set; } = new ObservableCollection<Egg>();

        public DateTime HatchDate { get; init; }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private double _weight;


        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                OnPropertyChanged("Weight");
            }
        }

        public void Dispose()
        {
            foreach (Egg egg in this.Eggs)
            {
                egg.Mother = null;
            }

            this.Eggs = null;
        }

        public abstract void Eat();

        public abstract void LayEgg();
    }

    public class BirdEventArgs : EventArgs
    {
        public BirdEventArgs(string changedProperty)
        {
            this.ChangedProperty = changedProperty; 
        }

        public string ChangedProperty { get; set; }
    }
}