using System;
using System.Collections.Generic;
using System.Text;

namespace RentalSystem
{
    public class Truck:Vehicle
    {
        public Truck(string color, double dailyRent, string licenseNo, string name, int rentDate, string rentUser, int yearsOfService,int load)
            : base(color, dailyRent, licenseNo, name, rentDate, rentUser, yearsOfService)
        {
            this.Load = load;
        }
        private int load;
        /// <summary>
        /// 卡车载重
        /// </summary>
        public int Load
        {
            get { return load; }
            set { load = value; }
        }

        //alt+shift+F10+Enter

        /// <summary>
        /// 重写租用计算方法
        /// </summary>
        /// <returns></returns>
        public override double CalcPrice()
        {
            this.DialyRent = this.RentDate * this.DialyRent + Load;
            return this.DialyRent;
        }
    }
}
