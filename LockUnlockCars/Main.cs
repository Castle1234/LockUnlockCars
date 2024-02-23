using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;

namespace LockUnlockCars
{
    public class Main : BaseScript
    {
        public Main()
        {
            API.RegisterCommand("lock", new Action(LockCar), false);
            API.RegisterCommand("unlock", new Action(UnlockCar), false);
        }

        private void LockCar()
        {
            var player = Game.PlayerPed;
            var vehicle = player.CurrentVehicle.Handle;

            if (vehicle == 0)
            {
                Screen.ShowNotification("You are not in a vehicle.");
                return;
            }

            var lockStatus = API.GetVehicleDoorLockStatus(vehicle);
            if (lockStatus == 2 || lockStatus == 3)
            {
                API.SetVehicleDoorsLocked(vehicle, 2);
                Screen.ShowNotification("Vehicle locked.");
                return;
            }
        }

        private void UnlockCar()
        {
            var player = Game.PlayerPed;
            var vehicle = player.CurrentVehicle.Handle;

            if (vehicle == 0)
            {
                Screen.ShowNotification("You are not in a vehicle.");
                return;
            }

            var lockStatus = API.GetVehicleDoorLockStatus(vehicle);
            if (lockStatus == 1 || lockStatus == 2)
            {
                API.SetVehicleDoorsLocked(vehicle, 0);
                Screen.ShowNotification("Vehicle unlocked.");
                return;
            }
        }
    }
}
`