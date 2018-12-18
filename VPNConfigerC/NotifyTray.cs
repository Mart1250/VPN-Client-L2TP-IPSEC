using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPNConfigerC
{
    class NotifyTray
    {
        public void showBalloon(NotifyIcon notifyIcon, string title, string body) //Bij gebruik van deze functie wel een icoon instellen en hem visible maken.
        {

            if (title != null)
            {

                notifyIcon.BalloonTipTitle = title;
            }

            if (body != null)
            {
                notifyIcon.BalloonTipText = body;
            }

            notifyIcon.ShowBalloonTip(30000);
        }

    }
}
