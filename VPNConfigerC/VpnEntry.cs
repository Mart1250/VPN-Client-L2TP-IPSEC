using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotRas;

namespace VPNConfigerC
{
    class VpnEntry
    {

    public RasEntry createEntry(string vpnname, string destination)                                                             //We maken ene nieuwe entry aan met specifieke settings. Zoals L2TP en het type communicatie middel, 'vpn' in dit geval.
        {

            RasEntry entry = DotRas.RasEntry.CreateVpnEntry(vpnname, destination, DotRas.RasVpnStrategy.L2tpOnly, DotRas.RasDevice.Create(vpnname, DotRas.RasDeviceType.Vpn));

            return entry;
        }

    public void loadOptions(RasEntry entry)
        {

            entry.Options.UsePreSharedKey = true;
            entry.Options.CacheCredentials = true;

            return;
        }

    public void setCredentials(RasEntry entry, System.Net.NetworkCredential credentials)                                        //We updaten de credentials.
        {

            entry.UpdateCredentials(credentials);

            return;
        }

    public void setPreSharedKey(RasEntry entry, string key)                                                                     //We updaten de presharedkey.
        {

            entry.UpdateCredentials(RasPreSharedKey.Client, key);

            return;
        }
    }
}
