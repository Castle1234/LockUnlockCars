using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace LockUnlockCars
{
    public class Main : BaseScript
    {
        [Command("lock")]
        [Command("unlock")]

        public void checkIsInVehicle()
        {
            if (Game.PlayerPed.CurrentVehicle == null)
            {
                Screen.ShowNotification("You are not in a vehicle");
                return;
            }
        }
        private void LockCar()
        {
            var pedVehicle = Game.PlayerPed.CurrentVehicle.Handle;
            checkIsInVehicle();
            // Lock the vehicle
            API.SetVehicleDoorsLocked(pedVehicle, 2);
            Screen.ShowNotification("Vehicle Locked");
            // Check if the vehicle is already locked
            if (API.GetVehicleDoorLockStatus(pedVehicle) == 2)
            {
                Screen.ShowNotification("Vehicle is already locked");
            }
        }

        private void unlockCar()
        {
            var pedVehicle = Game.PlayerPed.CurrentVehicle.Handle;
            checkIsInVehicle();

            API.SetVehicleDoorsLocked(pedVehicle, 1);
            Screen.ShowNotification("Vehicle Unlocked");
            if (API.GetVehicleDoorLockStatus(pedVehicle) == 1)
            {
                Screen.ShowNotification("Vehicle is already unlocked");
            }
        }
    }
}
