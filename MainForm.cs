using System;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;

namespace Device_Renamer
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("Select * from Win32_PnPSignedDriver");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {
                var FriendlyName = (string)obj["FriendlyName"] ?? (string)obj["DeviceName"] ?? "Unknown";
                var DeviceName = (string)obj["DeviceName"] ?? "Unknown";
                var Manufacturer = (string)obj["Manufacturer"] ?? "Unknown";
                var ClassGuid = (string)obj["ClassGuid"] ?? "Unknown";
                var DeviceClass = (string)obj["DeviceClass"] ?? "Unknown";
                if (!treeView1.Nodes.ContainsKey(DeviceClass)) {
                    TreeNode classNode = new TreeNode(DeviceClass);
                    classNode.Name = DeviceClass;
                    treeView1.Nodes.Add(classNode);
                }
                var deviceNode = new DeviceNode();
                deviceNode.Text = FriendlyName;
                deviceNode.Name = ClassGuid;
                deviceNode.FriendlyName = FriendlyName;
                deviceNode.Manufacturer = Manufacturer;
                treeView1.Nodes[DeviceClass].Nodes.Add(deviceNode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("System", true);
            key = key.OpenSubKey("ControlSet001", true);
            key = key.OpenSubKey("Enum", true);
            SearchSubKeys(key, textBox2.Text);
            return;
            key = key.OpenSubKey(textBox2.Text, true);

            key.SetValue("yourkey", "yourvalue");
            MessageBox.Show("Save clicked");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0) return;
            DeviceNode node = (DeviceNode)e.Node;
            textBox1.Text = node.FriendlyName;
            textBox2.Text = node.Name;
            textBox3.Text = node.Manufacturer;
        }

        private static void SearchSubKeys(RegistryKey root, string searchKey)
        {
            if (root == null)
            {
                return;
            }

            foreach (string keyname in root.GetSubKeyNames())
            {
                try
                {
                    using (RegistryKey key = root.OpenSubKey(keyname))
                    {
                        if (key == null)
                        {
                            return;
                        }

                        if (keyname == searchKey)
                        {
                            try
                            {
                                // root.DeleteSubKeyTree(searchKey);
                                MessageBox.Show(string.Format("{0},{1},{2}", keyname, key.Name, root.Name));
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        SearchSubKeys(key, searchKey);
                    }
                }
                catch (System.Security.SecurityException se)
                {

                }
                catch (Exception ex)
                {

                }
            }
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
