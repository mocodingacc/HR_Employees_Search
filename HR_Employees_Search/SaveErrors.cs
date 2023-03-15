using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace HR_Employees_Search
{
    class SaveErrors
    {
        public void WriteErrorToXml(string Date_Time, string Class_Name, string Function_Name, int ExceptionLineNo, string Exception_Message,Boolean ComportError)
        {
            string dateTimeNow = Date_Time.Replace(':', '-');
            dateTimeNow = dateTimeNow.Replace('/', '-');

            ////string filename = Application.StartupPath + @"\LogFiles\Errors\ProgramErrors.xml";
            ////if (ComportError == true)
            ////{
            ////    filename = Application.StartupPath + @"\LogFiles\Errors\ConnectionErrors.xml";
            ////}
            string filename = Application.StartupPath + @"\LogFiles\Errors\ProgramErrors_"+ dateTimeNow + ".xml";
            if (ComportError == true)
            {
                filename = Application.StartupPath + @"\LogFiles\Errors\ConnectionErrors_" + dateTimeNow + ".xml";
            }

            //string dateTimeNow = Date_Time.Replace(':', '-');
            //dateTimeNow = dateTimeNow.Replace('/', '-');
            //EnsureDirectoryExists(Application.StartupPath + @"\LogFiles\Errors");//AppDomain.CurrentDomain.BaseDirectory + "Error Log Files\\Function Error Log Files");
            //string fullpath = Application.StartupPath + @"\LogFiles\Errors\" + dateTimeNow + ".xml";//Path.Combine(Application.StartupPath, @"\LogFiles\Errors\" + dateTimeNow + ".xml");



            EnsureDirectoryExists(Application.StartupPath + @"\LogFiles\Errors");//AppDomain.CurrentDomain.BaseDirectory + "Error Log Files\\Function Error Log Files");
            string fullpath = filename;//Application.StartupPath + @"\LogFiles\Errors\" + dateTimeNow + ".xml";//Path.Combine(Application.StartupPath, @"\LogFiles\Errors\" + dateTimeNow + ".xml");




            string[] Date_Time_Split = Date_Time.Split(' ');
            if (File.Exists(fullpath))
            {
                try
                {
                    //create new instance of XmlDocument
                    XmlDocument doc = new XmlDocument();


                    //load from file
                    doc.Load(fullpath);

                    //create node and add value
                    XmlNode node = doc.CreateNode(XmlNodeType.Element, "Error", null);
                    //XElement xError = new XElement("Error");
                    //node.InnerText = "this is new node";


                    XmlNode NodeDate = doc.CreateElement("Date");
                    NodeDate.InnerText = Date_Time_Split[0];

                    XmlNode NodeTime = doc.CreateElement("Time");
                    NodeTime.InnerText = Date_Time_Split[1] + Date_Time_Split[2];

                    //create title node
                    XmlNode NodeClassName = doc.CreateElement("Class_Name");
                    //add value for it
                    NodeClassName.InnerText = Class_Name;

                    XmlNode NodeFunctionName = doc.CreateElement("Function_Name");
                    NodeFunctionName.InnerText = Function_Name;

                    XmlNode NodeExceptionLineNo = doc.CreateElement("Exception_Line_No");
                    NodeFunctionName.InnerText = ExceptionLineNo.ToString();

                    XmlNode NodeExceptionMessage = doc.CreateElement("Exception_Message");
                    NodeExceptionMessage.InnerText = Exception_Message;


                    node.AppendChild(NodeDate);
                    node.AppendChild(NodeTime);
                    node.AppendChild(NodeClassName);
                    node.AppendChild(NodeFunctionName);
                    node.AppendChild(NodeExceptionMessage);

                    //add to elements collection
                    doc.DocumentElement.AppendChild(node);

                    //save back
                    doc.Save(fullpath);
                }
                catch(Exception ex)
                {
                    //this may through error file in use
                    int ExceptionLIneNo = GetLineNumber(ex);
                    WriteErrorToXml(DateTime.Now.ToString(), "SaveErrors", "WriteErrorToXml" + " File Exists", ExceptionLIneNo, ex.Message, false);
                }
            }
            else //CreateParams new file
            {
                try
                {
                    using (XmlWriter _XmlWrite = XmlWriter.Create(fullpath))
                    {
                        _XmlWrite.WriteStartDocument();

                        //_XmlWrite.WriteStartElement("Program_Errors");

                        if (ComportError == false)
                        {
                            _XmlWrite.WriteStartElement("Program_Errors");
                        }
                        else
                        {
                            _XmlWrite.WriteStartElement("Connection_Errors");
                        }

                        _XmlWrite.WriteStartElement("Error");

                        _XmlWrite.WriteElementString("Date", Date_Time_Split[0]);
                        _XmlWrite.WriteElementString("Time", Date_Time_Split[1] + Date_Time_Split[2]);
                        _XmlWrite.WriteElementString("Class_Name", Class_Name);
                        _XmlWrite.WriteElementString("Function_Name", Function_Name);
                        _XmlWrite.WriteElementString("Exception_Line_No", ExceptionLineNo.ToString());
                        _XmlWrite.WriteElementString("Exception_Message", Exception_Message);

                        _XmlWrite.WriteEndElement();

                        _XmlWrite.WriteEndElement();
                        _XmlWrite.WriteEndDocument();
                    }
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    int ExceptionLIneNo = GetLineNumber(ex);
                    WriteErrorToXml(DateTime.Now.ToString(), "SaveErrors", "WriteErrorToXml" + " Create New File", ExceptionLIneNo, ex.Message, false);
                }
            }
        }
        
        public void WriteErrorToXml(Exception ex, Type declaringType, string v, Func<string, string, string, string> tokenRequest)
        {
            throw new NotImplementedException();
        }
        public void EnsureDirectoryExists(string filePath)
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    //Create the new directory
                    Directory.CreateDirectory(filePath);
                }
            }
            catch (Exception ex)
            {
                int ExceptionLIneNo = GetLineNumber(ex);
                WriteErrorToXml(DateTime.Now.ToString(), "SaveErrors", "EnsureDirectoryExists", ExceptionLIneNo, ex.Message, false);//(ex, MethodBase.GetCurrentMethod().DeclaringType, "EnsureDirectoryExists");
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

        }

        public int GetLineNumber(Exception ex)
        {
            //try
            //{

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
            //}
            //catch (Exception ex)
            //{
            //    int ExceptionLIneNo = GetLineNumber(ex);
            //    WriteErrorToXml(DateTime.Now.ToString(), "SaveErrors", "GetLineNumber", ExceptionLIneNo, ex.Message, false);//(ex, MethodBase.GetCurrentMethod().DeclaringType, "EnsureDirectoryExists");
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}

        }
    }
}

