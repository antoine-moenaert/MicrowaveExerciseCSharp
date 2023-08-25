using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrowaveExerciseCSharp.Utilities
{
    public static class MicrowaveExtensions
    {
        public static void OpenDoor(this MicrowaveOven oven)
        {
            Console.WriteLine("Opening door.");
            if (!oven.DoorOpen)
                oven.OnDoorOpenChanged();
        }

        public static void CloseDoor(this MicrowaveOven oven)
        {
            Console.WriteLine("Closing door.");
            if (oven.DoorOpen)
                oven.OnDoorOpenChanged();
        }

        public static void Run(this MicrowaveOven oven)
        {
            Console.WriteLine("To interact with the oven:");
            Console.WriteLine("Press 'O' to open the door.");
            Console.WriteLine("Press 'C' to close the door.");
            Console.WriteLine("Press 'S' to start the oven.\n");

            while (true)
            {
                char input = char.ToUpper(Console.ReadKey(intercept: true).KeyChar);

                switch (input)
                {
                    case 'O':
                        oven.OpenDoor();
                        Console.WriteLine();
                        break;
                    case 'C':
                        oven.CloseDoor();
                        Console.WriteLine();
                        break;
                    case 'S':
                        oven.OnStartButtonPressed();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
