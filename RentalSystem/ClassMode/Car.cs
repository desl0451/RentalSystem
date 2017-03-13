using System;
using System.Collections.Generic;
using System.Text;

namespace RentalSystem
{
    public class Car : Vehicle
    {
        public Car(string color, double dailyRent, string licenseNo, string name, int rentDate, string rentUser, int yearsOfService)
            : base(color, dailyRent, licenseNo, name, rentDate, rentUser, yearsOfService)
        {
        }
        /// <summary>
        /// 重写小汽车租金计算方法
        /// </summary>
        /// <returns></returns>
        public override double CalcPrice()
        {
            this.DialyRent = this.RentDate * this.DialyRent;
            return this.DialyRent;
        }
    }
}
