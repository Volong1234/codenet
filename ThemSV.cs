using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLySinhVien.DB;

namespace QuanLySinhVien
{
    public partial class ThemSV : Form
    {
        Student sinhVien;
        public ThemSV()
        {
            InitializeComponent();
            this.Text = "Them sinh vien";
        }
        public ThemSV(Student sinhVien)
        {
            InitializeComponent();
            this.Text = "Sua sinh vien";
            this.sinhVien = sinhVien;
            this.txtHo.Text = this.sinhVien.FirstName;
            this.txtTen.Text = this.sinhVien.LastName;
            this.txtMaSV.Text = this.sinhVien.ID;
            this.txtNoiSinh.Text = this.sinhVien.PlaceOfBirth;
            this.date.Text = this.sinhVien.DateOfBirth.ToString();
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            date.Format = DateTimePickerFormat.Short;
            AddStudent();
        }
       
        void AddStudent()
        {
            if(this.sinhVien == null)
            {
                Student student = new Student
                {

                    ID = txtMaSV.Text,
                    FirstName = txtHo.Text,
                    LastName = txtTen.Text,
                    DateOfBirth = date.Value,
                    PlaceOfBirth = txtNoiSinh.Text,
                    Gender = comboBoxGender.SelectedItem.ToString(),
                    IDClassroom = comboBoxLopHoc.SelectedItem.ToString()
                };
                var db = new QuanLySinhVien.DB.DB();
                var obj =
               db.Students.
               Where(e => e.ID == student.ID).
               FirstOrDefault();
                if (obj == null)
                {
                    //add cái dữ liệu trên vào bộ nhớ  
                    db.Students.Add(student);
                    //đẩy dữ liệu từ bộ nhớ vào db
                    db.SaveChanges();
                    MessageBox.Show("Ban da them sinh vien thanh cong");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Bạn không thể thêm lớp này được!");
                }
            } else
            {
                var db = new QuanLySinhVien.DB.DB();
                var sv = db.Students.Where(a => a.ID == sinhVien.ID).FirstOrDefault();
                sv.FirstName = txtHo.Text;
                sv.LastName = txtTen.Text;
                sv.Gender = comboBoxGender.SelectedItem.ToString();
                sv.DateOfBirth = date.Value;
                sv.PlaceOfBirth = txtNoiSinh.Text;
                sv.ID = txtMaSV.Text;
                sv.IDClassroom= comboBoxLopHoc.SelectedItem.ToString();
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
           
        }

        private void ThemSV_Load(object sender, EventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
