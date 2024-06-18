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
            InitializeComponent(); // Initialize form components
        }

        private int[] sales = new int[0]; // Array to store sales values from the file, initialized as empty

        // Event handler for the exit button click event
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application
        }

        // Event handler for the calculate button click event
        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // First Pass: counting the number of lines in the file to determine array size
                int lineCount = 0;

                // Open the file to count the number of lines
                using (StreamReader countFile = File.OpenText(@"C:\Users\milto\OneDrive\Desktop\DBS\ProgramsClass\sales.txt"))
                {
                    while (countFile.ReadLine() != null) // Read each line until the end of the file
                    {
                        lineCount++; // Increment line count for each line read
                    }
                }

                // Initialize the sales array with the number of lines counted
                sales = new int[lineCount];
                int total = 0; // Variable to store the total sales
                double average = 0; // Variable to store the average sales
                double largest; // Variable to store the largest sale
                double smallest; // Variable to store the smallest sale

                // Open the file again to read sales values
                using (StreamReader inputfile = File.OpenText(@"C:\Users\milto\OneDrive\Desktop\DBS\ProgramsClass\sales.txt"))
                {
                    // Read the first line to initialize largest and smallest sales
                    sales[0] = int.Parse(inputfile.ReadLine());
                    largest = sales[0];
                    smallest = sales[0];

                    // Loop through the remaining lines
                    for (int index = 1; index < lineCount; index++)
                    {
                        // Read and parse each line into an integer and store it in the array
                        sales[index] = int.Parse(inputfile.ReadLine());

                        total += sales[index]; // Add the sale value to the total

                        // Update largest sale if the current sale is larger
                        if (sales[index] > largest)
                        {
                            largest = sales[index];
                        }

                        // Update smallest sale if the current sale is smaller
                        if (sales[index] < smallest)
                        {
                            smallest = sales[index];
                        }
                    }
                }

                // Calculate the average sales after reading all lines
                average = (double)total / lineCount;

                // Clear the list box before displaying new values
                listBox1.Items.Clear();

                // Add each sale value to the list box
                foreach (int value in sales)
                {
                    listBox1.Items.Add(value);
                }

                // Display total, average, largest, and smallest sales in the respective labels
                outputLabel.Text = "Total sales: " + total.ToString("C2");
                averageOutputLabel.Text = "Average sales: " + average.ToString("C2");
                largestOutputLabel.Text = "Largest sale: " + largest.ToString("C2");
                smallestOutputLabel.Text = "Smallest sale: " + smallest.ToString("C2");
            }
            catch (Exception ex) // Catch any exceptions that occur during file operations
            {
                MessageBox.Show(ex.Message); // Display error message
            }
        }
    }
}
