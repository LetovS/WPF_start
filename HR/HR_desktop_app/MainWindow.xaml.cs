﻿using HR_desktop_app.Models.TestModelStudents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HR_desktop_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GroupsCollectionFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Group group)) return;
            if(group.Name is null) return;

            var filter = GroupNameFilterText.Text;
            if(filter.Length == 0) return;

            if(group.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)) return;
            if (group.Description != null && group.Description.Contains(filter, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;
        }

        private void OnGroupsTextChanged(object sender, TextChangedEventArgs e)
        {
            var text_box = (TextBox) sender;
            var collection = (CollectionViewSource)text_box.FindResource("GroupsCollection");
            collection.View.Refresh();
        }
    }
}
