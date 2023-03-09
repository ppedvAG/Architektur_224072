﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ppedv.SchrottyCar.UI.WPF.ViewModels
{
    internal class CarsViewModel : ObservableObject
    {
        readonly IRepository _repository;
        private Car selectedCar;

        public ICommand SaveCommandOLD { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public CarsViewModel(IRepository repository)
        {
            _repository = repository;

            CarList = new ObservableCollection<Car>(_repository.Query<Car>().Where(x => !x.IsDeleted));
            SaveCommandOLD = new SaveCommand(repository);

            SaveCommand = new RelayCommand(() => repository.SaveAll());

            NewCommand = new RelayCommand(UserWantsToAddNewCar);
        }

        private void UserWantsToAddNewCar()
        {
            var newCar = new Car()
            {
                BuildDate = DateTime.Now.AddDays(-123),
                Manufacturer = "NEU"
            };
            _repository.Add(newCar);
            CarList.Add(newCar);
            SelectedCar = newCar;
        }

        public ObservableCollection<Car> CarList { get; set; }

        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
                OnPropertyChanged(nameof(PS));
                //OnPropertyChanged("");
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
    }
}
