using EierfarmBl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmUiMvvM
{
    public class MainWindowViewModel : ViewModelBase
    { 
        // Liste für Tiere
        public ObservableCollection<IEggProducer> Animals { get; set; } = new ObservableCollection<IEggProducer>();

        // Neues Tier Command
        public RelayCommand NewAnimalCommand { get; set; }

        // Füttern Command
        public RelayCommand FeedCommand { get; set; }

        // Ei Legen Command
        public RelayCommand LayEggCommand { get; set; }

        private IEggProducer _selectedAnimal;
        // Ausgewähltes Element der Oberfläche
        public IEggProducer SelectedAnimal
        {
            get
            {
                return _selectedAnimal;
            }
            set
            {
                _selectedAnimal = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel():base(null) // TODO: (a => Ok()) o.ä. übergeben für OK-Action
        {
            this.NewAnimalCommand = new RelayCommand(p => CanNewAnimal(), a => NewAnimal());
            this.FeedCommand = new RelayCommand(p => CanFeed(), a => Feed());
            this.LayEggCommand = new RelayCommand(p => CanLayEgg(), a => LayEgg());
        }


        private bool CanLayEgg()
        {
            return true;
        }

        private void LayEgg()
        {
            SelectedAnimal.LayEgg();
        }

        private bool CanFeed()
        {
            return true;
        }

        private void Feed()
        {
            if (this.SelectedAnimal is Bird bird)
            {
                bird.Eat();
            }
        }

        private bool CanNewAnimal()
        {
            return true;
        }

        private void NewAnimal()
        {
            Chicken chicken = new Chicken("Neues Huhn");
            this.Animals.Add(chicken);
            this.SelectedAnimal = chicken;
        }
    }
}
