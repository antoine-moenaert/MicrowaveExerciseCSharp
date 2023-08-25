using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrowaveExerciseCSharp
{
    public class MicrowaveOven : IMicrowaveOven
    {
        private bool _doorOpen;
        private bool _heaterOn;
        private bool _interiorLightOn;

        public MicrowaveOven(bool doorOpen = false, bool heaterOn = false, bool interiorLightOn = false)
        {
            _doorOpen = doorOpen;
            _heaterOn = heaterOn;
            _interiorLightOn = interiorLightOn;
        }

        public bool DoorOpen
        {
            get { return _doorOpen; }
        }

        public bool HeaterOn
        {
            get { return _heaterOn; }
        }

        public bool InteriorLightOn
        {
            get { return _interiorLightOn; }
        }

        public int Timer { get; set; }

        public event Action<bool>? DoorOpenChanged;
        public event EventHandler? StartButtonPressed;

        public void TurnOnHeater()
        {
            _heaterOn = true;
            Console.WriteLine("Heater is on.");
        }

        public void TurnOffHeater()
        {
            _heaterOn = false;
            Console.WriteLine("Heater is off.");
        }

        public virtual void OnDoorOpenChanged()
        {
            _doorOpen = !_doorOpen;

            if (_doorOpen)
            {
                _interiorLightOn = true;
                Console.WriteLine("Interior light is on.");
                _heaterOn = false;
                Console.WriteLine("Heater is off.");
                Console.WriteLine("Door is opened.");
            }
            else
            {
                _interiorLightOn = false;
                Console.WriteLine("Interior light is off.");
                Console.WriteLine("Door is closed.");
            }

            DoorOpenChanged?.Invoke(DoorOpen);
        }

        public virtual void OnStartButtonPressed()
        {
            Console.WriteLine("Start button pressed.");
            StartButtonPressed?.Invoke(this, new EventArgs());
        }
    }
}
