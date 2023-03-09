﻿using ppedv.SchrottyCar.Model.Contracts;
using System;
using System.Windows.Input;

namespace ppedv.SchrottyCar.UI.WPF.ViewModels
{
    public class SaveCommand : ICommand
    {
        private readonly IRepository repo;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public SaveCommand(IRepository repo)
        {
            this.repo = repo;
        }

        public void Execute(object? parameter)
        {
            repo.SaveAll();
        }
    }
}
