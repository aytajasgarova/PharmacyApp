using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using PharmacyApp.Models;
using ZXing;

namespace PharmacyApp
{
    public partial class BarcodeForm : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        Medicine selectedMedicine;
        PharmacyDB _context = new PharmacyDB();

        #region BarcodeForm
        public BarcodeForm()
        {
            InitializeComponent();
        }
        #endregion
        #region BarcodeForm_Load
        private void BarcodeForm_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
            {
                cmbCamera.Items.Add(device.Name);
            }
            cmbCamera.SelectedIndex = 0;
        }
        #endregion
        #region btnBarcode_Click
        private void btnBarcode_Click(object sender, EventArgs e)
        {
            MedicinePanel.Visible = true;
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cmbCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }
        #endregion
        #region VideoCaptureDevice_NewFrame
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(bitmap);
            if(result != null)
            {
                txtBarcode.Invoke(new MethodInvoker(delegate ()
                {
                    txtBarcode.Text = result.ToString();
                    selectedMedicine = _context.Medicines.FirstOrDefault(m=> m.Barcode== txtBarcode.Text);
                    if(selectedMedicine != null)
                    {
                        txtMedicine.Text = selectedMedicine.MedicineName;
                        numCount.Maximum = selectedMedicine.Quantity;
                    }
                }));
            }
            barcodePicture.Image = bitmap;
        }
        #endregion
        #region BarcodeForm_FormClosing
        private void BarcodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                }
            }
        }
        #endregion
        #region AddMedicineToList
        private void AddMedicineToList(string text)
        {
            if (!ckBuyMedicine.Items.Contains(text))
            {
                ckBuyMedicine.Items.Add(text, true);
            }
        }
        #endregion
        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMedicineToList(txtMedicine.Text + " - " + numCount.Value);
            txtBarcode.Text = "";
        }
        #endregion
        #region btnBuy_Click
        private void btnBuy_Click(object sender, EventArgs e)
        {
            string result = "";
            for (int i = 0; i < ckBuyMedicine.Items.Count; i++)
            {
                string medicineItem = ckBuyMedicine.Items[i].ToString();
                string medName = medicineItem.Substring(0, medicineItem.LastIndexOf("-"));
                short medQuantity = Convert.ToInt16(medicineItem.Substring(medicineItem.LastIndexOf("-") + 1));
                Medicine selectMed = _context.Medicines.First(f => f.MedicineName == medName);
                _context.Orders.Add(new Order
                {
                    WorkerID = 1,
                    MedicineID = selectMed.ID,
                    PurchaseDate = DateTime.Now,
                    Amount = medQuantity,
                    Price = selectMed.Price,
                });
                selectMed.Quantity -= medQuantity;
                _context.SaveChanges();
                result += $"Medicine name: {selectMed.MedicineName}, Quantity: {medQuantity}, Price: {selectMed.Price} AZN \n";
            }
            MessageBox.Show(result, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAfterOrder();
        }
        #endregion
        #region ckBuyMedicine_SelectedIndexChanged
        private void ckBuyMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTag = ckBuyMedicine.SelectedIndex;
            if (selectedTag != -1)
            {
                ckBuyMedicine.Items.RemoveAt(selectedTag);
            }
        }
        #endregion
        #region ClearAfterOrder
        private void ClearAfterOrder()
        {
            ckBuyMedicine.Items.Clear();
            MedicinePanel.Visible = false;
        }
        #endregion

    }
}
