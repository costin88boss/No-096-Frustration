
using Exiled.Events.Handlers;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace No_096_Frustration_EXILED2._0
{
    public class No_096_Frustration : Plugin<Config>
    {
        public static No_096_Frustration SingleTon;

        PlayerHandler playerHandler;

        public override void OnDisabled()
        {
            SingleTon = null;
            Unregister();
        }

        public override void OnEnabled()
        {
            SingleTon = this;
            Register();
        }

        public void Register()
        {
            playerHandler = new PlayerHandler();

            Player.Destroying += playerHandler.OnPlayerLeft;
            Player.Spawning += playerHandler.OnPlayerSpawn;
            Player.ChangingRole += playerHandler.OnChangeRole;
        }
        public void Unregister()
        {

        }


    }
}
