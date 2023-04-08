using HR_desktop_app.ViewModels.Base;
using System;
using HR_desktop_app.Models.TestModelStudents;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Faker;
using HR_desktop_app.Data.GeneratorFakeStudents;

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

        private ICollection<Group> _Groups;
        public ICollection<Group> Groups
        {
            get => _Groups;
            set => Set(ref _Groups, value);
        }


        private Group _SelectedGroup;

        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => Set(ref _SelectedGroup, value);
        }

        private Student _SelectedStudent;
        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set => Set(ref _SelectedStudent, value);
        }

        #endregion

        public MainWindowViewModel()
        {
            #region Получение тестовых данных
            var rnd = new Random();

            Group[] groups = new Group[rnd.Next(5, 20)];

            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = new Group
                {
                    Name = $"Группа {i}"
                };
                groups[i].Students = GeneratorStudents.GetStudents(rnd.Next(10, 30), groups[i]);
            }

            Groups = new ObservableCollection<Group>(groups);
            #endregion







        }
    }
}
