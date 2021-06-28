using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace MornaLicensing
{
    public static class License
    {
       public static List<HardDrive> hdCollection = new List<HardDrive>();
        static License() //GetAllDiskDrives()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();
                hd.Model = wmi_HD["Model"].ToString();
                hd.InterfaceType = wmi_HD["InterfaceType"].ToString();
                hd.Caption = wmi_HD["Caption"].ToString();
                hd.DriveName = wmi_HD["Name"].ToString();
                hd.DriveSize = Convert.ToString(Convert.ToDouble(wmi_HD["Size"]) * 1e-9);

                hd.SerialNo = wmi_HD.GetPropertyValue("SerialNumber").ToString();//get the serailNumber of diskdrive

                hdCollection.Add(hd);
            }

        }
        
    }
}
