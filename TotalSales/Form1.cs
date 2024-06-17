using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TotalSales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int[] sales = new int[0]; //Creating the array to store the values of the sales from the file, initialized as empty

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //First Pass: couting the number of lines in the file
                //Initializing variable to 0 to keep track of the lines

                int lineCount = 0;

                using (StreamReader countFile = File.OpenText(@"C:\Users\milto\OneDrive\Desktop\DBS\ProgramsClass\sales.txt"))
                {
                    while (countFile.ReadLine() != null) //Keep couting single lines until it reaches the end of the file, when it will return null
                    {
                        lineCount++; //Iterating the lineCount variable
                    }

                }

                sales = new int[lineCount];
                int total = 0;


                using (StreamReader inputfile = File.OpenText(@"C:\Users\milto\OneDrive\Desktop\DBS\ProgramsClass\sales.txt"))
                {
                    for (int index = 0; index <lineCount; index++) //Loop will run the same times as the array size
                    {
                        sales[index] = int.Parse(inputfile.ReadLine()); //Reading a single line of text, parsing into integer and storing in the array
                        total += sales[index];
                    }
                   

                }

                listBox1.Items.Clear();
                foreach (int value in sales)
                {
                    listBox1.Items.Add(value);                    
                }

                outputLabel.Text = "Total sales: " + total.ToString("C2");
                
            }


            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
           
        }
    }
}
