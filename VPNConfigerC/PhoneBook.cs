using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotRas;

namespace VPNConfigerC
{
    class PhoneBook
    {
        RasPhoneBook pbook = new RasPhoneBook();                                                        //pbook staat voor: "phonebook".

        public void openPhoneBook()
        {

            pbook.Open();

        }


        public void addEntry(RasEntry vpnentry)
        {

            pbook.Entries.Add(vpnentry);

        }

        public void removeEntry(RasEntry vpnentry)
        {

            pbook.Entries.Remove(vpnentry);

        }
       
        public bool contains(string vpnname)
        {

            if (pbook.Entries.Contains(vpnname))
            {

                return true;

            }

            else

            {


                return false;

            }
            
        }

        public RasEntry getEntry()
        {
            RasEntry entry = pbook.Entries.FirstOrDefault(e => e.Name.Equals("VPN"));                           //We returnen de aangemaakte entry genaamd "Transip". Zie 'vpnname' in de main-code(form2).

            return entry;
        }
            
     }

 }

