using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTA.Math;

namespace TutorialScript
{


    public class Main : Script
    {
        Vehicle car;
        int GameTimeReference = Game.GameTime + 1000;
        public Main()
        {
            Tick += onTick;
            KeyDown += onKeyDown;
            GameTimeReference = Game.GameTime + 1000;
        }

        private void onTick(object sender, EventArgs e)
        {

            if (Game.GameTime > GameTimeReference)
            {
                if (Function.Call<bool>(Hash.IS_PED_IN_ANY_VEHICLE, Game.Player.Character, false)) ;
                {
                    car.Repair();
                    GameTimeReference = Game.GameTime + 1000;
                }
            }

        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad7)
            {
                car = World.CreateVehicle(VehicleHash.Adder, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0)));
                UI.Notify("Adder has been ~b~spawned!");
            }
        }

    }
}
