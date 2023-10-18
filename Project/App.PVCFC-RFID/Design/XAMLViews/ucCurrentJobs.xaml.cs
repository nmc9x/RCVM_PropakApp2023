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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for ucCurrentJobs.xaml
    /// </summary>
    public partial class ucCurrentJobs : UserControl
    {
        public static int Index { get; set; }


        private string _StationTagName;
        public string StationTagName
        {
            get { return _StationTagName; }
            set { _StationTagName = value; }
        }

        public ucCurrentJobs() : this(Index)
        {
            InitializeComponent();
            DataContext = this;
        }
        public ucCurrentJobs(int index)
        {
            Index = index;
        }
    }

}