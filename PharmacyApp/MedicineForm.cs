using PharmacyApp.Helpers;
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

namespace PharmacyApp
{
    public partial class MedicineForm : Form
    {
        PharmacyDB _context = new PharmacyDB();

        #region MedicineForm
        public MedicineForm()
        {
            InitializeComponent();
        }
        #endregion
        #region Firm ComboBox Fill
        public void FillFirmCombo()
        {
            cmbFirms.Items.AddRange(_context.Firms.Select(f => f.Name).ToArray());
        }
        #endregion
        #region Tag ComboBox Fill
        public void FillTagCombo()
        {
            cmbTags.Items.AddRange(_context.Tags.Select(t => t.Name).ToArray());
        }
        #endregion
        #region Medicine Load Form
        private void MedicineForm_Load(object sender, EventArgs e)
        {
            FillFirmCombo();
            FillTagCombo();
            FillMedicineDatagrid();
        }
        #endregion
        #region FillMedicineDatagrid
        private void FillMedicineDatagrid()
        {
            dtgMedicineList.DataSource = _context.Medicines.Select(md => new
            {
                Medicine_Name = md.MedicineName,
                md.Price,
                md.Quantity,
                Recept = md.IsReceipt ? "Reseptli" : "Reseptsiz",
                Firm_Name = md.Firm.Name,
                Production_Date = md.ProDate,
                md.ExperienceDate
            }).ToList();
            dtgMedicineList.Columns[5].DefaultCellStyle.Format = "dddd, dd MMMM yyyy";
            dtgMedicineList.Columns[6].DefaultCellStyle.Format = "dddd, dd MMMM yyyy";
            for(int i = 0;i < dtgMedicineList.RowCount; i++)
            {
                if(dtgMedicineList.Rows[i].Index % 2 == 0)
                {
                    dtgMedicineList.Rows[i].DefaultCellStyle.BackColor = Color.BlueViolet;
                    dtgMedicineList.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        #endregion
        #region FindFirm
        public int FindFirm(string firmName)
        {
           Firm selectedFirm = _context.Firms.FirstOrDefault(fr=> fr.Name == firmName);
            if(selectedFirm == null)
            {
                Firm firm = _context.Firms.Add(new Firm()
                {
                    Name = firmName
                });
                _context.SaveChanges();
                return firm.ID;
            }
            return selectedFirm.ID; 
        }
        #endregion
        #region btnAddMedicine_Click
        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            string medicineName = txtMedName.Text;
            string firmName = cmbFirms.Text;
            short count = (short)numQuantity.Value;
            decimal price = numPrice.Value;
            string barcode = txtBarcode.Text;
            string description = txtDescription.Text;
            DateTime productionDate = proDate.Value;
            DateTime experienceDate = exDate.Value;
            bool isReceipt = checkedReceipt.Checked;
            string[] arr = { medicineName, firmName, description};
            if (Utilities.IsEmpty(arr))
            {
                lblError.Visible = false;
                int firmId = FindFirm(firmName);
                if(productionDate < experienceDate)
                {
                    Medicine medicine = _context.Medicines.Add(new Medicine()
                    {
                        MedicineName = medicineName,
                        Description = description,
                        Price = price,
                        Quantity = count,
                        ExperienceDate = experienceDate,
                        IsReceipt = isReceipt ? true : false,
                        ProDate = productionDate,
                        FirmID = firmId,
                        Barcode = barcode
                    });
                    _context.SaveChanges();
                    MedicineAddToTag(medicine.ID);
                    MessageBox.Show("Medicine added succesfully");
                    ClearFormData();
                    FillMedicineDatagrid();
                }
                else
                {
                    lblError.Text = "Experience date is valid!";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Please, all the fill";
                lblError.Visible = true;
            }
        }
        #endregion
        #region CheckedTagName
        private bool CheckedTagName(string tgName)
        {
           Tag tag = _context.Tags.FirstOrDefault(tg => tg.Name == tgName);
            if(tag == null)
            {
                return false;
            }
            return true;
        }
        #endregion
        #region MedicineAddToTag
        private void MedicineAddToTag(int medicineId)
        {
            for(int i = 0; i < ckTagList.Items.Count; i++)
            {
               string tagName = ckTagList.Items[i].ToString();
                int tagId;
                if (CheckedTagName(tagName))
                {
                    tagId = _context.Tags.First(tg => tg.Name == tagName).ID;
                }
                else
                {
                    Tag newTag = _context.Tags.Add(new Tag()
                    {
                        Name = tagName
                    });
                    _context.SaveChanges();
                    tagId = newTag.ID;
                }
                _context.MedicineToTags.Add(new MedicineToTag()
                {
                    MedicineID = medicineId,
                    TagID = tagId
                });
                _context.SaveChanges();
            }
        }
        #endregion
        #region txtBarcode_KeyPress
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57 || txtBarcode.Text.Length > 13) && e.KeyChar != 8)
            {
                e.Handled = true;
            }      
        }
        #endregion
        #region cmbTags_SelectedIndexChanged
        private void cmbTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddTagName();
        }
        #endregion
        #region AddTagName
        private void AddTagName()
        {
            string tagName = cmbTags.Text;
            if (!ckTagList.Items.Contains(tagName) && !string.IsNullOrWhiteSpace(tagName))
            {
                ckTagList.Items.Add(tagName, true);
            }
        }
        #endregion
        #region cmbTags_KeyUp
        private void cmbTags_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AddTagName();
            }
        }
        #endregion
        #region ClearFormData
        private void ClearFormData()
        {
            foreach(Control item in this.Controls)
            {
                if(item is TextBox || item is ComboBox || item is RichTextBox)
                {
                    item.Text = "";
                }
                else if(item is NumericUpDown)
                {
                    NumericUpDown numericUpDown = (NumericUpDown)item;
                    numericUpDown.Value = 1;
                }
                else if(item is DateTimePicker)
                {
                    DateTimePicker dateTimePicker = (DateTimePicker)item;
                    dateTimePicker.Value = DateTime.Now;
                }
                else if(item is CheckedListBox)
                {
                    CheckedListBox checklist = (CheckedListBox)item;
                    checklist.Items.Clear();
                }
                else if(item is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)item;
                    checkBox.Checked = false;
                }
            }
        }
        #endregion
        #region ckTagList_SelectedIndexChanged
        private void ckTagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTag = ckTagList.SelectedIndex;
            if (selectedTag != -1)
            {
                ckTagList.Items.RemoveAt(selectedTag);
            }
        }
        #endregion

    }
}
