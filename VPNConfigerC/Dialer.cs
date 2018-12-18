using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotRas;
using System.Windows.Forms;

namespace VPNConfigerC
{
    class Dialer
    {

        public RasDialer createDialer()
        {

            RasDialer dialer = new RasDialer();
            return dialer;
        }

        public void setEntryName(RasDialer dialer, string entryname)
        {

            dialer.EntryName = entryname;                                                                                   //We setten de naam van de opgegeven dialer.

            return;                                            
        }

        public void setPhoneBookPath(RasDialer dialer)
        {

            dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);

            return;         
        }

        public void setCredentials(RasDialer dialer, System.Net.NetworkCredential credentials)
        {
            dialer.Credentials = credentials;

            return;
        }

        public void setTimeout(RasDialer dialer, int timeout)
        {
            dialer.Timeout = timeout;

            return;
        }

        public RasHandle Dial(RasDialer dialer)
        {
            RasHandle handler = dialer.DialAsync();

            return handler;
        }

        public bool hangup(RasDialer dialer, RasConnection connection)
        {
            if (dialer.IsBusy)
            {
                dialer.DialAsyncCancel();

                return true;

            }else
            {
                if(connection != null)
                {
                    connection.HangUp();                                                                                        //We sluiten de verbinding

                    return true;
                }
            }

            return false;
        }

        public bool checkIfConnectionExist(RasConnection connection)                                                            //We controleren of er al een connectie bestaat.
        {
            if (connection != null)
            {

                return true;
            }
            else
            {

                return false;
            }
        }

        public void connectionState(NotifyTray trayIcon, NotifyIcon notify, RasConnectionWatcher watcher, RasHandle handle, Form mainform)
        {

            watcher.Handle = handle;

            /*watcher.Connected += (sender, e) =>
            {
                trayIcon.showBalloon(notifyIcon, "Uw privacy is nu beschermt!", "Mocht de verbinding met onze server om onbekende redenen opeens beëindigen, dan krijgt u via deze weg een melding, zodat u opnieuw kunt verbinden.");
            };*/

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //BAD PRACTICE:////////////////////////////////////////////////////////////////////////////BAD PRACTICE//////////////////////////////////////////////////////////////////////////////////BAD PRACTICE//
            //BELOW:///////////////////////////////////////////////////////////////////////////////////BELOW:////////////////////////////////////////////////////////////////////////////////////////BELOW:///////

            watcher.Disconnected += (sender, e) =>
            {
                mainform.Show();
                mainform.WindowState = FormWindowState.Normal;

                //trayIcon.showBalloon(notify, "Uw privacy is NIET meer beschermt!", "De verbinding met de server is zojuist verbroken! Maak opnieuw verbinding. (eenmaal klikken op het icoon rechts onderin om de software te openen of rechtermuisknop en kies uit het menu 'verbinden'.)");
                f_Vpnconfiger.lStatusstate.Text = "Not active";
                f_Vpnconfiger.lStatusstate.BackColor = System.Drawing.Color.Red;
                f_Vpnconfiger.tKey.Enabled = true;
                f_Vpnconfiger.tUsername.Enabled = true;
                f_Vpnconfiger.tPassword.Enabled = true;
                f_Vpnconfiger.bConnect.Enabled = true;
                f_Vpnconfiger.bDisconnect.Enabled = false;
                f_Vpnconfiger.bReset.Enabled = true;
                f_Vpnconfiger.connectItem.Enabled = true;
                f_Vpnconfiger.disconnectItem.Enabled = false;
                f_Vpnconfiger.exitItem.Enabled = true;

                mainform.Show();
                mainform.WindowState = FormWindowState.Normal;

            };

            watcher.Connected += (sender, e) =>
            {
                f_Vpnconfiger.connection = RasConnection.GetActiveConnectionByHandle(handle);                       //Update de connectiestatus.
                f_Vpnconfiger.lStatusstate.Text = "Active";
                f_Vpnconfiger.lStatusstate.BackColor = System.Drawing.Color.Green;
                f_Vpnconfiger.tKey.Enabled = false;
                f_Vpnconfiger.tUsername.Enabled = false;
                f_Vpnconfiger.tPassword.Enabled = false;
                f_Vpnconfiger.bConnect.Enabled = false;
                f_Vpnconfiger.bDisconnect.Enabled = true;
                f_Vpnconfiger.bReset.Enabled = false;
                f_Vpnconfiger.connectItem.Enabled = false;
                f_Vpnconfiger.disconnectItem.Enabled = true;
                f_Vpnconfiger.exitItem.Enabled = false;
            };

                watcher.EnableRaisingEvents = true;
        }
    }
}
