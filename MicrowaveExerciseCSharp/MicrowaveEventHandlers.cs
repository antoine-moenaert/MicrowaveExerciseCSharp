using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrowaveExerciseCSharp
{
    public static class MicrowaveEventHandlers
    {
        public static void OnStartButtonPressed(object? source, EventArgs e)
        {
            ArgumentNullException.ThrowIfNull(source);

            MicrowaveOven oven = (MicrowaveOven)source;
            int timerIntervalInMiliseconds = 60000;

            if (!oven.DoorOpen)
            {
                if (!oven.HeaterOn)
                {
                    oven.TurnOnHeater();
                    var timerTask = SetTimerAndTurnOffHeaterAsync(timerIntervalInMiliseconds);
                    timerTask.ContinueWith(_ => Console.WriteLine());
                }
                else
                    oven.Timer += timerIntervalInMiliseconds;
            }
            else
                Console.WriteLine();

            async Task SetTimerAndTurnOffHeaterAsync(int timerIntervalInMiliseconds)
            {
                oven.Timer = timerIntervalInMiliseconds;

                while (oven.Timer > 0)
                {
                    Console.WriteLine($"Countdown: {oven.Timer / 1000} seconds remaining.");
                    await Task.Delay(1000);
                    oven.Timer -= 1000;
                }

                oven.TurnOffHeater();
            }
        }

        public static void OnDoorOpenChanged(bool doorOpen)
        {
            // ?
        }
    }
}
