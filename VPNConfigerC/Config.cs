using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace VPNConfigerC
{
    class Config
    {

        public string readAppSetting(string setting)
        {
            string appsetting = ConfigurationManager.AppSettings[setting];                                          //Return de waarde die bij de bijhorende KEY hoort. De 'KEY' is een resultaat binnen "<appSettings> </appSettings>'. Bijvoorbeeld '<add key="wachtwoord" value="welkom" />"

            return appsetting;
        }

        public void setAppSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);          //Dit bepaald volgens mij waar de config file wordt opgeslagen.
            config.AppSettings.Settings[key].Value = value;

            config.Save();

            ConfigurationManager.RefreshSection("appSettings");                                                     //Van MSDN: Refreshes the named section so the next time that it is retrieved it will be re-read from disk.

        }

    }
}
