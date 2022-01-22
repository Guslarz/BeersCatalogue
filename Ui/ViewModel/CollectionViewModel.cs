using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public abstract class CollectionViewModel<T, FilterViewModel, I> : ViewModel
        where T : ValidatableViewModel, I
        where FilterViewModel : ViewModel, IFilter<I>, new()
    {
        private T _selected;
        private FilterViewModel _filter;
        private ObservableCollection<T> _list;

        protected T _draft;

        public ICommand CreateCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SelectCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ApplyFilterCommand { get; }
        public ICommand ResetFilterCommand { get; }

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
        public FilterViewModel Filter
        {
            get => _filter;
            protected set
            {
                _filter = value;
                NotifyProperyChanged();
            }
        }

        public ObservableCollection<T> List
        {
            get => _list;
            private set
            {
                _list = value;
                NotifyProperyChanged();
            }
        }

        public CollectionViewModel() : base()
        {
            LoadList();
            CreateCommand = new RelayCommand(param => Create());
            SaveCommand = new RelayCommand(param => Save());
            SelectCommand = new RelayCommand(Select);
            DeleteCommand = new RelayCommand(param => Delete());
            ApplyFilterCommand = new RelayCommand(param => ApplyFilter());
            ResetFilterCommand = new RelayCommand(param => ResetFilter());
            _draft = null;
            Selected = null;
            Filter = new FilterViewModel();
        }

        protected abstract void Create();

        protected abstract IEnumerable<T> Load();

        protected abstract void Save();

        protected abstract void Select(object obj);

        protected abstract void Delete(T item);

        protected void LoadList()
        {
            List = new ObservableCollection<T>(Load());
        }

        private void Delete()
        {
            if (!IsDraftSelected)
            {
                Delete(Selected);
            }
            LoadList();
            Selected = null;
        } 

        private void ApplyFilter()
        {
            List = new ObservableCollection<T>(Load()
                .Where(Filter.Test));
        }

        private void ResetFilter()
        {
            LoadList();
            Filter.Reset();
        }
    }
}
