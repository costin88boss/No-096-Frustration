using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace No_096_Frustration_EXILED2._0
{
    class PlayerHandler
    {
        public List<Player> Scp096Players;
        public int Players;

        public void OnRoundStart()
        {
            Players = Player.List.Count();
        }
        public void OnPlayerLeft(LeftEventArgs e)
        {
            if (e.Player.Role == RoleType.Scp096)
                if (Scp096Players.Exists(k => k.UserId == e.Player.UserId))
                {
                    Scp096Players.Remove(e.Player);
                }
            Players--;
        }
        public void OnPlayerJoin(JoinedEventArgs e)
        {
            Players++;
        }
        public void OnChangeRole(ChangingRoleEventArgs e)
        {
            if (No_096_Frustration.SingleTon.Config.ChangingRoleTriggersPlugin)
                if (e.NewRole == RoleType.Scp096 && e.Player.Role != RoleType.Scp096)
                {
                    Scp096Players.Add(e.Player);
                    CheckStuff(false);
                }
        }
        public void OnPlayerSpawn(SpawningEventArgs e)
        {
            if (No_096_Frustration.SingleTon.Config.ChangingRoleTriggersPlugin)
                if (e.RoleType == RoleType.Scp096)
                {
                    Scp096Players.Add(e.Player);
                    CheckStuff(false);
                }
        }

        void CheckStuff(bool OnRoundStart)
        {
            if (!OnRoundStart)
            {
                if (Players <= No_096_Frustration.SingleTon.Config.MaxPlayersNewScp && !Player.List.Any(e => e.IsScp && e.Role != RoleType.Scp096))
                {
                    foreach (Player player in Scp096Players)
                    {
                        int randomizer = Random.Range(1, 4);
                        if (randomizer == 1)
                            player.Role = RoleType.Scp049;
                        if (randomizer == 2)
                            player.Role = RoleType.Scp106;
                        if (randomizer == 3)
                            player.Role = RoleType.Scp173;
                        if (randomizer == 4)
                            player.Role = RoleType.Scp93953;



                    }
                }
            }
            else if (Players <= No_096_Frustration.SingleTon.Config.MaxPlayersNewScp)
            {
                foreach (Player player in Scp096Players)
                {
                    int randomizer = Random.Range(1, 4);
                    if (randomizer == 1)
                        player.Role = RoleType.Scp049;
                    if (randomizer == 2)
                        player.Role = RoleType.Scp106;
                    if (randomizer == 3)
                        player.Role = RoleType.Scp173;
                    if (randomizer == 4)
                        player.Role = RoleType.Scp93953;
                }
            }
        }
    }
}
