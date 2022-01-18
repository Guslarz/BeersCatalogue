using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public abstract class CollectionViewModel<T> : ViewModel 
        where T : ValidatableViewModel
    {
        private T _selected;

        protected T _draft;

        public ICommand CreateCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SelectCommand { get; }

        public bool IsDraftSelected { get => _draft != null && _draft == _selected; }
        public T Selected
        {
            get => _selected;
            protected set
            {
                _selected = value;
                NotifyProperyChanged();
                NotifyProperyChanged(nameof(IsDraftSelected));
            }
        }

        public ObservableCollection<T> List { get; private set; }

        public CollectionViewModel() : base()
        {
            LoadList();
            CreateCommand = new RelayCommand(param => Create());
            SaveCommand = new RelayCommand(param => Save());
            SelectCommand = new RelayCommand(Select);
            _draft = null;
            Selected = null;
        }

        protected abstract void Create();

        protected abstract IEnumerable<T> Load();

        protected abstract void Save();

        protected abstract void Select(object obj);

        protected void LoadList()
        {
            List = new ObservableCollection<T>(Load());
            NotifyProperyChanged(nameof(List));
        }
    }
}
