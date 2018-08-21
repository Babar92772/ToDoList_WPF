﻿using System;
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
using System.Windows.Shapes;
using TrelloWPF.Models;

namespace TrelloWPF
{
    /// <summary>
    /// Interaction logic for EditTask.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        public Tasks tasks;

        public EditTask(Tasks tasks)
        {
            InitializeComponent();
            this.tasks = tasks;
            this.dp_deadline.Text = tasks.DeadLine.ToShortDateString();
            this.tb_note.Text = tasks.Note;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            this.tasks.DeadLine = Convert.ToDateTime(this.dp_deadline.Text);
            this.tasks.Note = this.tb_note.Text;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}