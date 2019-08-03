using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SalesInvoiceGenerator
{
    class dataInfo
    {
        private static int newFile;
        private static String companyName;
        private static String address1;
        private static String city;
        private static String state;
        private static String zip;
        private static String phone;
        private static int serial;

        public static void loadDataInfo()
        {
            String[] read = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\config.txt");
            newFile = Int32.Parse(read[0].Split('=').Last());
            companyName = read[1].Split('=').Last();
            address1 = read[2].Split('=').Last();
            city = read[3].Split('=').Last();
            state = read[4].Split('=').Last();
            zip = read[5].Split('=').Last();
            phone = read[6].Split('=').Last();
            serial = Int32.Parse(read[7].Split('=').Last());
        }

        public static void saveDataInfo()
        {
            String dataIn = "";
            dataIn += "newFile=" + newFile + "\n";
            dataIn += "companyName=" + companyName + "\n";
            dataIn += "address1=" + address1 + "\n";
            dataIn += "city=" + city + "\n";
            dataIn += "state=" + state + "\n";
            dataIn += "zip=" + zip + "\n";
            dataIn += "phone=" + phone + "\n";
            dataIn += "serial=" + serial;

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\config.txt", dataIn);
           

        }

        public static int NewFile
        {
            get
            {
                return newFile;
            }

            set
            {
                newFile = value;
            }
        }

        public static string CompanyName
        {
            get
            {
                return companyName;
            }

            set
            {
                companyName = value;
            }
        }

        public static string Address1
        {
            get
            {
                return address1;
            }

            set
            {
                address1 = value;
            }
        }

        public static string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public static string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public static string Zip
        {
            get
            {
                return zip;
            }

            set
            {
                zip = value;
            }
        }

        public static string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public static int Serial
        {
            get
            {
                return serial;
            }

            set
            {
                serial = value;
            }
        }
    }
}
