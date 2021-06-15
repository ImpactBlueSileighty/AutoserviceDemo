using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoserviceDemo.Model.EF
{
    public partial class Service
    {
        public string CostFormat
        {
            get
            {
                if (Discount != 0)
                {
                    return Convert.ToDouble(Cost) * (1 - Discount) + " рублей";
                }
                else
                {
                    return (Int32)Cost + " рублей";
                }
            }
        }

        public string CostStrikethrough
        {
            get
            {
                if (Discount != 0)
                {
                    return Convert.ToInt32(Cost).ToString() + " ";
                }
                else
                {
                    return null;
                }
            }
        }

        public string DateFormat 
        {
            get
            {
                return DurationInSeconds / 60 + " минут";
            }
        }

        public string DiscountFormat 
        {
            get
            {
                if(Discount != 0)
                {
                    return "*скидка " + Discount * 100 + "%";
                }else 
                {
                    return null;
                }
                
            }
        }
    }
}
