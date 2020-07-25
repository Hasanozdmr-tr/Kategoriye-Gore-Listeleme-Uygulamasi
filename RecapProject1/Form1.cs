using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListCategories();
            ListProducts();

            


    }
        private void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())   //garbage collector u beklemeden direk uçur performans için.
            {
                dgwProduct.DataSource = context.Products.ToList(); // yani burda select * from  yollayacaktır. Product içinde olanları select eder.
            }
        }

        private void ListProductsByCategory(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())   
            {
                dgwProduct.DataSource = context.Products.Where(p=>p.CategoryId==categoryId).ToList(); 
            }                     //bu sorgudaki gibi where koşulunca olanları getir.
        }

        private void ListProductsByProductName(string key)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.ProductName.ToLower().Contains(key.ToLower())).ToList();
            }                     //bu sorgudaki gibi where koşulunca olanları getir.
        }

        private void ListCategories()
        {
            using (NorthwindContext context = new NorthwindContext())   //garbage collector u beklemeden direk uçur performans için.
            {
                cbxCategory.DataSource = context.Categories.ToList(); // yani burda select * from  yollayacaktır. Product içinde olanları select eder.
                cbxCategory.DisplayMember = "CategoryName";      // combobox da Textini göstermek için
                cbxCategory.ValueMember = "CategoryId";            //kullanıcı onu seçtiğinde ürünlere göre filtrelerken bu lazım olcak.

            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {

                // burayı boş bırakmak hatayı verme dediğimi yap demek
            }

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            
            string key = TbtSearch.Text;
            if (string.IsNullOrEmpty(key))
            {
                ListProducts();
            }
            else
                ListProductsByProductName(key);

        }
    }
}
