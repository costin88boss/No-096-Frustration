using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace No096FrustrationEXILED20
{
    class PlayerHandler
    {
        public List<Player> Scp096Players = new List<Player>();
        public void OnPlayerLeft(DestroyingEventArgs e)
        {
            if (e.Player.Role == RoleType.Scp096)
                Scp096Players.Remove(e.Player);

        }
        public void OnChangeRole(ChangingRoleEventArgs e)
        {
            if (No_096_Frustration.Singleton.Config.ChangingRoleTriggersPlugin)
            {
                if (e.NewRole == RoleType.Scp096 && e.Player.Role != RoleType.Scp096)

                    Scp096Players.Add(e.Player);

                if (e.NewRole != RoleType.Scp096 && e.Player.Role == RoleType.Scp096)

                    Scp096Players.Remove(e.Player);

                if (e.NewRole == RoleType.Scp096)
                {
                    Log.Debug("Changing role");
                    Timing.CallDelayed(0.1f, () => { CheckStuff(true); });
                }
            }
        }
        public void OnPlayerSpawn(SpawningEventArgs e)
        {
            if (No_096_Frustration.Singleton.Config.ChangingRoleTriggersPlugin)
                if (e.RoleType == RoleType.Scp096)
                {
                    Scp096Players.Add(e.Player);
                    Timing.CallDelayed(0.1f, () => { CheckStuff(true); });
                }
        }
        void CheckStuff(bool OnRoundStart)
        {
            if (!OnRoundStart)
            {
                if (Player.List.Count() <= No_096_Frustration.Singleton.Config.MaxPlayersNewScp)
                SetRole(true);
            }
            else if (Player.List.Count() <= No_096_Frustration.Singleton.Config.MaxPlayersNewScp && !Player.List.Any(e => e.IsScp && e.Role != RoleType.Scp096))
            {
                SetRole(false);
            }
        }

        void SetRole(bool Respawn)
        {
            foreach (Player player in Scp096Players)
            {
                int randomizer = Random.Range(1, 4);
                switch (randomizer)
                {
                    case 1:

                        player.Broadcast(10, No_096_Frustration.Singleton.Config.Were096ChangedMsg.Replace("{PlayerCount}", No_096_Frustration.Singleton.Config.MaxPlayersNewScp.ToString()).Replace("{ScpName}", "Scp-049"));
                        player.SetRole(RoleType.Scp049, !Respawn);
                        break;
                    case 2:

                        player.Broadcast(10, No_096_Frustration.Singleton.Config.Were096ChangedMsg.Replace("{PlayerCount}", No_096_Frustration.Singleton.Config.MaxPlayersNewScp.ToString()).Replace("{ScpName}", "Scp-106"));
                        player.SetRole(RoleType.Scp106, !Respawn);
                        break;
                    case 3:

                        player.Broadcast(10, No_096_Frustration.Singleton.Config.Were096ChangedMsg.Replace("{PlayerCount}", No_096_Frustration.Singleton.Config.MaxPlayersNewScp.ToString()).Replace("{ScpName}", "Scp173"));
                        player.SetRole(RoleType.Scp173, !Respawn);
                        break;
                    case 4:

                        player.Broadcast(10, No_096_Frustration.Singleton.Config.Were096ChangedMsg.Replace("{PlayerCount}", No_096_Frustration.Singleton.Config.MaxPlayersNewScp.ToString()).Replace("{ScpName}", "Scp-939-53"));
                        player.SetRole(RoleType.Scp93953, !Respawn);
                        break;
                }

            }
        }
    }
}
