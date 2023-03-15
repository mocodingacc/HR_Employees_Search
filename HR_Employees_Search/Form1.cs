/**
 * 
 * Multi Browse Button
 * https://www.c-sharpcorner.com/UploadFile/mahesh/openfiledialog-in-C-Sharp/
 * 
 * Get file path from OpenFileDialog and FolderBrowserDialog
 * https://stackoverflow.com/questions/24449988/how-to-get-file-path-from-openfiledialog-and-folderbrowserdialog
 * 
 * 
 * icons
 * https://www.iconsdb.com/orange-icons/orange-file-icons.html
 * https://www.iconsdb.com/orange-icons/orange-arrow-icons.html
 * 
 */



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HR_Employees_Search
{
    public partial class Form1 : Form
    {
        #region Important Definitions
        SaveErrors _SaveErrors = new SaveErrors();
        InputLanguage arabic;
        InputLanguage english;

        PictureBox picBox;
        int pictureNumber = 1;

        #endregion Important Definitions

        #region Form design and GUI

        public Form1()
        {
            InitializeComponent();
            bunifuTextBox_Employees_Name.Text = "Mohamed Mahmoud Sobhy";
            ChangePictures(pictureNumber);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Location = new Point(0, 0);
            arabic = InputLanguage.CurrentInputLanguage;
            english = InputLanguage.CurrentInputLanguage;
            int count = InputLanguage.InstalledInputLanguages.Count;
            for (int i = 0; i <= count - 1; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("Arabic"))
                {
                    arabic = InputLanguage.InstalledInputLanguages[i];
                }
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("English"))
                {
                    english = InputLanguage.InstalledInputLanguages[i];
                }
            }
        }


        private void bunifuButton_Form_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                int ExceptionLineNo = GetLineNumber(ex);
                _SaveErrors.WriteErrorToXml(DateTime.Now.ToString(), "Form1", "bunifuButton_Form_Close_Click", ExceptionLineNo, ex.Message, false);
            }

        }

        private void bunifuButton_Form_Minimize_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                int ExceptionLineNo = GetLineNumber(ex);
                _SaveErrors.WriteErrorToXml(DateTime.Now.ToString(), "Form1", "bunifuButton_Form_Minimize_Click", ExceptionLineNo, ex.Message, false);
            }

        }

        private void bunifuButton_Settings_Click(object sender, EventArgs e)
        {
            try
            {
                //Form2 OpenformSerialPortSettings = new Form2();
                //OpenformSerialPortSettings.Show();
            }
            catch (Exception ex)
            {
                int ExceptionLineNo = GetLineNumber(ex);
                _SaveErrors.WriteErrorToXml(DateTime.Now.ToString(), "Form1", "bunifuButton_Settings_Click", ExceptionLineNo, ex.Message, false);
            }
        }

        private void bunifuButton_Information_Click(object sender, EventArgs e)
        {
            try
            {
                AboutBox1 aboutBoxForm = new AboutBox1();
                aboutBoxForm.Show();
            }
            catch (Exception ex)
            {
                int ExceptionLineNo = GetLineNumber(ex);
                _SaveErrors.WriteErrorToXml(DateTime.Now.ToString(), "Form1", "bunifuButton_Information_Click", ExceptionLineNo, ex.Message, false);
            }

        }

        private void bunifuButton_Language_Arabic_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuButton_Language_Arabic.SendToBack();
                bunifuButton_Language_Arabic.Hide();
                bunifuButton_Language_English.BringToFront();
                bunifuButton_Language_English.Show();

                InputLanguage.CurrentInputLanguage = arabic;

                this.bunifuLabel1.RightToLeft = this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuLabel1.Text = "الشركة العربية العالمية للبصريات";
                bunifuLabel1.Location = new System.Drawing.Point(1473, 17);//75, 17

                this.bunifuLabel_Employees_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuLabel_Employees_Name.Text = "اسم الموظف:";
                bunifuLabel_Employees_Name.Location = new System.Drawing.Point(130, 10);//6, 10
                this.bunifuTextBox_Employees_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;


                this.bunifuLabel_Employees_ID.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuLabel_Employees_ID.Text = "رقم تعريف الموظف:";
                bunifuLabel_Employees_ID.Location = new System.Drawing.Point(78, 102);//6, 102
                this.bunifuTextBox_Employees_ID.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;


                this.bunifuButton_Search.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuButton_Search.Text = "بحث";

                //-----------------------//

                this.bunifuLabel_Employees_First_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuLabel_Employees_First_Name.Text = "الاسم الأول للموظفين:";
                bunifuLabel_Employees_First_Name.Location = new System.Drawing.Point(64, 260);//6, 260
                this.bunifuTextBox_Employees_First_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

                this.bunifuLabel_Employees_Middle_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuLabel_Employees_Middle_Name.Text = "الاسم الأوسط للموظف:";
                bunifuLabel_Employees_Middle_Name.Location = new System.Drawing.Point(55, 353);//6, 353
                this.bunifuTextBox_Employees_Middle_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

                this.bunifuLabel_Employees_Last_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuLabel_Employees_Last_Name.Text = "اسم العائلة للموظف:";
                bunifuLabel_Employees_Last_Name.Location = new System.Drawing.Point(75, 448);//6, 448
                this.bunifuTextBox_Employees_Last_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

                this.bunifuLabel_Employees_ID_Advanced_Search.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuLabel_Employees_ID_Advanced_Search.Text = "رقم تعريف الموظف:";
                bunifuLabel_Employees_ID_Advanced_Search.Location = new System.Drawing.Point(78, 543);//6, 543
                this.bunifuTextBox_Employees_ID_Advanced_Search.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

                this.bunifuButton_Advanced_Search.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuButton_Advanced_Search.Text = "البحث المتقدم";

                //------------------------//
                this.bunifuButton_Upload.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuButton_Upload.Text = "حفظ البيانات";

                //bunifuLabel_Latitude.Location = new System.Drawing.Point(143, 230);//143, 203);//14, 203
                //bunifuTextBox_Latitude.Location = new System.Drawing.Point(72, 257);//72, 230);//14, 230

                this.bunifuLabel2.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                bunifuLabel2.Text = "الشركة العربية العالمية للبصريات - الموارد البشرية نظام البحث عن الموظفين الإصدار 1.0. هذا البرنامج محمي بحقوق النشر. جميع الحقوق محفوظة 2023 © .";
                bunifuLabel2.Location = new System.Drawing.Point(919, 5);//5, 5

                //bunifuLabel2.Text = "© 2023 Arab International Optronics - M60 Navigation and Observation System version 1.0 . This program is copyright protected. All rights reserved.";
            }
            catch (Exception ex)
            {
                int ExceptionLineNo = GetLineNumber(ex);
                _SaveErrors.WriteErrorToXml(DateTime.Now.ToString(), "Form1", "bunifuButton_Language_Arabic_Click", ExceptionLineNo, ex.Message, false);
            }
        }

        private void bunifuButton_Language_English_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuButton_Language_English.SendToBack();
                bunifuButton_Language_English.Hide();
                bunifuButton_Language_Arabic.BringToFront();
                bunifuButton_Language_Arabic.Show();

                InputLanguage.CurrentInputLanguage = english;

                this.bunifuLabel1.RightToLeft = this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuLabel1.Text = "Arab International Optronics";
                bunifuLabel1.Location = new System.Drawing.Point(75, 17);//75, 17

                this.bunifuLabel_Employees_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuLabel_Employees_Name.Text = "Employee's Name:";
                bunifuLabel_Employees_Name.Location = new System.Drawing.Point(6, 10);//6, 10
                this.bunifuTextBox_Employees_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;


                this.bunifuLabel_Employees_ID.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuLabel_Employees_ID.Text = "Employee's ID:";
                bunifuLabel_Employees_ID.Location = new System.Drawing.Point(6, 102);//6, 102
                this.bunifuTextBox_Employees_ID.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;


                this.bunifuButton_Search.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuButton_Search.Text = "Search";

                //-----------------------//

                this.bunifuLabel_Employees_First_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuLabel_Employees_First_Name.Text = "Employee's First Name:";
                bunifuLabel_Employees_First_Name.Location = new System.Drawing.Point(6, 260);//6, 260
                this.bunifuTextBox_Employees_First_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;

                this.bunifuLabel_Employees_Middle_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuLabel_Employees_Middle_Name.Text = "Employee's Middle Name:";
                bunifuLabel_Employees_Middle_Name.Location = new System.Drawing.Point(6, 353);//6, 353
                this.bunifuTextBox_Employees_Middle_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;

                this.bunifuLabel_Employees_Last_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuLabel_Employees_Last_Name.Text = "Employee's Last Name:";
                bunifuLabel_Employees_Last_Name.Location = new System.Drawing.Point(6, 448);//6, 448
                this.bunifuTextBox_Employees_Last_Name.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;

                this.bunifuLabel_Employees_ID_Advanced_Search.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuLabel_Employees_ID_Advanced_Search.Text = "Employee's ID:";
                bunifuLabel_Employees_ID_Advanced_Search.Location = new System.Drawing.Point(6, 543);//6, 543
                this.bunifuTextBox_Employees_ID_Advanced_Search.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;

                this.bunifuButton_Advanced_Search.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuButton_Advanced_Search.Text = "Advanced Search";

                //------------------------//
                this.bunifuButton_Upload.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuButton_Upload.Text = "Upload";

                //bunifuLabel_Latitude.Location = new System.Drawing.Point(143, 230);//143, 203);//14, 203
                //bunifuTextBox_Latitude.Location = new System.Drawing.Point(72, 257);//72, 230);//14, 230

                this.bunifuLabel2.RightToLeft = this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bunifuLabel2.Text = "© 2023 Arab International Optronics - Human Resources Employees Search System version 1.0. This program is copyright protected. All rights reserved.";
                bunifuLabel2.Location = new System.Drawing.Point(5, 5);//5, 5
            }
            catch (Exception ex)
            {
                int ExceptionLineNo = GetLineNumber(ex);
                _SaveErrors.WriteErrorToXml(DateTime.Now.ToString(), "Form1", "bunifuButton_Language_English_Click", ExceptionLineNo, ex.Message, false);
            }
        }

        #endregion Form design and GUI

        #region Functions and methods 
        public int GetLineNumber(Exception ex)
        {
            var lineNumber = 0;
            const string lineSearch = ":line ";
            var index = ex.StackTrace.LastIndexOf(lineSearch);
            if (index != -1)
            {
                var lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length);
                if (int.TryParse(lineNumberText, out lineNumber))
                {
                }
            }
            return lineNumber;
        }
        #endregion Functions and methods 

        #region Deligates
        /*
        public delegate void TextBoxDelg(System.Windows.Forms.TextBox textBoxName, string RetrievedData);
        private void TextBoxDelgFunction(System.Windows.Forms.TextBox textBoxName, string RetrievedData)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    TextBoxDelg _TextBoxDelg = new TextBoxDelg(TextBoxDelgFunction);
                    Invoke(_TextBoxDelg, new object[] { textBoxName, RetrievedData });
                }
                else
                {

                    if (textBoxName.Name == "textBox_SerialConnectionStatus")
                    {
                        //textBoxName.Enabled = false;
                        textBoxName.ReadOnly = true;
                        textBoxName.Clear();
                        textBoxName.BackColor = Color.LightSlateGray;
                        if (RetrievedData == "Connected")
                        {
                            textBoxName.ForeColor = Color.Green;
                            textBoxName.Text = RetrievedData;
                        }
                        else if (RetrievedData == "Disconnected")
                        {
                            textBoxName.ForeColor = Color.Red;
                            textBoxName.Text = RetrievedData;
                        }
                        else if (RetrievedData == "Initialized")
                        {
                            textBoxName.ForeColor = Color.Black;
                            textBoxName.Text = "Disconnected";
                        }


                    }
                    else
                    {
                        textBoxName.AppendText(RetrievedData);
                    }

                }
            }
            catch (Exception ex)
            {
                int ExceptionLineNo = GetLineNumber(ex);
                _SaveErrors.WriteErrorToXml(DateTime.Now.ToString(), "Form1", "TextBoxDelgFunction", ExceptionLineNo, ex.Message, false);
            }
        }

        private delegate void SetTextDeleg(string text, string status);
        private void si_DataReceived(string data, string status)
        {
            if (status == "textbox1")
            {
                //textBox_SerialRead.Text += data.Trim();
                //textBox_SerialRead.AppendText(data.Trim());
            }
            else if (status == "SplittedData")
            {
                //textBox3.AppendText(data.Trim());
            }
        }

        */

        #endregion Deligates

        private void bunifuButton_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bunifuTextBox_File_Path.Text = openFileDialog1.FileName;
            }
        }

        private void bunifuButton_Multi_Browse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";

            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select Photos";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        //PictureBox imageControl = new PictureBox();
                        //imageControl.Height = 400;
                        //imageControl.Width = 400;

                        Image.GetThumbnailImageAbort myCallback =
                                new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        Bitmap myBitmap = new Bitmap(file);
                        Image myThumbnail = myBitmap.GetThumbnailImage(300, 300,
                            myCallback, IntPtr.Zero);
                        pictureBox_Employee_File.Image = myThumbnail;

                        //PhotoGallary.Controls.Add(imageControl);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void bunifuButton_Next_Click(object sender, EventArgs e)
        {

            /*
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox_Employee_File.Image = new Bitmap(open.FileName);
                pictureBox_Employee_File.BackgroundImageLayout = ImageLayout.Stretch;
                // image file path  
                bunifuTextBox_Employees_Name.Text = open.FileName;
            }
            */

            /*
            int numberOfControls = panel1.Controls.Count;

            int count = 0;
            foreach (Control control in panel1.Controls)
            {
                PictureBox pictureBoxControl = control as PictureBox;
                if (pictureBoxControl != null)
                {
                    count++; //number of textboxes
                             //do what you want here
                    

                }
            }
            */
            int numberOfControls = panel1.Controls.Count;
            pictureNumber += 1;
            if (pictureNumber > numberOfControls)//4
            {
                pictureNumber = 1;
            }
            ChangePictures(pictureNumber);
        }
        private void ChangePictures(int picNum)
        {

            //int count = 1;
            //foreach (Control control in panel1.Controls)
            //{
            //    PictureBox pictureBoxControl = control as PictureBox;
            //    if (pictureBoxControl != null)
            //    {
            //        count++; //number of textboxes
            //                 //do what you want here


            //    }
            //}
            
            switch (picNum)
            {
                case 1:
                    int count = 1;
                    PictureBox pictureBoxControl;
                    foreach (Control control in panel1.Controls)
                    {
                        pictureBoxControl = control as PictureBox;
                        if (pictureBoxControl != null)
                        {
                            count++; //number of textboxes
                                     //do what you want here
                            string pbName = pictureBoxControl.Name;

                        }
                    }
                    //picBox.Name = "PB1";
                    //pictureBox_Employee_File.Image = panel1.Controls.GetChildIndex(pictureBoxControl);//Properties.Resources._01;
                    var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    GetDirectory = GetDirectory + "\\Employees\\" + bunifuTextBox_Employees_Name.Text + "\\" + picNum.ToString() + ".jpg";
                    MessageBox.Show(GetDirectory.ToString());
                    //string[] filePaths = Directory.GetFiles(@GetDirectory, "*.jpg", SearchOption.AllDirectories);

                    //pictureBox_Employee_File.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.StretchImage;//Zoom
                    pictureBox_Employee_File.Image = Image.FromFile(GetDirectory);//Properties.Resources._01;
                    //lblInfo.Text = "This is the first image, picture of a very nice lake with the hills around it.";

                    //picBox.Name = "PB1";
                    //pictureBox_Employee_File.Image = picBox.Image;//pictureBox_Employee_File.Image = Properties.Resources._02;

                    pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.Normal;
                    //pictureBox_Employee_File.Image = imageList1.Images[picNum ];

                    break;
                case 2:
                    //string name_of_PB_to_be_changed = "PB" + picNum.ToString();
                    //this.Controls[name_of_PB_to_be_changed].BackgroundImage = System.Drawing.Color.Red;
                    //pictureBox_Employee_File.Image = this.Controls[name_of_PB_to_be_changed].BackgroundImage;
                    //picBox.Name = "PB2"; 
                    //pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.Zoom;
                    //pictureBox_Employee_File.Image = picBox.Image;//pictureBox_Employee_File.Image = Properties.Resources._02;
                    //lblInfo.Text = "This is the second image, picture of a cottage in the lake with lots of mountains around it";
                    pictureBox_Employee_File.Size = new Size(729, 450);
                    pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.StretchImage ;
                    pictureBox_Employee_File.Image = imageList1.Images[picNum - 1];
                    break;
                case 3:
                    //picBox.Name = "PB3";
                    //pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.Zoom;
                    //pictureBox_Employee_File.Image = picBox.Image;//pictureBox_Employee_File.Image = Properties.Resources._03;
                    //lblInfo.Text = "This is the third image, looks like a nice green field, mountains and the lake";

                    pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Employee_File.Image = imageList1.Images[picNum - 1];
                    break;
                case 4:
                    //picBox.Name = "PB4";
                    //pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.Zoom;
                    //pictureBox_Employee_File.Image = picBox.Image;//pictureBox_Employee_File.Image = Properties.Resources._04;
                    ////lblInfo.Text = "This is the fourth image, a beautiful sunset on the horizon";

                    pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Employee_File.Image = imageList1.Images[picNum - 1];
                    break;
                case 5:
                    //picBox.Name = "PB5";
                    //pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.Zoom;
                    //pictureBox_Employee_File.Image = picBox.Image;//pictureBox_Employee_File.Image = Properties.Resources._05;
                    ////lblInfo.Text = "This is the fifth image, it has the nice red sunset and it reflects on the water, the clouds and the mountains";
                    
                    pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Employee_File.Image = imageList1.Images[picNum - 1];
                    break;
                case 6:
                    //picBox.Name = "PB6";
                    //pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.Zoom;
                    //pictureBox_Employee_File.Image = picBox.Image;//pictureBox_Employee_File.Image = Properties.Resources._05;
                    ////lblInfo.Text = "This is the fifth image, it has the nice red sunset and it reflects on the water, the clouds and the mountains";
                    
                    pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Employee_File.Image = imageList1.Images[picNum - 1];
                    break;

                case 7:
                    //picBox.Name = "PB7";
                    //pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.Zoom;
                    //pictureBox_Employee_File.Image = picBox.Image;//pictureBox_Employee_File.Image = Properties.Resources._05;
                    ////lblInfo.Text = "This is the fifth image, it has the nice red sunset and it reflects on the water, the clouds and the mountains";
                    
                    pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Employee_File.Image = imageList1.Images[picNum - 1];
                    break;
                case 8:
                    //picBox.Name = "PB8";
                    //pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.Zoom;
                    //pictureBox_Employee_File.Image = picBox.Image;

                    pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Employee_File.Image = imageList1.Images[picNum-1];
                    break;
                case 9:
                    //picBox.Name = "PB9";
                    //pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.Zoom;
                    //pictureBox_Employee_File.Image = picBox.Image;

                    pictureBox_Employee_File.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Employee_File.Image = imageList1.Images[picNum-1];
                    break;
            }
            
        }

        private void bunifuButton_Previous_Click(object sender, EventArgs e)
        {
            int numberOfControls = panel1.Controls.Count;
            Console.WriteLine(numberOfControls.ToString());
            
            pictureNumber -= 1;
            Console.WriteLine(pictureNumber.ToString());
            if (pictureNumber <= 0)//4
            {
                pictureNumber = numberOfControls;
            }
            ChangePictures(pictureNumber);
        }

        private void bunifuButton_Search_Click(object sender, EventArgs e)
        {
            //var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location + "\\Employees");
            //var GetDirectory = Path.GetDirectoryName(Application.StartupPath);
            //var GetDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            GetDirectory = GetDirectory + "\\Employees\\" + bunifuTextBox_Employees_Name.Text + "\\";
            MessageBox.Show(GetDirectory.ToString());

            //string[] filePaths = Directory.GetFiles(@GetDirectory, "*.jpg");
            //string[] filePaths = Directory.GetFiles(@"H:\visual_studio_2022\HR_Employees_Search\HR_Employees_Search\HR_Employees_Search\bin\Debug\Employees\Mohamed Mahmoud Sobhy\", "*.jpg",SearchOption.AllDirectories);

            string[] filePaths = Directory.GetFiles(@GetDirectory, "*.jpg", SearchOption.AllDirectories);

            //H:\visual_studio_2022\HR_Employees_Search\HR_Employees_Search\HR_Employees_Search\bin\Employees\Mohamed Mahmoud Sobhy

            int x = 20;
            int y = 20;
            int maxHeight = -1;
            int index = 1;

            foreach (string filePath in filePaths)
            {
                
                picBox = new PictureBox();
                picBox.Image = Image.FromFile(filePath);
                picBox.Name = "PB" + index.ToString();
                picBox.Location = new Point(x, y);
                picBox.SizeMode = PictureBoxSizeMode.Zoom;

                x += picBox.Width + 10;
                maxHeight = Math.Max(picBox.Height, maxHeight);
                if(x > this.ClientSize.Width - 100)
                {
                    x = 20;
                    y += maxHeight + 10;
                }
                imageList1.Images.Add(Image.FromFile(filePath));
                this.panel1.Controls.Add(picBox);
                index++;
                Console.WriteLine(filePath.ToString());
            }

            int numberOfControls = panel1.Controls.Count;
            Console.WriteLine(numberOfControls.ToString());
            Console.WriteLine(imageList1.Images.Count.ToString());


        }

        private void bunifuButton_Print_Click(object sender, EventArgs e)
        {
            var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            GetDirectory = GetDirectory + "\\Employees\\" + bunifuTextBox_Employees_Name.Text + "\\" + 1.ToString() + ".jpg";
            MessageBox.Show(GetDirectory.ToString());

            //string[] filePaths = Directory.GetFiles(@GetDirectory, "*.jpg");
            //string[] filePaths = Directory.GetFiles(@"H:\visual_studio_2022\HR_Employees_Search\HR_Employees_Search\HR_Employees_Search\bin\Debug\Employees\Mohamed Mahmoud Sobhy\", "*.jpg",SearchOption.AllDirectories);

            //string[] filePaths = Directory.GetFiles(@GetDirectory, "*.jpg", SearchOption.AllDirectories);

            using (PrintDocument pd = new PrintDocument())
            {
                
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                   // string filePath = @"C:\image.JPG";
                    string filePath = @GetDirectory;
                    pd.OriginAtMargins = true;
                    pd.PrintPage += pd_PrintPage;
                    pd.DocumentName = filePath;
                    pd.Print();
                    pd.PrintPage -= pd_PrintPage;
                }
            }
        }

        public void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            string labelPath = ((PrintDocument)sender).DocumentName;
            e.Graphics.DrawImage(new Bitmap(labelPath), 0, 0);
        }

        private void bunifuButton_Upload_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter =
"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
"All files (*.*)|*.*";

            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select Photos";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        //PictureBox imageControl = new PictureBox();
                        //imageControl.Height = 400;
                        //imageControl.Width = 400;

                        Image.GetThumbnailImageAbort myCallback =
                                new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        Bitmap myBitmap = new Bitmap(file);
                        Image myThumbnail = myBitmap.GetThumbnailImage(myBitmap.Width, myBitmap.Height,
                            myCallback, IntPtr.Zero);
                        pictureBox_Employee_File.Image = myThumbnail;

                        //PhotoGallary.Controls.Add(imageControl);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
