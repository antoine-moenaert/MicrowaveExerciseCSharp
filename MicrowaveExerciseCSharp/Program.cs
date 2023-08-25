// See https://aka.ms/new-console-template for more information

using MicrowaveExerciseCSharp;
using MicrowaveExerciseCSharp.Utilities;

MicrowaveOven oven = new(doorOpen: false, heaterOn: false, interiorLightOn: false);
oven.StartButtonPressed += MicrowaveEventHandlers.OnStartButtonPressed;
oven.DoorOpenChanged += MicrowaveEventHandlers.OnDoorOpenChanged;

oven.Run();
