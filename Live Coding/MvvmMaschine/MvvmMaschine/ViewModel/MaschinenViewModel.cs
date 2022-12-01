using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmMaschine.ViewModel
{
    public class MaschinenViewModel
    {
        public MaschinenViewModel()
        {
            this.Wurfmaschine = new TennisballWurfmaschine();

            this.StartCommand = new RelayCommand(p => CanStarten(), a => Starten());
            this.StoppCommand = new RelayCommand(p => CanStoppen(), a => Stoppen());
        }

        private bool CanStoppen()
        {
            return this.Wurfmaschine.IstAmLaufen;
        }

        private void Stoppen()
        {
            this.Wurfmaschine.Stopp();
        }

        private bool CanStarten()
        {
            return !this.Wurfmaschine.IstAmLaufen;
        }

        private void Starten()
        {
            this.Wurfmaschine.Start();
        }

        private TennisballWurfmaschine _wurfmaschine;
        public TennisballWurfmaschine Wurfmaschine
        {
            get { return _wurfmaschine; }
            set
            {
                _wurfmaschine = value;
            }
        }

        public RelayCommand StartCommand { get; set; }
        public RelayCommand StoppCommand { get; set; }
    }
}
