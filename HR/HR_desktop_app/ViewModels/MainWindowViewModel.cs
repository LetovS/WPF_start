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

        public ICollection<Group> Groups;

        #endregion

        public MainWindowViewModel()
        {

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






        }
    }
}
