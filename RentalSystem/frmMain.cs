using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RentalSystem
{
    public partial class frmMain : Form
    {
        //可租用车信息
        Dictionary<string, Vehicle> vehicles;

        //结算车集合集息
        Dictionary<string, Vehicle> rentVehicles;

        /// <summary>
        /// 初始化车量信息
        /// </summary>
        private void Initial()
        {
            vehicles = new Dictionary<string, Vehicle>();
            Car car1 = new Car("黑色", 888, "黑A88888", "奥迪A9", 0, "", 1);
            Car car2 = new Car("白色", 999, "黑B88888", "奥迪A10", 0, "", 1);
            Truck car3 = new Truck("红色", 1000, "黑C88888", "奥迪A11", 0, "", 1,300);
            vehicles.Add(car1.LicenseNO, car1);
            vehicles.Add(car2.LicenseNO, car2);
            vehicles.Add(car3.LicenseNO, car3);

            //循环显示数据
            foreach (Vehicle v in vehicles.Values)
            {
                if (v is Car)
                {
                    Car car = v as Car;
                    ListViewItem lv = new ListViewItem(car.LicenseNO);
                    lv.SubItems.AddRange(new string[] { car.Name.ToString(), car.Color.ToString(),car.YearsOfService.ToString(),car.DialyRent.ToString() ,"无" });
                    lvRent.Items.Add(lv);
                }
                if (v is Truck)
                {
                    Truck truck = v as Truck;
                    ListViewItem lv = new ListViewItem(truck.LicenseNO);
                    lv.SubItems.AddRange(new string[] { truck.Name.ToString(), truck.Color.ToString(), truck.YearsOfService.ToString(), truck.DialyRent.ToString(), truck.Load.ToString()});
                    lvRent.Items.Add(lv);
                }
            }

            rentVehicles = new Dictionary<string, Vehicle>();
            Car rcar2 = new Car("白色", 999, "黑B888881", "奥迪A10", 0, "", 1);
            Truck rcar3 = new Truck("红色", 1000, "黑C888881", "奥迪A11", 0, "", 1, 300);
            rentVehicles.Add(rcar2.LicenseNO, rcar2);
            rentVehicles.Add(rcar3.LicenseNO, rcar3);
            //循环显示数据
            foreach (Vehicle v in rentVehicles.Values)
            {
                if (v is Car)
                {
                    Car car = v as Car;
                    ListViewItem lv = new ListViewItem(car.LicenseNO);
                    lv.SubItems.AddRange(new string[]{ car.Name.ToString(), car.Color.ToString(),car.YearsOfService.ToString(),car.DialyRent.ToString() ,"无" });
                    lvReturn.Items.Add(lv);
                }
                if (v is Truck)
                {
                    Truck truck = v as Truck;
                    ListViewItem lv = new ListViewItem(truck.LicenseNO);
                    lv.SubItems.AddRange(new string[] { truck.Name.ToString(), truck.Color.ToString(), truck.YearsOfService.ToString(), truck.DialyRent.ToString(), truck.Load.ToString() });
                    lvReturn.Items.Add(lv);
                }
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 程序退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTuiChu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            Initial();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string key = lvRent.SelectedItems[0].Text;
            vehicles[key].RentUser = this.txtRenter.Text;
            rentVehicles.Add(vehicles[key].LicenseNO, vehicles[key]);
            if (vehicles.ContainsKey(key))
            {
                vehicles.Remove(key);
            }
            PrintVehicles(vehicles, lvRent);
            PrintVehicles(rentVehicles,lvReturn);
        }
        public void PrintVehicles(Dictionary<string, Vehicle> vehicles, ListView lvRent)
        {
            lvRent.Items.Clear();
            //循环显示数据
            foreach (Vehicle v in vehicles.Values)
            {
                if (v is Car)
                {
                    Car car = v as Car;
                    ListViewItem lv = new ListViewItem(car.LicenseNO);
                    lv.SubItems.AddRange(new string[] { car.Name.ToString(), car.Color.ToString(), car.YearsOfService.ToString(), car.DialyRent.ToString(), "无" });
                    lvRent.Items.Add(lv);
                }
                if (v is Truck)
                {
                    Truck truck = v as Truck;
                    ListViewItem lv = new ListViewItem(truck.LicenseNO);
                    lv.SubItems.AddRange(new string[] { truck.Name.ToString(), truck.Color.ToString(), truck.YearsOfService.ToString(), truck.DialyRent.ToString(), truck.Load.ToString() });
                    lvRent.Items.Add(lv);
                }
            }
        }
        /// <summary>
        /// 选择结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string strDate = txtRentDate.Text;
            if (strDate.Equals(""))
            {
                MessageBox.Show("请输入租车天数","提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            string key = lvReturn.SelectedItems[0].Text;
            rentVehicles[key].RentDate = int.Parse(this.txtRentDate.Text);
            //调用抽象方法
            double totalPrice = rentVehicles[key].CalcPrice();
            string msg = string.Format("您的总价是{0}。",totalPrice);
            MessageBox.Show(msg, "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //加入到可租车辆集合
            vehicles.Add(rentVehicles[key].LicenseNO, rentVehicles[key]);
            //还车后从已租车辆集合中移除
            if (rentVehicles.ContainsKey(key))
            {
                rentVehicles.Remove(key);
            }
            this.PrintVehicles(rentVehicles, lvReturn);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.PrintVehicles(vehicles, lvRent);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.PrintVehicles(rentVehicles, lvReturn);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Enabled = false;
            textBox7.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string strType = "";//车类型
            if (radioButton1.Checked == true)
            {
                strType = "car";
            }
            else
            {
                strType = "truck";
            }
            string strLicenseNo = textBox3.Text;
            if (strLicenseNo.Equals(""))
            {
                MessageBox.Show("请输入车牌号!");
                return;
            }
            string strName = textBox4.Text;
            if (strName.Equals(""))
            {
                MessageBox.Show("请输入车型!");
                return;
            }
            string strColor = comboBox1.Text;
            if (strColor.Equals(""))
            {
                MessageBox.Show("请输入颜色!");
                return;
            }
            string strYearsOfService = textBox5.Text;
            if (strYearsOfService.Equals(""))
            {
                MessageBox.Show("请输入使用时间!");
                return;
            }
            string strDailyRent = textBox6.Text;
            if (strDailyRent.Equals(""))
            {
                MessageBox.Show("请输入每日租金!");
                return;
            }
            string strLoad = "";
            if (radioButton1.Checked == true)
            {
                strLoad = "0";
            }
            else
            {
                strLoad = textBox7.Text;
            }

            Vehicle vehicle = VehicelUtil.CreateVehicle(
                strLicenseNo, strName, strColor, 
                int.Parse(strYearsOfService), double.Parse(strDailyRent), 
                int.Parse(strLoad), strType);
            //将新车添加到入库中
            if (vehicles.ContainsKey(vehicle.LicenseNO))
            {
                MessageBox.Show("此车量已入库!");
                return;
            }
            else
            {
                vehicles.Add(vehicle.LicenseNO, vehicle);
                MessageBox.Show("入库成功!");
                PrintVehicles(vehicles, lvRent);
            }
        }
    
    }
}
