using HR_desktop_app.Infrastructure.Commands;
using HR_desktop_app.ViewModels.Base;
using System;
using System.Windows;
using HR_desktop_app.Models.TestModelStudents;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HR_desktop_app.Data.GeneratorFakeStudents;
using System.Windows.Input;
using HR_desktop_app.Infrastructure.Commands;
using System.Windows.Data;
using System.ComponentModel;
using HR_desktop_app.ViewModels.TreeDerictoriesViewModels;
using System.IO;

namespace HR_desktop_app.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна
        /// <summary> Заголовок окна </summary>
        private string _Title = "Поле для проверки работы привязки";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion
        #region Тестовые данные со студентами и группами
        #region Поля и навигационные свойства
        private ObservableCollection<Group> _Groups;
        public ObservableCollection<Group> Groups
        {
            get => _Groups;
            set => Set(ref _Groups, value);
        }

        private Group _SelectedGroup;

        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set
            {
                if (!Set(ref _SelectedGroup, value)) return;
                _SelectedGroupStudents.Source = value?.Students;
                OnPropertyChanged(nameof(SelectedGroupStudents));
            }
        }

        private Student _SelectedStudent;
        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set => Set(ref _SelectedStudent, value);
        }
        private readonly CollectionViewSource _SelectedGroupStudents = new CollectionViewSource();
        public ICollectionView SelectedGroupStudents => _SelectedGroupStudents?.View;

        private void OnStudentFiltered(object sender, FilterEventArgs e)
        {
            var filter_text = _StudentFilterText;
            if (string.IsNullOrWhiteSpace(filter_text)) return;
            if (!(e.Item is Student student)) return;
            if (student.Name is null || student.SurName is null)
            {
                e.Accepted = false;
                return;
            }
            if (student.Name.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
            if (student.SurName.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;
        }

        private string _StudentFilterText;
        public string StudentFilterText
        {
            get => _StudentFilterText;
            set
            {
                if (!Set(ref _StudentFilterText, value)) return;
                _SelectedGroupStudents.View.Refresh();
            }
        }

        #endregion
        #region Команды
        public ICommand AddGroupCommand { get; }
        private bool CanAddGroupCommandExecute(object o) => true;
        private void OnAddGroupCommandExecuted (object o)
        {
            //TODO При удалении групп и новом создании повторяются номера групп
            var new_group = new Group() { Name = $"Группа {Groups.Count}", Students = new ObservableCollection<Student>() };
            Groups.Add(new_group);
            SelectedGroup = new_group;
        }

        public ICommand DeleteGroupCommand { get; }
        private bool CanDeleteGroupCommandExecute(object o) => o is Group group && Groups.Contains(group);
        private void OnDeleteGroupCommandExecuted(object o)
        {
            if (!(o is Group group)) return;
            int index = Groups.ToList().IndexOf(group);
            Groups.Remove(group);
            //TODO При удалении последней группы не присваивается selectedgroup
            if (index < Groups.Count)
            {
                SelectedGroup = Groups[index];
            }
        }
        public ICommand CloseAppCommand { get; }
        private void OnCloseAppCommandExecuted(object o) => Application.Current.Shutdown();
        private bool CanExecuteCloseAppCommand(object o) => true;

        #endregion

        #endregion

        #region Коллекция разнотипных данных
        private ICollection<object> _CompositeCollection;

        public ICollection<object> CompositeCollection
        {
            get => _CompositeCollection;
            set => Set(ref _CompositeCollection, value);
        }

        private object _SelectedElement;
        public object SelectedElement
        {
            get => _SelectedElement;
            set => Set(ref _SelectedElement, value);
        }
        #endregion

        #region Работа с каталогом папок
        public DirectoryViewModel DiskRoot { get; } = new DirectoryViewModel("d:\\");

        private DirectoryViewModel _SelectedDirectory;
        public DirectoryViewModel SelectedDirectory
        {
            get => _SelectedDirectory;
            set => Set(ref _SelectedDirectory, value);
        }

        #endregion



        public MainWindowViewModel()
        {
            #region Получение тестовых данных
            var rnd = new Random();
            var count = App.IsDeveloping ? 10 : 100;
            Group[] groups = new Group[rnd.Next(count)];

            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = new Group
                {
                    Name = $"Группа {i}"
                };
                groups[i].Students = GeneratorStudents.GetStudents(rnd.Next(10, 30), groups[i]);
            }
            
            Groups = new ObservableCollection<Group>(groups);

            _SelectedGroupStudents.Filter += OnStudentFiltered;
            //_SelectedGroupStudents.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
            _SelectedGroupStudents.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
            var composite = new List<object>();
            composite.Add("Hello world");
            composite.Add(6);
            composite.Add(groups[0]);
            composite.Add(GeneratorStudents.GetStudents(1, new Group { Name = "Test group"}).First());
            CompositeCollection = new ObservableCollection<object>(composite);
            #endregion

            #region Инициализация команд
            AddGroupCommand = new LambdaCommand(OnAddGroupCommandExecuted, CanAddGroupCommandExecute);
            DeleteGroupCommand = new LambdaCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);
            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanExecuteCloseAppCommand);
            #endregion
        }
    }
}
