using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotRas;

namespace VPNConfigerC
{
    public partial class f_Vpnconfiger : Form
    {
        public string Vpnname = "Transip";
        public string Destination = "149.210.200.145";
        public string Presharedkey = "7cd882a3ea03ded5c377d7e2b4797d149636917f8b52238113b16966b7c5";

        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("mart", "welkom");
        PhoneBook book = new PhoneBook();                                                                               //We maken een nieuw telefoonboek aan.
        RasDialer dialer = new Dialer().createDialer();                                                             //We maken een nieuwe dialer aan.
        Dialer dialerclass = new Dialer();
        RasConnection connection = null;
        RasHandle connectionHandler;

        



        public f_Vpnconfiger()
        {
            InitializeComponent();
            bDisconnect.Enabled = false;
        }

        public void bConnect_Click(object sender, EventArgs e)
        {
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("mart", "welkom");
            PhoneBook book = new PhoneBook();                                                                               //We maken een nieuw telefoonboek aan.

            dialerclass.setEntryName(dialer, Vpnname);
            dialerclass.setPhoneBookPath(dialer);
            dialerclass.setCredentials(dialer, credentials);
            dialerclass.setTimeout(dialer, 1000);

            book.openPhoneBook();                                                                                           //We openen het zojuist aangemaakte telefoonboek.    

            if (book.contains(Vpnname))                                                                                     //We checken of de naam van de entry al in het telefoonboek voorkomt.
            {
            
                //MessageBox.Show("Er bestaat al een connectie met dezelfde naam.");

                try
                {

                    connectionHandler = dialerclass.Dial(dialer);                                                 //LETOP OF DIT WERKT.     //We proberen de verbinding tot stand te brengen.
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

                System.Threading.Thread.Sleep(1500);

                connection = RasConnection.GetActiveConnectionByHandle(connectionHandler);
                if (dialerclass.checkIfConnectionExist(connection))
                {
                    bDisconnect.Enabled = true;
                    bConnect.Enabled = false;
                    lStatusstate.Text = "Connected";
                }

            }
            else
            {
                VpnEntry vpnentryclass = new VpnEntry();                                                                    //We maken een nieuwe entry class aan.
                RasEntry vpnentry = new VpnEntry().createEntry("Transip", "149.210.200.145");                               //We maken een entry aan met de gewenste  gegevens.
                              
                vpnentryclass.loadOptions(vpnentry);                                                                        //We laten bepaalde opties in voor een specifieke 'vpnentry'.
                book.addEntry(vpnentry);                                                                                    //We voegen de entry toe aan het telefoonboek. (DIT MOET ALTIJD NA DE LOADOPTIONS).

                vpnentryclass.setCredentials(vpnentry, credentials);
                vpnentryclass.setPreSharedKey(vpnentry, Presharedkey);

                dialerclass.setEntryName(dialer, Vpnname);
                dialerclass.setPhoneBookPath(dialer);
                dialerclass.setCredentials(dialer, credentials);
                dialerclass.setTimeout(dialer, 1500);        
                                                                                                                                                   
                lStatusstate.Text = "Connected";         
                

                try
                {

                    connectionHandler = dialerclass.Dial(dialer);                                                            //LETOP OF DIT WERKT.     //We proberen de verbinding tot stand te brengen.

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

                System.Threading.Thread.Sleep(1500);

                connection = RasConnection.GetActiveConnectionByHandle(connectionHandler);

                if (dialerclass.checkIfConnectionExist(connection))
                {
                    bDisconnect.Enabled = true;                                                                                  //We enabelen de Disconect button.
                    bConnect.Enabled = false;                                                                                    //We disabelen de Connect button.
                    lStatusstate.Text = "Connected";
                }

            }
            
        }

        public void bDisconnect_Click(object sender, EventArgs e)
        {

            if (dialerclass.hangup(dialer, connection)){
                lStatusstate.Text = "Disconnected";
                bConnect.Enabled = true;
                bDisconnect.Enabled = false;
            }
        }

        private void f_Vpnconfiger_Load(object sender, EventArgs e)
        {

            book.openPhoneBook();

            if (book.contains(Vpnname))
            {
                dialerclass.setEntryName(dialer, Vpnname);
                dialerclass.setPhoneBookPath(dialer);
                dialerclass.setCredentials(dialer, credentials);
                dialerclass.setTimeout(dialer, 1000);
                connectionHandler = dialerclass.Dial(dialer);

                connection = RasConnection.GetActiveConnectionByHandle(connectionHandler);

                if (dialerclass.checkIfConnectionExist(connection) == true)
                {
                    lStatusstate.Text = "Connected";
                    bConnect.Enabled = false;
                    bDisconnect.Enabled = true;
                }
                else
                {
                    lStatusstate.Text = "Disconnected";
                    bConnect.Enabled = true;
                    bDisconnect.Enabled = false;
                }

            }
        }
    }
}
