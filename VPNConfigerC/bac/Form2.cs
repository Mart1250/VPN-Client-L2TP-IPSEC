using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using DotRas;
using Microsoft.Win32;
using System.Diagnostics;

namespace VPNConfigerC                                                                      //https://msdn.microsoft.com/en-us/library/ms182532.aspx handig.
{



    public partial class f_Vpnconfiger : Form
    {

        public string Vpnname = "VPN";
        public string Destination;
        public string Presharedkey;                                                                                 //"7cd882a3ea03ded5c377d7e2b4797d149636917f8b52238113b16966b7c5";   
        public string Presharedkeybox;
        public string Username;
        public string Usernamebox;
        public string Password;                                                                                          
        public string Passwordbox;

        Config appconfig = new Config();
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("", "");
        PhoneBook book = new PhoneBook();                                                                           //We maken een nieuw telefoonboek aan.
        RasDialer dialer = new Dialer().createDialer();                                                             //We maken een nieuw telefoonboek aan.
        Dialer dialerclass = new Dialer();                                                                          //We maken een nieuwe dialer aan.
        public static RasConnection connection = null;
        RasHandle connectionHandler;
        RasConnectionWatcher watcher = new RasConnectionWatcher();
        NotifyTray tray = new NotifyTray();
        ContextMenu trayMenu = new System.Windows.Forms.ContextMenu();                                              //Het trayMenu

        MenuItem openItem = new System.Windows.Forms.MenuItem();
        public static MenuItem connectItem = new System.Windows.Forms.MenuItem();                                                 //De connect button van het trayMenu.
        public static MenuItem disconnectItem = new System.Windows.Forms.MenuItem();                                              //De disconnect button van het trayMenu.
        public static MenuItem exitItem = new System.Windows.Forms.MenuItem();                                                    //De afsluit button van het trayMenu.

        Xml xml = new Xml();

        List<string> Serverlocation = new List<string>();


        public f_Vpnconfiger()
        {
            InitializeComponent();
            Presharedkey = appconfig.readAppSetting("presharedkey");
            Username = appconfig.readAppSetting("username");
            Password = appconfig.readAppSetting("password");
            lLocationname.Text = appconfig.readAppSetting("serverlocation");

            notify.Icon = SystemIcons.Application;                                                                  //We stellen het icoontje van de 'tray' in.

            //dialerclass.connectionState(tray, notify, watcher, connectionHandler);                                  //Dit zorgt er voor dat er een balonmelding komt als de verbinding is verbroken met de server.

            trayMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.openItem, f_Vpnconfiger.exitItem, f_Vpnconfiger.disconnectItem, f_Vpnconfiger.connectItem });


            this.openItem.Index = 0;
            this.openItem.Text = "O&pen";
            this.openItem.Click += new System.EventHandler(this.openItem_Click);

            f_Vpnconfiger.connectItem.Index = 1;
            f_Vpnconfiger.connectItem.Text = "C&onnect";
            f_Vpnconfiger.connectItem.Click += new System.EventHandler(this.connectItem_Click);

            f_Vpnconfiger.disconnectItem.Index = 2;
            f_Vpnconfiger.disconnectItem.Text = "D&isconnect";
            f_Vpnconfiger.disconnectItem.Click += new System.EventHandler(this.disconnectItem_Click);

            f_Vpnconfiger.exitItem.Index = 3;
            f_Vpnconfiger.exitItem.Text = "E&xit";
            f_Vpnconfiger.exitItem.Click += new System.EventHandler(this.exitItem_Click);

