using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace máy_tính
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isTypingNumber = false;

        enum PhepToan { Cong, Tru, Nhan, Chia };
        PhepToan pheptoan;

        double nho;



        private void Nhapso(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Nhapso(btn.Text);

        }
        private void Nhapso(string so)

        {
            if (isTypingNumber)
            {
                if (lblHienThi.Text == "0")
                    lblHienThi.Text = "";
                lblHienThi.Text += so;
            }
            else
            {
                lblHienThi.Text = so;
                isTypingNumber = true;
            }

        }
        private void NhapPhepToan(object sender, EventArgs e)
        {
            if (nho != 0) ;
              TinhKetQua(); 
          

            Button btn = (Button)sender;
            switch (btn.Text)
            {

                case "+": pheptoan = PhepToan.Cong; break;
                case "-": pheptoan = PhepToan.Tru; break;
                case "*": pheptoan = PhepToan.Nhan; break;
                case "/": pheptoan = PhepToan.Chia; break;


            }
            nho = double.Parse(lblHienThi.Text);
            isTypingNumber = false;


        }

        private void TinhKetQua()

        {
            // tinh toan dua tren; nho, phettoan, lblHienThi.Text
            double tam = double.Parse(lblHienThi.Text);
            double ketqua = 0.0;
            switch (pheptoan)
            {
                case PhepToan.Cong: ketqua = nho + tam; break;
                case PhepToan.Tru: ketqua = nho - tam; break;
                case PhepToan.Nhan: ketqua = nho * tam; break;
                case PhepToan.Chia: ketqua = nho / tam; break;

            }
            // gan ket qua tinh duoc len lblHienThi
            lblHienThi.Text = ketqua.ToString();
        }

        private void btnbang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            isTypingNumber = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':

                    Nhapso("" + e.KeyChar);
                    break;
                case '+':
                    btncong.PerformClick();
                    break;
                case '-':
                    btntru.PerformClick();
                    break;
                case '*':
                    btnnhan.PerformClick();
                    break;
                case '/':
                    btnchia.PerformClick();
                    break;
                case '=':
                    btnbang.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void Btncan_Click(object sender, EventArgs e)
        {
            lblHienThi.Text = (Math.Sqrt(Double.Parse(lblHienThi.Text))).ToString();
        }

        private void Btndoidau_Click(object sender, EventArgs e)
        {
            lblHienThi.Text = (-1 * (double.Parse(lblHienThi.Text))).ToString();
        }

        private void Btnphantram_Click(object sender, EventArgs e)
        {
            lblHienThi.Text = ((double.Parse(lblHienThi.Text) / 100)).ToString();
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            {
                if (lblHienThi.Text.Length > 0)
                    lblHienThi.Text = lblHienThi.Text.Remove(lblHienThi.Text.Length - 1, 1);
                if (lblHienThi.Text == "")
                {
                    lblHienThi.Text = "0";
                }
            }
        }

        private void BtnNho_Click(object sender, EventArgs e)
        {
            nho = 0;
            lblHienThi.Text = "0";
        }

        private void BTNCHAM_Click(object sender, EventArgs e)
        {
            if (lblHienThi.Text.Contains("."))
            {
                if (lblHienThi.Text == "0.")
                {
                    lblHienThi.Text = "";
                    Nhapso("0.");
                }
                return;
            }
            lblHienThi.Text += ".";
        }
    }
}

            


        
    




