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
using WPFNaudioLib;
using WPFControls;
using WpfSpectrum;
using System.Diagnostics;

namespace WPFSpectrum
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Audio audio;
        TimerTick timer = new TimerTick();
        public MainWindow()
        {
            InitializeComponent();

            audio = new Audio();
            

            timer.Time = 1;
            timer.Tick += timer_Tick;
            timer.Start();
            audio.StartRecording();
        }
        void timer_Tick(object sender ,EventArgs e)
        {
            for (int i = 0; i < ControlsLib.Count(); i++)
            {
                double size_h =this.Height - audio.list_array[i];

                ControlsLib.GetElementByID(i).SizeHeight = size_h;
            }
        }
        private void ListLabel_Loaded(object sender, RoutedEventArgs e)
        {
            ControlsLib.CreateLine(this.Height,this.Width, 8, ListLabel);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ControlsLib.Clear();
            ControlsLib.CreateLine(this.Height, this.Width, 8, ListLabel);

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
            audio.StopRecording();
            timer.Stop();
            
        }
    }
}