            notify.ContextMenu = this.trayMenu;

        }

        public void bConnect_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////
            //List<string> list = xml.readXML("Servers");

            //foreach (string childnode in list)
            //{
            //    MessageBox.Show(childnode);
            //}////////////////////////////////////////////////////////

            Presharedkeybox = tKey.Text;
            Usernamebox = tUsername.Text;
            Passwordbox = tPassword.Text;

            if ((Presharedkeybox != Presharedkey) || (Usernamebox != Username) || (Passwordbox != Password))
            {
                appconfig.setAppSetting("presharedkey", Presharedkeybox);                                                    //We slaan alle ingevoerde gegevens op in de config file.
                appconfig.setAppSetting("username", Usernamebox);                                                 //We slaan alle ingevoerde gegevens op in de config file.
                appconfig.setAppSetting("password", Passwordbox);                                                     //We slaan alle ingevoerde gegevens op in de config file.
                Presharedkey = Presharedkeybox;
                Username = Usernamebox;
                Password = Passwordbox;
            }

            credentials = new System.Net.NetworkCredential(Usernamebox, Passwordbox);

            dialerclass.setEntryName(dialer, Vpnname);
            dialerclass.setPhoneBookPath(dialer);
            dialerclass.setCredentials(dialer, credentials);
            dialerclass.setTimeout(dialer, 1000);

            book.openPhoneBook();                                                                                       //We openen het zojuist aangemaakte telefoonboek.    


            if (book.contains(Vpnname))                                                                                 //We checken of de naam van de entry al in het telefoonboek voorkomt.
            {
                VpnEntry vpnentryclass = new VpnEntry();
                RasEntry vpnentry = book.getEntry();

                vpnentryclass.setCredentials(vpnentry, credentials);
                vpnentryclass.setPreSharedKey(vpnentry, Presharedkeybox);

                //MessageBox.Show("Er bestaat al een connectie met dezelfde naam.");

                try
                {

                    connectionHandler = dialerclass.Dial(dialer);                                                       //LETOP OF DIT WERKT.     //We proberen de verbinding tot stand te brengen.


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

                System.Threading.Thread.Sleep(1500);

                connection = RasConnection.GetActiveConnectionByHandle(connectionHandler);

                if (dialerclass.checkIfConnectionExist(connection))
                {
                    lStatusstate.Text = "Active";
                    lStatusstate.BackColor = System.Drawing.Color.Green;
                    bConnect.Enabled = false;                                                                           //We disabelen de Disconect button.
                    bDisconnect.Enabled = true;                                                                         //We enabelen de Disconect button.
                    bReset.Enabled = false;                                                                              
                    tKey.Enabled = false;
                    tUsername.Enabled = false;
                    tPassword.Enabled = false;
                    connectItem.Enabled = false;
                    disconnectItem.Enabled = true;
                    exitItem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Failed to establish a connection, sometimes the connection is not established immediately. Try again. Are you sure that the data entered is correct?", "Failed to connect");
                }

            }
            else
            {
                List<string> list = xml.readXML("Servers", Serverlocation);

                int randomvalue = xml.randomValue(list);

                Destination = xml.randomValueFromList(list, randomvalue);

                lLocationname.Text = Serverlocation.ElementAt(randomvalue);

                appconfig.setAppSetting("serverlocation", Serverlocation.ElementAt(randomvalue));

                Presharedkeybox = tKey.Text;
                Usernamebox = tUsername.Text;
                Passwordbox = tPassword.Text;
                credentials = new System.Net.NetworkCredential(Usernamebox, Passwordbox);

                VpnEntry vpnentryclass = new VpnEntry();                                                                    //We maken een nieuwe entry class aan.
                RasEntry vpnentry = new VpnEntry().createEntry(Vpnname, Destination);                                     //We maken een entry aan met de gewenste  gegevens.
                              
                vpnentryclass.loadOptions(vpnentry);                                                                        //We laten bepaalde opties in voor een specifieke 'vpnentry'.
                book.addEntry(vpnentry);                                                                                    //We voegen de entry toe aan het telefoonboek. (DIT MOET ALTIJD NA DE LOADOPTIONS).

                vpnentryclass.setCredentials(vpnentry, credentials);
                vpnentryclass.setPreSharedKey(vpnentry, Presharedkeybox);

                dialerclass.setEntryName(dialer, Vpnname);
                dialerclass.setPhoneBookPath(dialer);
                dialerclass.setCredentials(dialer, credentials);
                dialerclass.setTimeout(dialer, 1500);                                                                                                                                                                
                
                try
                {

                    connectionHandler = dialerclass.Dial(dialer);                                                            //LETOP OF DIT WERKT.     //We proberen de verbinding tot stand te brengen.

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

                System.Threading.Thread.Sleep(3500);

                connection = RasConnection.GetActiveConnectionByHandle(connectionHandler);

                if (dialerclass.checkIfConnectionExist(connection))
                {
                    lStatusstate.Text = "Active";
                    lStatusstate.BackColor = System.Drawing.Color.Green;
                    bConnect.Enabled = false;                                                                               //We disabelen de Connect button.
                    bDisconnect.Enabled = true;                                                                             //We enabelen de Disconect button.
                    bReset.Enabled = false;                                                                                 
                    tKey.Enabled = false;
                    tUsername.Enabled = false;
                    tPassword.Enabled = false;
                    connectItem.Enabled = false;
                    disconnectItem.Enabled = true;
                    exitItem.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Failed to establish a connection. The most likely reason is that the information you entered is incorrect. If you are sure that these are correct, click on 'connect' again, sometimes the connection will not be established immediately.", "Connection failed");
                }

            }
            
        }

        public void bDisconnect_Click(object sender, EventArgs e)
        {

            //connection = RasConnection.GetActiveConnectionByHandle(connectionHandler);

            if (dialerclass.hangup(dialer, connection)){
                lStatusstate.Text = "Not active";
                lStatusstate.BackColor = System.Drawing.Color.Red;
                bConnect.Enabled = true;
                bDisconnect.Enabled = false;
                bReset.Enabled = true;
                tKey.Enabled = true;
                tUsername.Enabled = true;
                tPassword.Enabled = true;
                connectItem.Enabled = true;
                disconnectItem.Enabled = false;
                exitItem.Enabled = true;
            }

        }

        private void f_Vpnconfiger_Load(object sender, EventArgs e)                                                         //Bij het laden van het programma. Hier wordt onder andere gecheckt
        {                                                                                                                   //wat er in de config file staat en vult die gegevens in in de textboxen.
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                MessageBox.Show("The vpnclient is already active! Open the application via the system tray (icon at the bottom right).");
                this.Close();
            }

            tKey.Text = Presharedkey;
            tUsername.Text = Username;
            tPassword.Text = Password;

            book.openPhoneBook();

            if (book.contains(Vpnname))
            {

                dialerclass.setEntryName(dialer, Vpnname);
                dialerclass.setPhoneBookPath(dialer);
                dialerclass.setCredentials(dialer, credentials);
                dialerclass.setTimeout(dialer, 1000);
                connectionHandler = dialerclass.Dial(dialer);

                connection = RasConnection.GetActiveConnectionByHandle(connectionHandler);                                    //vult de variabel 'connection' met een RasConnection als er een connectie actief is.
                dialerclass.connectionState(tray, notify, watcher, connectionHandler, this);                                    //Dit zorgt er voor dat er een balonmelding komt als de verbinding is verbroken met de server.                                                                                                                

                if (dialerclass.checkIfConnectionExist(connection) == true)                                                   //Als er een connectie is worden de buttons, labels en textboxes geënabled/gedisabeld.
                {
                    lStatusstate.Text = "Active";
                    lStatusstate.BackColor = System.Drawing.Color.Green;
                    bConnect.Enabled = false;
                    bDisconnect.Enabled = true;
                    bReset.Enabled = false;
                    tKey.Enabled = false;
                    tUsername.Enabled = false;
                    tPassword.Enabled = false;
                    connectItem.Enabled = false;
                    disconnectItem.Enabled = true;
                    exitItem.Enabled = false;
                }
                else                                                                                                           //Zo niet dan gebeurt het tegenovergestelde met de buttons, labels en tekxtboxes.
                {
                    lStatusstate.Text = "Not active";
                    lStatusstate.BackColor = System.Drawing.Color.Red;
                    bConnect.Enabled = true;
                    bDisconnect.Enabled = false;
                    bReset.Enabled = true;
                    tKey.Enabled = true;
                    tUsername.Enabled = true;
                    tPassword.Enabled = true;
                    connectItem.Enabled = true;
                    disconnectItem.Enabled = false;
                    exitItem.Enabled = true;
                }
                
            }else
            {
                bConnect.Enabled = true;
                bDisconnect.Enabled = false;
            }

        }

        private void bReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Only use this button if the connection has not been established after 5 or more attempts. If so, click on 'Yes'. If not, then on 'No'.", "Reset?", MessageBoxButtons.YesNo);

            book.openPhoneBook();

            if (dialogResult == DialogResult.Yes)
            {
                if (book.contains(Vpnname))
                {

                    book.removeEntry(book.getEntry());
                    appconfig.setAppSetting("serverlocation", "");
                    lLocationname.Text = "";

                    MessageBox.Show("The reset has been successfully completed!", "Successful");

                }else
                {

                    MessageBox.Show("You have already reset the vpnclient or you have never made a connection.", "Resetting failed");

                }
            }
        }

        public void Form_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
                MessageBox.Show("" + this.WindowState);
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                this.Hide();
                MessageBox.Show("" + this.WindowState);
                notify.Visible = false;
            }
        }

        private void f_Vpnconfiger_Resize_1(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
                notify.Visible = true;
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                this.Show();
                notify.Visible = false;
            }
        }
