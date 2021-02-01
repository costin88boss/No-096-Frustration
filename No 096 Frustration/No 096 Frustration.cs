
using Exiled.Events.Handlers;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;
using System;

namespace No096FrustrationEXILED20
{
    public class No_096_Frustration : Plugin<Config>
    {
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 30);
        public override Version Version { get; } = new Version(1, 1, 2);

        public static No_096_Frustration Singleton;

        PlayerHandler PlayerHandler;

        public override void OnDisabled()
        {
            Singleton = null;
            Unregister();
        }

        public override void OnEnabled()
        {
            Singleton = this;
            Register();
        }

        public void Register()
        {
            PlayerHandler = new PlayerHandler();

            Player.Destroying += PlayerHandler.OnPlayerLeft;
            Player.Spawning += PlayerHandler.OnPlayerSpawn;
            Player.ChangingRole += PlayerHandler.OnChangeRole;
        }
        public void Unregister()
        {
            Player.Destroying -= PlayerHandler.OnPlayerLeft;
            Player.Spawning -= PlayerHandler.OnPlayerSpawn;
            Player.ChangingRole -= PlayerHandler.OnChangeRole;

            PlayerHandler = null;
        }


    }
}
