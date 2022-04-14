using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace PharmacyApp
{
    public partial class DashboardForm : Form
    {
        PharmacyDB _context = new PharmacyDB();

        #region DashboardForm
        public DashboardForm()
        {
            InitializeComponent();
        }
        #endregion
        #region addToolStripMenuItem_Click
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineForm medicineForm = new MedicineForm();
            medicineForm.ShowDialog();
        }
        #endregion
        #region FillMedicineCombo
        private void FillMedicineCombo()
        {
            comboMedicine.Items.AddRange(_context.Medicines.Select(m => m.MedicineName).ToArray());
        }
        #endregion
        #region FillFirmCombo
        private void FillFirmCombo()
        {
            comboTags.Items.AddRange(_context.Tags.Select(m => m.Name).ToArray());
        }
        #endregion
        #region FillMedicineDtg
        private void FillMedicineDtg()
        {
            dtgMed.DataSource = _context.MedicineToTags.Where(m=> m.Medicine.MedicineName.Contains(comboMedicine.Text) ||
            m.Tag.Name.Contains(comboTags.Text))
                .Select(md => new
            {
                md.MedicineID,
                Medicine_Name = md.Medicine.MedicineName,
                md.Medicine.Price,
                md.Medicine.Quantity,
                Recept = md.Medicine.IsReceipt ? "Reseptli" : "Reseptsiz",
                Firm_Name = md.Medicine.Firm.Name,
                Production_Date = md.Medicine.ProDate,
                md.Medicine.ExperienceDate
            }).Distinct().ToList();
            dtgMed.Columns[0].Visible = false;
            dtgMed.Columns[5].DefaultCellStyle.Format = "dddd, dd MMMM yyyy";
            dtgMed.Columns[6].DefaultCellStyle.Format = "dddd, dd MMMM yyyy";
            _context.SaveChanges();
            for (int i = 0; dtgMed.Rows.Count > i; i++)
            {
                short quantity = (short)dtgMed.Rows[i].Cells[3].Value;
                DateTime exDate = (DateTime)dtgMed.Rows[i].Cells[7].Value;
                 if(exDate < DateTime.Now)
                 {
                    dtgMed.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    dtgMed.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }

                if (quantity <= 0)
                {
                    dtgMed.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dtgMed.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                if(exDate < DateTime.Now && quantity <= 0)
                {
                    dtgMed.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                    dtgMed.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }

        }
        #endregion
        #region DashboardForm_Load
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            FillMedicineCombo();
            FillFirmCombo();
            FillMedicineDtg();
        }
        #endregion
        #region comboMedicine_KeyUp
        private void comboMedicine_KeyUp(object sender, KeyEventArgs e)
        {
            FillMedicineDtg();
        }
        #endregion
        #region comboTags_KeyUp
        private void comboTags_KeyUp(object sender, KeyEventArgs e)
        {
            FillMedicineDtg();
        }
        #endregion
        #region comboMedicine_SelectedIndexChanged
        private void comboMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillMedicineDtg();
        }
        #endregion
        #region comboTags_SelectedIndexChanged
        private void comboTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillMedicineDtg();
        }
        #endregion
        #region dtgMed_RowHeaderMouseDoubleClick
        private void dtgMed_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int medId =  (int)dtgMed.Rows[e.RowIndex].Cells[0].Value;
            Medicine selectedMedicine = _context.Medicines.FirstOrDefault(m=> m.ID == medId);
            if (selectedMedicine.Quantity !=0 && selectedMedicine.ExperienceDate > DateTime.Now)
            {
                MedicinePanel.Visible = true;
                txtMedicine.Text = selectedMedicine.MedicineName;
                numCount.Maximum = selectedMedicine.Quantity;
                numCount.Value = 1;
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
        #region btnBuy_Click
        private void btnBuy_Click(object sender, EventArgs e)
        {
            string result = "";
            for (int i = 0; i < ckBuyMedicine.Items.Count; i++)
            {
                string medicineItem = ckBuyMedicine.Items[i].ToString();
                string medName = medicineItem.Substring(0, medicineItem.LastIndexOf("-"));
                short medQuantity = Convert.ToInt16(medicineItem.Substring(medicineItem.LastIndexOf("-") + 1));
                Medicine selectMed = _context.Medicines.First(f=> f.MedicineName==medName);
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
            FillMedicineDtg();
            ClearAfterOrder();
        }
        #endregion
        #region btnExportExcel_Click
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            var xlapp = new Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = xlapp.Workbooks.Add();
            var xlSheet = xlWorkBook.Worksheets[1];
            for (int i = 0; i < dtgMed.ColumnCount; i++)
            {
                xlSheet.Cells[1, i + 1] = dtgMed.Columns[i].HeaderText;
            }
            for (int i = 0; i < dtgMed.RowCount; i++)
            {
                for (int j = 0; j < dtgMed.ColumnCount; j++)
                {
                    xlSheet.Cells[i + 2, j + 1] = dtgMed.Rows[i].Cells[j].Value.ToString();
                }
            }
            string medFileName = "Medicine" + Guid.NewGuid().ToString();
            xlWorkBook.SaveAs($@"C:\Users\Aytac\Desktop\Med\{medFileName}.xlsx");
            xlWorkBook.Close();
            xlapp.Quit();
            MessageBox.Show("Medicine added Excel succesfully");
        }
        #endregion
        #region btnExportPdf_Click
        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dtgMed.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dtgMed.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dtgMed.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dtgMed.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
        #endregion
        #region btnBarcode_Click
        private void btnBarcode_Click(object sender, EventArgs e)
        {
            BarcodeForm barcodeForm = new BarcodeForm();    
            barcodeForm.ShowDialog();
        }
        #endregion

    }
}
