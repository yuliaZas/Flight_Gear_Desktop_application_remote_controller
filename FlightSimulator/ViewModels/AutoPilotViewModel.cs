using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightSimulator.ViewModels 
{
    class AutoPilotViewModel : BaseNotify
    {
        private Model.EventArgs.VirtualGeographicCocordinatesEventArgs model;
        private Model.EventArgs.VirtualJoystickEventArgs joystickEventArgs = new Model.EventArgs.VirtualJoystickEventArgs();
        private Model.EventArgs.VirtualSliderEventArgs sliderEventArgs = Model.EventArgs.VirtualSliderEventArgs.Instance;
        private string text;
        private string backCol;
        private bool okClicked;
        private bool cleraClicked;

        public AutoPilotViewModel(Model.EventArgs.VirtualGeographicCocordinatesEventArgs model)
        {
            this.model = model;
            this.text = "";
            this.okClicked = false;
            this.cleraClicked = false;
            
        }
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                NotifyPropertyChanged("Text");
                NotifyPropertyChanged("BackgroundColor");
            }
        }

        public string BackgroundColor
        {
            get
            {
                if(text==null || text == "")
                {
                    backCol = "White";
                }
                else
                {
                    backCol = "PaleVioletRed";
                }
                return backCol;
            }
            set
            {

            }
        }
        #region Commands
        #region OK_Click
        private ICommand _0kCommand;
        public ICommand OK_Click
        {
            get
            {
                return _0kCommand ?? (_0kCommand = new CommandHandler(() => OkClick()));
            }
        }
        private void OkClick()
        {
            SendingTheCommands(text);
            ClearClick();

        }
        #endregion

        #region CancelCommand
        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => ClearClick()));
            }
        }
        private void ClearClick()
        {
            cleraClicked = true;
            Text = null;

        }
        #endregion
        #endregion

        private void SendingTheCommands(string text)
        {
            //parse the text
            string[] lines = text.Split(
                            new[] { "\r\n", "\r", "\n" },
                            StringSplitOptions.None
                            );

            // if there are more then one command in the text box
            if (lines.Length > 1) { }

            Task task = new Task(() => {
                foreach (string command in lines)
                {
                    String[] words = command.Split(' ');
                    if(words.Length == 3)
                    {
                        // words[0] = set words[1] = property words[2] = value
                        if (String.Compare(words[1], "controls/flight/rudder") == 0)
                        {
                            sliderEventArgs.Rudder = Convert.ToDouble(words[2]);
                        }
                        if (String.Compare(words[1], "controls/engines/current-engine/throttle") == 0)
                        {
                            sliderEventArgs.Throttle = Convert.ToDouble(words[2]);
                        }
                        if (String.Compare(words[1], "controls/flight/elevators") == 0)
                        {
                            joystickEventArgs.Elevator = Convert.ToDouble(words[2]);
                        }
                        if (String.Compare(words[1], "controls/flight/aileron") == 0)
                        {
                            joystickEventArgs.Aileron = Convert.ToDouble(words[2]);
                        }
                    }
                    System.Threading.Thread.Sleep(2000);
                }
            });
            task.Start();
        }
    }
}