/*
        private void f_Vpnconfiger_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                notify.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }*/

        private void notify_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void connectItem_Click(object sender, EventArgs e)
        {

            Presharedkeybox = tKey.Text;
            Usernamebox = tUsername.Text;
            Passwordbox = tPassword.Text;

            if ((Presharedkeybox != Presharedkey) || (Usernamebox != Username) || (Passwordbox != Password))
            {
                appconfig.setAppSetting("sleutel", Presharedkeybox);                                                    //We slaan alle ingevoerde gegevens op in de config file.
                appconfig.setAppSetting("gebruikersnaam", Usernamebox);                                                 //We slaan alle ingevoerde gegevens op in de config file.
                appconfig.setAppSetting("wachtwoord", Passwordbox);                                                     //We slaan alle ingevoerde gegevens op in de config file.
                Presharedkey = Presharedkeybox;
                Username = Usernamebox;
                Password = Passwordbox;
            }

            credentials = new System.Net.NetworkCredential(Usernamebox, Passwordbox);

            dialerclass.setEntryName(dialer, Vpnname);
            dialerclass.setPhoneBookPath(dialer);
            dialerclass.setCredentials(dialer, credentials);
            dialerclass.setTimeout(dialer, 1000);

            book.openPhoneBook();                                                                                       //We openen het zojuist aangemaakte telefoonboek.    


            if (book.contains(Vpnname))                                                                                 //We checken of de naam van de entry al in het telefoonboek voorkomt.
            {
                VpnEntry vpnentryclass = new VpnEntry();
                RasEntry vpnentry = book.getEntry();

                vpnentryclass.setCredentials(vpnentry, credentials);
                vpnentryclass.setPreSharedKey(vpnentry, Presharedkeybox);

                //MessageBox.Show("Er bestaat al een connectie met dezelfde naam.");

                try
                {

                    connectionHandler = dialerclass.Dial(dialer);                                                       //LETOP OF DIT WERKT.     //We proberen de verbinding tot stand te brengen.


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

                System.Threading.Thread.Sleep(1500);

                connection = RasConnection.GetActiveConnectionByHandle(connectionHandler);

                if (dialerclass.checkIfConnectionExist(connection))
                {
                    lStatusstate.Text = "Active";
                    lStatusstate.BackColor = System.Drawing.Color.Green;
                    bConnect.Enabled = false;                                                                           //We disabelen de Disconect button.
                    bDisconnect.Enabled = true;                                                                         //We enabelen de Disconect button.
                    bReset.Enabled = false;
                    tKey.Enabled = false;
                    tUsername.Enabled = false;
                    tPassword.Enabled = false;
                    connectItem.Enabled = false;
                    disconnectItem.Enabled = true;
                    exitItem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Failed to establish a connection, sometimes the connection is not established immediately. Try again. Are you sure that the data entered is correct?", "Failed to connect");
                }

            }
            else
            {
                List<string> list = xml.readXML("Servers", Serverlocation);

                int randomvalue = xml.randomValue(list);

                Destination = xml.randomValueFromList(list, randomvalue);

                lLocationname.Text = Serverlocation.ElementAt(randomvalue);

                appconfig.setAppSetting("serverlocation", Serverlocation.ElementAt(randomvalue));

                Presharedkeybox = tKey.Text;
                Usernamebox = tUsername.Text;
                Passwordbox = tPassword.Text;
                credentials = new System.Net.NetworkCredential(Usernamebox, Passwordbox);

                VpnEntry vpnentryclass = new VpnEntry();                                                                    //We maken een nieuwe entry class aan.
                RasEntry vpnentry = new VpnEntry().createEntry(Vpnname, Destination);                                       //We maken een entry aan met de gewenste  gegevens.

                vpnentryclass.loadOptions(vpnentry);                                                                        //We laten bepaalde opties in voor een specifieke 'vpnentry'.
                book.addEntry(vpnentry);                                                                                    //We voegen de entry toe aan het telefoonboek. (DIT MOET ALTIJD NA DE LOADOPTIONS).

                vpnentryclass.setCredentials(vpnentry, credentials);
                vpnentryclass.setPreSharedKey(vpnentry, Presharedkeybox);

                dialerclass.setEntryName(dialer, Vpnname);
                dialerclass.setPhoneBookPath(dialer);
                dialerclass.setCredentials(dialer, credentials);
                dialerclass.setTimeout(dialer, 1500);

                try
                {

                    connectionHandler = dialerclass.Dial(dialer);                                                            //LETOP OF DIT WERKT.     //We proberen de verbinding tot stand te brengen.

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

                System.Threading.Thread.Sleep(3500);

                connection = RasConnection.GetActiveConnectionByHandle(connectionHandler);

                if (dialerclass.checkIfConnectionExist(connection))
                {
                    lStatusstate.Text = "Active";
                    lStatusstate.BackColor = System.Drawing.Color.Green;
                    bConnect.Enabled = false;                                                                               //We disabelen de Connect button.
                    bDisconnect.Enabled = true;                                                                             //We enabelen de Disconect button.
                    bReset.Enabled = false;
                    tKey.Enabled = false;
                    tUsername.Enabled = false;
                    tPassword.Enabled = false;                   
                    connectItem.Enabled = false;
                    disconnectItem.Enabled = true;
                    exitItem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Failed to establish a connection. The most likely reason is that the information you entered is incorrect. If you are sure that these are correct, click on 'connect' again, sometimes the connection will not be established immediately", "Connection failed");
                }

            }

        }


        private void disconnectItem_Click(object sender, EventArgs e)
        {

            if (dialerclass.hangup(dialer, connection))
            {
                lStatusstate.Text = "Not active";
                lStatusstate.BackColor = System.Drawing.Color.Red;
                bConnect.Enabled = true;
                bDisconnect.Enabled = false;
                bReset.Enabled = true;
                tKey.Enabled = true;
                tUsername.Enabled = true;
                tPassword.Enabled = true;
                connectItem.Enabled = true;
                disconnectItem.Enabled = false;
                exitItem.Enabled = true;
            }

        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
