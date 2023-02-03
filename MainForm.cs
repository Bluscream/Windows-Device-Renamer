using System;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Windows.Input;
using System.Diagnostics;
using System.Linq;

namespace Device_Renamer
{

    public partial class MainForm : Form
    {
        ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("Select * from Win32_PnPSignedDriver");
        public MainForm()
        {
            InitializeComponent();
            InitList();
        }

        private void InitList()
        {
            ManagementObjectCollection objCollection = objSearcher.Get();

            treeView1.Nodes.Clear();
            foreach (ManagementObject obj in objCollection)
            {
                var FriendlyName = (string)obj["FriendlyName"] ?? (string)obj["DeviceName"] ?? "Unknown";
                var DeviceName = (string)obj["DeviceName"] ?? "Unknown";
                var Manufacturer = (string)obj["Manufacturer"] ?? "Unknown";
                var ClassGuid = (string)obj["ClassGuid"] ?? "Unknown";
                var HardWareID = (string)obj["HardWareID"] ?? "Unknown";
                var DeviceClass = (string)obj["DeviceClass"] ?? "Unknown";
                if (!treeView1.Nodes.ContainsKey(DeviceClass))
                {
                    TreeNode classNode = new TreeNode(DeviceClass);
                    classNode.Name = DeviceClass;
                    treeView1.Nodes.Add(classNode);
                }
                var deviceNode = new DeviceNode();
                deviceNode.Text = FriendlyName;
                deviceNode.Name = HardWareID;
                deviceNode.FriendlyName = FriendlyName;
                deviceNode.Manufacturer = Manufacturer;
                treeView1.Nodes[DeviceClass].Nodes.Add(deviceNode);
            }
        }



        private void btn_save_registry_devicedesc_Click(object sender, EventArgs e)
        {
            var key = GetKeyByHardwareID(txt_wmi_hwid.Text);
            if (!key.GetSubKeyNames().ToList().Contains("_DeviceDesc"))
            {
                key.SetValue("_DeviceDesc", key.GetValue("DeviceDesc").ToString());
            }
            key.SetValue("DeviceDesc", txt_registry_devicedesc.Text);
            InitList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var key = GetKeyByHardwareID(txt_wmi_hwid.Text);
            if (!key.GetSubKeyNames().ToList().Contains("_FriendlyName"))
            {
                key.SetValue("_FriendlyName", key.GetValue("FriendlyName").ToString());
            }
            key.SetValue("FriendlyName", txt_registry_friendlyname.Text);
            InitList();
        }

        private void btn_reset_name_Click(object sender, EventArgs e)
        {
            var key = GetKeyByHardwareID(txt_wmi_hwid.Text);
            if (!key.GetSubKeyNames().ToList().Contains("_FriendlyName"))
            {
                MessageBox.Show($"Original FriendlyName could not be found in {key.Name}", "Could not find original FriendlyName", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            key.SetValue("FriendlyName", key.GetValue("_FriendlyName").ToString());
        }

        private void btn_regedit_Click(object sender, EventArgs e)
        {
            var registryLastKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Applets\Regedit";
            try
            {
                Registry.SetValue(registryLastKey, "LastKey", GetKeyByHardwareID(txt_wmi_hwid.Text).ToString()); // Set LastKey value that regedit will go directly to
                Process.Start("regedit.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0) return;
            DeviceNode node = (DeviceNode)e.Node;
            txt_wmi_friendly_name.Text = node.FriendlyName;
            txt_wmi_hwid.Text = node.Name;
            txt_wmi_manufacturer.Text = node.Manufacturer;
            var key = GetKeyByHardwareID(node.Name);
            try { txt_registry_friendlyname.Text = (key.GetValue("FriendlyName") as string).Split(';').Last(); } catch { txt_registry_friendlyname.Text = "Unknown"; }
            try { txt_registry_devicedesc.Text = (key.GetValue("DeviceDesc") as string).Split(';').Last(); } catch { txt_registry_devicedesc.Text = "Unknown"; }
            try { txt_registry_manufacturer.Text = (key.GetValue("Mfg") as string).Split(';').Last(); } catch { txt_registry_manufacturer.Text = "Unknown"; }
        }

        private static RegistryKey GetKeyByHardwareID(string hardwareID)
        {
            var uuid = hardwareID;
            var root = "System\\ControlSet001\\Enum";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(root, true);
            RegistryKey new_key = null;
            _ = SearchSubKeys(key, uuid, ref new_key);
            if (new_key == null) MessageBox.Show($"{uuid} could not be found in {root}", "Could not find device in Registry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new_key;
        }

        private static RegistryKey SearchSubKeys(RegistryKey root, string searchKey, ref RegistryKey outKey)
        {
            if (root == null)
            {
                return null;
            }

            foreach (string keyname in root.GetSubKeyNames())
            {
                try
                {
                    var key = root.OpenSubKey(keyname, true);
                    if (key == null) continue;
                    var uuidkey_obj = key.GetValue("HardwareID");
                    if (uuidkey_obj != null)
                    {
                        string uuidkey = "";
                        switch (key.GetValueKind("HardwareID"))
                        {
                            case RegistryValueKind.MultiString:
                                uuidkey = ((string[])uuidkey_obj)[0]; break;
                            case RegistryValueKind.ExpandString:
                            case RegistryValueKind.String:
                                uuidkey = ((string)uuidkey_obj); break;
                            default:
                                continue;
                        }
                        // Console.WriteLine($"\"{uuidkey}\" vs \"{searchKey}\" == {(uuidkey.Trim() == searchKey.Trim())}");
                        if (uuidkey.Trim() == searchKey.Trim())
                        {
                            Console.WriteLine($"Found {key}!");
                            outKey = key;
                            return key;
                        } else
                        {
                            continue;
                        }
                    } else
                    {
                        if (outKey is null) SearchSubKeys(key, searchKey, ref outKey);
                    }

                }
                catch (System.Security.SecurityException se)
                {
                    // Console.WriteLine(se.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw (ex);
                }
            }
            return outKey;
        }
    }
    public class DeviceNode : TreeNode
    {
        private string strFriendlyName;
        public string FriendlyName {
            get { return strFriendlyName; }
            set { strFriendlyName = value; }
        }
        private string strManufacturer;
        public string Manufacturer {
            get { return strManufacturer; }
            set { strManufacturer = value; }
        }
    }
}
