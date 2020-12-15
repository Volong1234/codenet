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
    public partial class ThemLop : Form
    {
        Classroom lopHoc;
        public ThemLop()
        {
            InitializeComponent();
            this.Text = "Them moi ";
        }
        public ThemLop(Classroom lopHoc)
        {
            InitializeComponent();
            this.Text = "Chinh sua ";
            this.lopHoc = lopHoc;
            txtTenLop.Text = this.lopHoc.Name;
            txtPhongHoc.Text = this.lopHoc.Room;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var tenLop = txtTenLop.Text;
            var phongHoc = txtPhongHoc.Text;
            if (this.lopHoc == null)
            {
                //them lop o day 
                var lop = new Classroom
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = tenLop,
                    Room = phongHoc
                };
                var db = new QuanLySinhVien.DB.DB();
                db.Classrooms.Add(lop);
                db.SaveChanges();
                //Nếu thêm thành công thì trả về kết quả là OK
                DialogResult = DialogResult.OK;
            }
            else
            {
                var db = new QuanLySinhVien.DB.DB();
                var lop = db.Classrooms.Where(t => t.ID == lopHoc.ID).FirstOrDefault();
                lop.Name = tenLop;
                lop.Room = phongHoc;
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }

        void AddClassroom()
        {
            var tenLop = txtTenLop.Text;
            var phongHoc = txtPhongHoc.Text;
            if (this.lopHoc == null)
            {
                //them lop o day 
                var lop =new Classroom
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = tenLop,
                    Room = phongHoc
                };
                var db = new QuanLySinhVien.DB.DB();
                db.Classrooms.Add(lop);
                db.SaveChanges();
                //Nếu thêm thành công thì trả về kết quả là OK
                DialogResult = DialogResult.OK;
            }
            else
            {
                var db = new QuanLySinhVien.DB.DB();
                var lop = db.Classrooms.Where(t => t.ID == lopHoc.ID).FirstOrDefault();
                lop.Name = tenLop;
                lop.Room = phongHoc;
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
