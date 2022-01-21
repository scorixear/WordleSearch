using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WordleSearch.Model;

namespace WordleSearch.ViewModel
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowModel()
        {

        }
        private ObservableCollection<string> outputListStrings;
        public ObservableCollection<string> OutputListSource
        {
            get
            {
                return outputListStrings;
            }
            set
            {
                outputListStrings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OutputListSource)));
            }
        }

        private string text1;
        public string Text1
        {
            get
            {
                return text1;
            }
            set
            {
                if(value == "" )
                {
                    text1 = null;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text1)));
                    return;
                }
                text1 = value.Last().ToString().ToUpper();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text1)));
            }
        }
        private string text2;
        public string Text2
        {
            get
            {
                return text2;
            }
            set
            {
                if (value == "")
                {
                    text2 = null;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text2)));
                    return;
                }
                text2 = value.Last().ToString().ToUpper();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text2)));
            }
        }
        private string text3;
        public string Text3
        {
            get
            {
                return text3;
            }
            set
            {
                if (value == "")
                {
                    text3 = null;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text3)));
                    return;
                }
                text3 = value.Last().ToString().ToUpper();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text3)));
            }
        }
        private string text4;
        public string Text4
        {
            get
            {
                return text4;
            }
            set
            {
                if (value == "")
                {
                    text4 = null;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text4)));
                    return;
                }
                text4 = value.Last().ToString().ToUpper();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text4)));
            }
        }
        private string text5;
        public string Text5
        {
            get
            {
                return text5;
            }
            set
            {
                if (value == "")
                {
                    text5 = null;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text5)));
                    return;
                }
                text5 = value.Last().ToString().ToUpper();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text5)));
            }
        }

        private readonly List<Button> activatedButtons = new();



        private void UpdateList()
        {
            StringBuilder buttonStrings = new StringBuilder();
            foreach (Button button in activatedButtons)
            {
                buttonStrings.Append(button.Content.ToString().ToLower());
            }
            string regex = RegexCreator.CreateRegex(new[] { Text1, Text2, Text3, Text4, Text5 }, buttonStrings.ToString());
            OutputListSource = new ObservableCollection<string>(RegexCreator.FindWords(RegexCreator.ReadWords("Words.json"), regex));
        }

        public void OnLetterButtonPressed(object sender, RoutedEventArgs e)
        {
            if (activatedButtons.Contains(sender))
            {
                _ = activatedButtons.Remove((Button)sender);
                ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x81, 0x83, 0x84));
            }
            else
            {
                activatedButtons.Add((Button)sender);
                ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x3A, 0x3A, 0x3C));
            }
            UpdateList();
        }

        public void OnResetButtonPressed(object sender, RoutedEventArgs e)
        {
            foreach (Button button in activatedButtons)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x81, 0x83, 0x84));
            }

            activatedButtons.Clear();
            UpdateList();
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
    }
}
