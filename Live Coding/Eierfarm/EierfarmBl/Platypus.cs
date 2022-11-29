using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EierfarmBl
{
    public class Platypus : Mammal, IEggProducer, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public ObservableCollection<Egg> Eggs { get; set; } = new();

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
                OnPropertyChanged();
            }
        }


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
                OnPropertyChanged();
            }
        }


        public override void BreastFeed()
        {
            throw new NotImplementedException();
        }

        public void LayEgg()
        {
            if (this.Weight > 2500)
            {
                Egg egg = new Egg(this);
                this.Weight -= egg.Weight;
                this.Eggs.Add(egg);
            }
        }
    }
}