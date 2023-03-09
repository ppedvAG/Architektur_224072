using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;

namespace ppedv.SchrottyCar.UI.WPF.ViewModels
{
    internal class CarsViewModel : INotifyPropertyChanged
    {
        IRepository _repository;
        private Car selectedCar;

        //todo: kill it!
        public CarsViewModel() : this(new Data.EfCore.EfRepository("Server=(localdb)\\mssqllocaldb;Database=SchrottyDb_Tests;Trusted_Connection=true;"))
        { }

        public CarsViewModel(IRepository repository)
        {
            _repository = repository;

            CarList = new List<Car>(_repository.Query<Car>().Where(x => !x.IsDeleted));
        }

        public List<Car> CarList { get; set; }

        public Car SelectedCar
        {
            get => selectedCar; 
            set
            {
                selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar)); 
                OnPropertyChanged(nameof(PS)); 
            }
        }

        public string PS
        {
            get
            {
                if (SelectedCar == null)
                    return "---";
                return (SelectedCar.KW * 0.73549875).ToString("N");
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
