﻿using Microsoft.VisualBasic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MastermindCSProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string color1, color2, color3, color4;
        private int attempts = 0;
        private DispatcherTimer timer = new DispatcherTimer();
        DateTime startTime;


        public MainWindow()
        {
            InitializeComponent();

            //Start declaratie timer. Timespan is 1 seconde zodat de timer iedere tick 1 seconde vooruit gaat.
            timer.Tick += StartCountdown;
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Start();
            startTime = DateTime.Now;
            
            RandomColors(out color1, out color2, out color3, out color4);
            secretCodeTextBox.Text = $"Kleur 1: {color1}, Kleur 2: {color2}, Kleur 3:{color3}, Kleur 4:{color4}";

            Title = $"Mastermind - Poging: {attempts}";



        }
        //timespan wordt globaal gedeclareerd zodat hij overal gebruikt kan worden.
        TimeSpan interval;

        private void StartCountdown(object? sender, EventArgs e)
        {
            //Een begintijd declareren
            interval = DateTime.Now.Subtract(startTime);
            timerLabel.Content = "Timer: " + interval.ToString("mm\\:ss");
            //een limiet declareren
            TimeSpan limit = TimeSpan.FromSeconds(10);

            //Als de timer langer dan 10 seconden is, stop de timer en voeg 1 poging toe aan de teller
            if (interval.TotalSeconds >= limit.TotalSeconds)
            {
                timer.Stop();
                attempts = attempts + 1;
                this.Title = $"Mastermind - Poging: {attempts}";
            }
        }
        

        private void ToggleDebug(object sender, KeyEventArgs e)
        {
            //Als CTRL + F12 wordt ingedrukt EN de texbox is verborgen, laat deze dan zien.
            if ((e.Key == Key.F12 && e.KeyboardDevice.Modifiers == ModifierKeys.Control) & secretCodeTextBox.Visibility == Visibility.Hidden)
            {
                secretCodeTextBox.Visibility = Visibility.Visible;
            }

            //Hetzelfde gebeurd hier, maar omgekeerd. Als de textbox zichtbaar is, wordt deze verborgen.
            else if ((e.Key == Key.F12 && e.KeyboardDevice.Modifiers == ModifierKeys.Control) & secretCodeTextBox.Visibility == Visibility.Visible)
            {
                secretCodeTextBox.Visibility= Visibility.Hidden;
            }
        }

        public void RandomColors(out string color1, out string color2, out string color3, out string color4)
        {
            Random newColor = new Random();
            List<string> colorList = new List<string>();
            string randomColor;

            for (int i = 1; i <= 4; i++)
            {
                randomColor = (newColor.Next(1, 7)).ToString();
                switch (randomColor)
                {
                    case "1":
                        randomColor = "White";
                        break;
                    case "2":
                        randomColor = "Red";
                        break;
                    case "3":
                        randomColor = "Blue";
                        break;
                    case "4":
                        randomColor = "Green";
                        break;
                    case "5":
                        randomColor = "Yellow";
                        break;
                    case "6":
                        randomColor = "Orange";
                        break;
                }

                colorList.Add(randomColor);
            }

            color1 = colorList[0];
            color2 = colorList[1];
            color3 = colorList[2];
            color4 = colorList[3];

        }

        private void colorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == color1ComboBox)
            {
                switch (color1ComboBox.SelectedIndex)
                {
                    case 0:
                        color1Label.Background = Brushes.White;
                        break;
                    case 1:
                        color1Label.Background = Brushes.Red;
                        break;
                    case 2:
                        color1Label.Background = Brushes.Blue;
                        break;
                    case 3:
                        color1Label.Background = Brushes.Green;
                        break;
                    case 4:
                        color1Label.Background = Brushes.Orange;
                        break;
                    case 5:
                        color1Label.Background = Brushes.Yellow;
                        break;
                }
            }

            else if (sender == color2ComboBox)
            {
                switch (color2ComboBox.SelectedIndex)
                {
                    case 0:
                        color2Label.Background = Brushes.White;
                        break;
                    case 1:
                        color2Label.Background = Brushes.Red;
                        break;
                    case 2:
                        color2Label.Background = Brushes.Blue;
                        break;
                    case 3:
                        color2Label.Background = Brushes.Green;
                        break;
                    case 4:
                        color2Label.Background = Brushes.Orange;
                        break;
                    case 5:
                        color2Label.Background = Brushes.Yellow;
                        break;
                }
            }

            else if (sender == color3ComboBox)
            {
                switch (color3ComboBox.SelectedIndex)
                {
                    case 0:
                        color3Label.Background = Brushes.White;
                        break;
                    case 1:
                        color3Label.Background = Brushes.Red;
                        break;
                    case 2:
                        color3Label.Background = Brushes.Blue;
                        break;
                    case 3:
                        color3Label.Background = Brushes.Green;
                        break;
                    case 4:
                        color3Label.Background = Brushes.Orange;
                        break;
                    case 5:
                        color3Label.Background = Brushes.Yellow;
                        break;
                }
            }

            else if (sender == color4ComboBox)
            {
                switch (color4ComboBox.SelectedIndex)
                {
                    case 0:
                        color4Label.Background = Brushes.White;
                        break;
                    case 1:
                        color4Label.Background = Brushes.Red;
                        break;
                    case 2:
                        color4Label.Background = Brushes.Blue;
                        break;
                    case 3:
                        color4Label.Background = Brushes.Green;
                        break;
                    case 4:
                        color4Label.Background = Brushes.Orange;
                        break;
                    case 5:
                        color4Label.Background = Brushes.Yellow;
                        break;
                }
            }
        }

        private void checkCodeButton_Click(object sender, RoutedEventArgs e)
        {
            

            string chosenColor1, chosenColor2, chosenColor3, chosenColor4;
            chosenColor1 = color1ComboBox.Text;
            chosenColor2 = color2ComboBox.Text;
            chosenColor3 = color3ComboBox.Text;
            chosenColor4 = color4ComboBox.Text;

            List<string> generatedColors = new List<string> {color1, color2, color3, color4};
            List<string> chosenColors = new List<string> {chosenColor1, chosenColor2, chosenColor3, chosenColor4};

            for (int i = 0; i < 4; i++) 
            {
                Label targetLabel= null;

                switch (i)
                {
                    case 0: targetLabel = color1Label;
                        break;
                    case 1: targetLabel = color2Label;
                        break;
                    case 2: targetLabel = color3Label;
                        break;
                    case 3: targetLabel = color4Label;
                        break;
                }

                if (chosenColors[i] == generatedColors[i])
                {
                    targetLabel.BorderBrush = Brushes.DarkRed;
                    targetLabel.BorderThickness = new Thickness(5);
                }
                else if (generatedColors.Contains(chosenColors[i]))
                {
                    targetLabel.BorderBrush = Brushes.Wheat;
                    targetLabel.BorderThickness = new Thickness(5);
                }
                else
                {
                    targetLabel.BorderBrush = Brushes.Transparent;
                    targetLabel.BorderThickness = new Thickness(5);
                }

            }
            //Timer start opnieuw
            timer.Tick += StartCountdown;
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Start();
            startTime = DateTime.Now;

            attempts = attempts + 1;
            this.Title = $"Mastermind - Poging: {attempts}";
        }
    }
}