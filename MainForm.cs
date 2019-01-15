using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System;
using System.Management;
using System.Windows.Forms;

namespace Device_Renamer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            /*
            foreach (var screen in Screen.AllScreens)
            {
                listBox1.Items.Add("Device Name: " + screen.DeviceName);
                listBox1.Items.Add("Bounds: " + screen.Bounds.ToString());
                listBox1.Items.Add("Type: " + screen.GetType().ToString());
                listBox1.Items.Add("Working Area: " + screen.WorkingArea.ToString());
                listBox1.Items.Add("Primary Screen: " + screen.Primary.ToString());
            }
            */
            
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("Select * from Win32_PnPSignedDriver");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {
                var FriendlyName = (string)obj["FriendlyName"] ?? "Unknown";
                var DeviceName = (string)obj["DeviceName"] ?? "Unknown";
                var Manufacturer = (string)obj["Manufacturer"] ?? "Unknown";
                var ClassGuid = (string)obj["ClassGuid"] ?? "Unknown";
                var DeviceClass = (string)obj["DeviceClass"] ?? "Unknown";
                // var groupNode = new TreeNode(DeviceClass);
                if (!treeView1.Nodes.ContainsKey(DeviceClass)) {
                    TreeNode classNode = new TreeNode(DeviceClass);
                    classNode.Name = DeviceClass;
                    treeView1.Nodes.Add(classNode);
                }
                // var index = treeView1.Nodes.IndexOfKey(DeviceClass);
                treeView1.Nodes[DeviceClass].Nodes.Add(new TreeNode(DeviceName));
            }


            /*
             * var q = WindowsMultiDisplayTools.QueryDisplays();
            foreach (var screen in q)
            {
                listBox1.Items.Add(screen.FriendlyName);
            }
            */
            /*
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_PnPSignedDriver WHERE ClassGuid = '{4d36e97d-e325-11ce-bfc1-08002be10318}'");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                   listBox1.Items.Add($"ClassGuid: {queryObj["ClassGuid"]}");
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save clicked");
        }

       /* public static void populateDevicesList()
        {

            devices = new List<DisplayDevice>();

            bool error = false;
            for (int devId = 0; !error; devId++)
            {
                try
                {
                    //setup the device structure...
                    DisplayDevice device = new DisplayDevice();
                    device.cb = Marshal.SizeOf(typeof(DisplayDevice));


                    //Commence enumeration
                    error = EnumDisplayDevices(null, devId, ref device, 0) == 0;

                    ControlForm.debug_addDebugMessage("Enumerated Display Device: " + device.DeviceName + " @" + device.DeviceString);


                    //do it again for extra data?
                    bool extraerror = EnumDisplayDevices(device.DeviceName, 0, ref device, 0x00000001) == 0;
                    if (!extraerror)
                    {
                        ControlForm.debug_addDebugMessage("\tInitializing device " + devId + " with name: " + device.DeviceString + "...");

                        EnumDisplayDevices(null, devId, ref device, 0);
                        devices.Add(device);
                        ControlForm.debug_addDebugMessage("\t\tAdded device: " + device.DeviceName + " Attached to: " + device.DeviceString);
                    }
                }
                catch (Exception)
                {
                    ControlForm.debug_addDebugMessage("Exception during initialization");
                    error = true;
                }
            }
        }
        */



    }


    /// <summary>
    /// Find out about which monitors are made available by the system.
    /// </summary>
    public abstract class WindowsMultiDisplayTools
    {
        #region Multi-Display Detection
        private delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);

        [DllImport("user32.dll")]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct MonitorInfo
        {
            public uint Size;
            public RectNative Monitor;
            public RectNative WorkArea;
            public uint Flags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RectNative
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool GetMonitorInfo(IntPtr hmon, ref MonitorInfo monitorinfo);
        #endregion

        /// <summary>
        /// The struct that contains the display information
        /// </summary>
        public class DisplayInfo
        {
            public string Availability { get; set; }
            public int ScreenHeight { get; set; }
            public int ScreenWidth { get; set; }
            public Rect MonitorArea { get; set; }
            public int MonitorTop { get; set; }
            public int MonitorLeft { get; set; }
            public string DeviceName { get; set; }
            public string FriendlyName { get; set; }
            public string VendorsName { get; set; }
        }

        /// <summary>
        /// Returns the number of Displays using the Win32 functions.
        /// </summary>
        /// <returns>A collection of DisplayInfo with information about each monitor.</returns>
        public static List<DisplayInfo> QueryDisplays()
        {
            var Monitors = new List<DisplayInfo>();

            // Get the all Display Monitors.
            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                delegate (IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
                {
                    MonitorInfo monitor = new MonitorInfo();
                    monitor.Size = (uint)Marshal.SizeOf(monitor);
                    monitor.DeviceName = null;
                    bool Success = GetMonitorInfo(hMonitor, ref monitor);
                    if (Success)
                    {
                        DisplayInfo displayinfo = new DisplayInfo();
                        displayinfo.ScreenWidth = monitor.Monitor.Right - monitor.Monitor.Left;
                        displayinfo.ScreenHeight = monitor.Monitor.Bottom - monitor.Monitor.Top;
                        displayinfo.MonitorArea = new Rect(monitor.Monitor.Left, monitor.Monitor.Top, displayinfo.ScreenWidth, displayinfo.ScreenHeight);
                        displayinfo.MonitorTop = monitor.Monitor.Top;
                        displayinfo.MonitorLeft = monitor.Monitor.Left;
                        displayinfo.Availability = monitor.Flags.ToString();
                        displayinfo.DeviceName = monitor.DeviceName;
                        displayinfo.FriendlyName = QueryDisplaysFriendlyName(monitor.DeviceName);
                        displayinfo.VendorsName = QueryDisplaysVendorName(monitor.DeviceName);
                        Monitors.Add(displayinfo);
                    }
                    return true;
                }, IntPtr.Zero);
            return Monitors;
        }
        /// <summary>
        /// Returns the Friendly Name of a target Display using the Win32 functions.
        /// </summary>
        /// <returns>A string of with FriendlyName from DeviceName.</returns>
        private static string QueryDisplaysFriendlyName(string DeviceName)
        {
            string FriendlyName = null;

            // Get Friendly Name for the Device code goes here.


            return FriendlyName;
        }
        /// <summary>
        /// Returns the Vendors Name of a target Display using the Win32 functions.
        /// </summary>
        /// <returns>A string of with VendorName from DeviceName.</returns>
        private static string QueryDisplaysVendorName(string DeviceName)
        {
            string VendorName = null;

            // Get Vendors Name for the Device code goes here.


            return VendorName;
        }

    } 
    }
