using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInvoiceGenerator
{
    class CustomerInfo
    {
        private static String customerName;
        private static String address1;
        private static String address2;
        private static String cityStateZip;
        private static String subTotal;
        private static String tax;
        private static String totalDue;
        private static String notes;

        private static List<String> item;
        private static List<String> desc;
        private static List<String> unit;
        private static List<String> qty;
        private static List<String> total;


        public static void initLists()
        {
            item = new List<String>();
            desc = new List<String>();
            unit = new List<String>();
            qty = new List<String>();
            total = new List<String>();

        }

    public static string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
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

        public static string Address2
        {
            get
            {
                return address2;
            }

            set
            {
                address2 = value;
            }
        }

        public static string CityStateZip
        {
            get
            {
                return cityStateZip;
            }

            set
            {
                cityStateZip = value;
            }
        }

        public static string SubTotal
        {
            get
            {
                return subTotal;
            }

            set
            {
                subTotal = "PhP " + value;
            }
        }

        public static string Tax
        {
            get
            {
                return tax;
            }

            set
            {
                tax = value + "%";
            }
        }

        public static string TotalDue
        {
            get
            {
                return totalDue;
            }

            set
            {
                totalDue = "PhP " + value;
            }
        }

        public static List<string> Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        public static List<string> Desc
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
            }
        }

        public static List<string> Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }

        public static List<string> Qty
        {
            get
            {
                return qty;
            }

            set
            {
                qty = value;
            }
        }

        public static List<string> Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public static string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }
    }
}
