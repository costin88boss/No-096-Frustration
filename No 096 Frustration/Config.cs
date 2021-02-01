using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_096_Frustration_EXILED2._0
{
    public class Config : IConfig
    {
        [Description("Enable or Disable the plugin.")]
        public bool IsEnabled { get; set; } = true;
        [Description("The max amount of players needed for 096 to change.")]
        public int MaxPlayersNewScp { get; private set; } = 6;
        public bool ChangingRoleTriggersPlugin { get; private set; } = true;
        [Description("use {PlayerCount} to specify the \"MaxPlayersNewScp\" config and {ScpName} to specify the Scp he now is.")]
        public string Were096ChangedMsg { get; private set; } = "You were 096, but because there are less players or equal to {PlayerCount}, you have been changed to a random scp.";


    }
}
