using System;
using System.Collections.Generic;
using System.Text;

namespace RentalSystem
{
    public abstract class Vehicle
    {
        #region 1.构造函数
        public Vehicle()
        {
        }
        public Vehicle(string color,double dailyRent,string licenseNo,string name,int rentDate,string rentUser,int yearsOfService)
        {
            this.Color = color;
            this.DialyRent = dailyRent;
            this.LicenseNO = licenseNo;
            this.Name = name;
            this.RentDate = rentDate;
            this.RentUser = rentUser;
            this.YearsOfService = yearsOfService;
        }
        #endregion

        #region 2.字段和属性
        private string color;
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        private double dialyRent;
        /// <summary>
        /// 租金
        /// </summary>
        public double DialyRent
        {
            get { return dialyRent; }
            set { dialyRent = value; }
        }
        private string licenseNO;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicenseNO
        {
            get { return licenseNO; }
            set { licenseNO = value; }
        }
        private string name;
        /// <summary>
        /// 车名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int rentDate;
        /// <summary>
        /// 租用天数
        /// </summary>
        public int RentDate
        {
            get { return rentDate; }
            set { rentDate = value; }
        }
        private string rentUser;
        /// <summary>
        /// 租用者
        /// </summary>
        public string RentUser
        {
            get { return rentUser; }
            set { rentUser = value; }
        }
        private int yearsOfService;
        /// <summary>
        /// 使用时间
        /// </summary>
        public int YearsOfService
        {
            get { return yearsOfService; }
            set { yearsOfService = value; }
        }
        #endregion

        #region 3.抽象方法
        public abstract double CalcPrice();
        #endregion
    }
}
