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
using GoogleCloudPrint;
using System.Configuration;
using GoogleCloudPrint.Model;

namespace GCPrintTest
{
    public partial class Form1 : Form
    {
        string serviceAccount = ConfigurationManager.AppSettings["serviceAccountID"];
        string P12FileLocation = ConfigurationManager.AppSettings["P12FileLocation"];
        string P12Secret = ConfigurationManager.AppSettings["P12Secret"];
        string ThisProgramName = "Test GCP"; // this can be anything
                                             // used later, not part of instantiation of GCP service
        string m_printerId = ConfigurationManager.AppSettings["printerID"];
        //string FileName = ConfigurationManager.AppSettings["FileName"];
        string PrintJobName = ConfigurationManager.AppSettings["PrintJobName"];
        string MimeType = ConfigurationManager.AppSettings["MimeType"];
        string NotifyUserOfShareEmail = ConfigurationManager.AppSettings["NotifyUserOfShareEmail"];

        #region Class for combo box
        private class CBOItem
        {
            public string defaultDisplayName;
            public string Value;
            public CBOItem(string name, string value)
            {
                defaultDisplayName = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return defaultDisplayName;
            }
        }
        #endregion
        string CRLF = Environment.NewLine;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrintDoc_Click(object sender, EventArgs e)
        {
            // solution to show credentials - https://github.com/io7/GoogleCloudPrint/issues/3
            #region Instantiate library

            var gcpService = new GoogleCloudPrintService(serviceAccount, P12FileLocation, P12Secret, ThisProgramName, GoogleCloudPrintService.CallingProgramConstants.Desktop);
            #endregion
            byte[] docBytes = GetDocumentOnDisk();            // note Hard coding below

            gcpService.PrintDocument(m_printerId, PrintJobName, docBytes, MimeType);
        }

        private byte[] GetDocumentOnDisk()
        {
            #region GetDocument
            GetDocument.ShowDialog();
            // convert doc to byte stream
            byte[] docBytes = StreamFile(GetDocument.FileName);
            #endregion
            return docBytes;
        }

        private byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return ImageData; //return the byte data
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetPrinters();
            LoadPrinterTypes();
        }

        private void GetPrinters()
        {
            GoogleCloudPrint.Model.CloudPrinters printerCollection = GetPrinterCollection();

            List<CloudPrinter> allPrinters = new List<CloudPrinter>();

            //CloudPrinters cPrinters = GetPrinters();
            foreach (var aPrinter in printerCollection.printers)
            {
                allPrinters.Add(aPrinter);
            }

            ClearComboBox(cboPrinters);

            cboPrinters.DataSource = allPrinters;

            cboPrinters.DisplayMember = "defaultDisplayName";
            cboPrinters.ValueMember = "id";

            cboPrinters.Text = string.Empty;

            //foreach (var printer in printerCollection.printers)
            //{
            //    //cboPrinters.Items.Add(new CBOItem(printer.defaultDisplayName, printer.id));
            //    GoogleCloudPrint.Model.CloudPrinter cpItem = new GoogleCloudPrint.Model.CloudPrinter();
            //    cpItem.defaultDisplayName = printer.defaultDisplayName;
            //    cpItem.id = printer.id;
            //    cboPrinters.Items.Add(cpItem);
            //    cboPrinters.DisplayMember = "defaultDisplayName";
            //    cboPrinters.ValueMember = "id";
            //}
        }

        private void ClearComboBox(ComboBox cbo)
        {
            cbo.Text = string.Empty;
            cbo.DataSource = null;
            cbo.Items.Clear();
        }

        private GoogleCloudPrint.Model.CloudPrinters GetPrinterCollection()
        {
            // get list of printers
            var gcpService = new GoogleCloudPrintService(serviceAccount, P12FileLocation, P12Secret, ThisProgramName, GoogleCloudPrintService.CallingProgramConstants.Desktop);
            var printerCollection = gcpService.GetPrinters();
            return printerCollection;
        }

        private void btnSharePrinter_Click(object sender, EventArgs e)
        {
            this.Text = "trying to share printer";
            var gcpService = new GoogleCloudPrintService(serviceAccount, P12FileLocation, P12Secret, ThisProgramName, GoogleCloudPrintService.CallingProgramConstants.Desktop);
            gcpService.PrinterShare(txtPrinterID.Text, NotifyUserOfShareEmail, chkNotify.Checked);
            this.Text = "done";
        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            this.Text = "trying to invite newly shared printer";
            lblInviteResponse.Text = string.Empty;
            var gcpService = new GoogleCloudPrintService(serviceAccount, P12FileLocation, P12Secret, ThisProgramName, GoogleCloudPrintService.CallingProgramConstants.Desktop);
            var response = gcpService.ProcessInvite(txtPrinterID.Text);
            lblInviteResponse.Text = response.success + System.Environment.NewLine + response.message;

            // refresh the list of printers
            GetPrinters();

            this.Text = "done";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Text = "trying to register printer";
            var gcpService = new GoogleCloudPrintService(serviceAccount, P12FileLocation, P12Secret, ThisProgramName, GoogleCloudPrintService.CallingProgramConstants.Desktop);
            GoogleCloudPrint.Model.UnregisteredCloudPrinter pReg = new GoogleCloudPrint.Model.UnregisteredCloudPrinter();

            // fill printer object to register
            pReg.name = txtName.Text;
            pReg.default_display_name = txtDefault_display_name.Text;
            pReg.proxy = txtProxy.Text;
            pReg.tag = txtTag.Text;
            pReg.capabilities = txtCapabilities.Text;

            pReg = gcpService.RegisterPrinter(pReg);

            if (pReg.id == "failure")
            {
                MessageBox.Show("Failure" + CRLF
                    + pReg.name + CRLF
                    + pReg.description);

                this.Text = "failure :( ";
            }
            else
            {
                this.Text = "Success!!!";
            }
        }

        private void cboPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNameFromList.Text = string.Empty;
            CloudPrinter printerInfo = (CloudPrinter)cboPrinters.SelectedItem;
            if (cboPrinters.SelectedItem != null)
            {
                lblNameFromList.Text = printerInfo.defaultDisplayName;
                lblPrinterID.Text = printerInfo.id;
                lblPrinterNameFromList.Text = printerInfo.defaultDisplayName;
            }
            
        }

        // does the update method
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CBOItem printerInfo = (CBOItem)cboPrinters.SelectedItem;
                string selectedPrinterID = printerInfo.Value;

                //if (txtNewName.Text == string.Empty) throw new Exception("Need new name");
                if (lblNewDefaultDisplayName.Text == string.Empty) throw new Exception("Need new display name");

                var gcpService = new GoogleCloudPrintService(serviceAccount, P12FileLocation, P12Secret, ThisProgramName, GoogleCloudPrintService.CallingProgramConstants.Desktop);
                GoogleCloudPrint.Model.UnregisteredCloudPrinter pReg = new GoogleCloudPrint.Model.UnregisteredCloudPrinter();

                // fill printer object to rename
                //pReg.name = txtNewName.Text;
                pReg.default_display_name = lblNewDefaultDisplayName.Text;
                pReg.id = selectedPrinterID;

                gcpService.UpdatePrinter(pReg);

                GetPrinters();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapabilitesFile_Click(object sender, EventArgs e)
        {
            // use a file to fill the capabilites text box
            GetCapabilities.ShowDialog();
            string capabilitiesFile = GetCapabilities.FileName;
            // read file into text box
            txtCapabilities.Text = File.ReadAllText(capabilitiesFile);
        }

        private void btnPrintDocFromName_Click(object sender, EventArgs e)
        {
            var gcpService = new GoogleCloudPrintService(serviceAccount, P12FileLocation, P12Secret, ThisProgramName, GoogleCloudPrintService.CallingProgramConstants.Desktop);
            GoogleCloudPrint.Model.CloudPrinters myPrinters = GetPrinterCollection();
            
            string localPrinterID = string.Empty;
            foreach (var aPrinter in myPrinters.printers)
            {
                if (aPrinter.defaultDisplayName == lblPrinterNameFromList.Text)
                {
                    localPrinterID = aPrinter.id;
                    break;
                }
            }
            byte[] docBytes = GetDocumentOnDisk();
            // note PrintJobName and MimeType come from the CONFIG file
            gcpService.PrintDocument(localPrinterID, PrintJobName, docBytes, MimeType);
        }
        private void LoadPrinterTypes()
        {
            // load combo with printer types enum
            cboGCPPrinterType.DataSource = Enum.GetValues(typeof(GoogleCloudPrint.Model.GoogleCloudPrinterTypeConstants));
        }

        private void btnMakeName_Click(object sender, EventArgs e)
        {
            string delimiter = GoogleCloudPrint.Model.MiscConstants.DEFAULT_NAME_DELIMITER;
            string PrinterType = cboGCPPrinterType.SelectedValue.ToString();
            string NewDisplayName = lblAgencyID.Text + delimiter + PrinterType + delimiter + txtNewDisplayName.Text;
            lblNewDefaultDisplayName.Text = NewDisplayName;
        }

        private void btnFilterPrintersByType_Click(object sender, EventArgs e)
        {
            var gcpService = new GoogleCloudPrintService(serviceAccount, P12FileLocation, P12Secret, ThisProgramName, GoogleCloudPrintService.CallingProgramConstants.Desktop);
            List<GoogleCloudPrint.Model.CloudPrinter> filteredPrinters = gcpService.GetFilteredPrinters((GoogleCloudPrint.Model.GoogleCloudPrinterTypeConstants)cboGCPPrinterType.SelectedValue);

            ClearComboBox(cboPrinters);

            // todo shold refactor the 3 or 4 lines below into a method
            cboPrinters.DataSource = filteredPrinters;
            cboPrinters.DisplayMember = "defaultDisplayName";
            cboPrinters.ValueMember = "id";

            cboPrinters.Text = string.Empty;
        }

        private void btnUnfilteredPrinters_Click(object sender, EventArgs e)
        {
            GetPrinters();
            LoadPrinterTypes();
        }

        private void btnTestCapabilities_Click(object sender, EventArgs e)
        {
            var gcpService = new GoogleCloudPrintService(serviceAccount, P12FileLocation, P12Secret, ThisProgramName, GoogleCloudPrintService.CallingProgramConstants.Desktop);
            GoogleCloudPrint.Model.CloudPrinters myPrinters = GetPrinterCollection();

            string localPrinterID = string.Empty;
            foreach (var aPrinter in myPrinters.printers)
            {
                if (aPrinter.defaultDisplayName == lblPrinterNameFromList.Text)
                {
                    localPrinterID = aPrinter.id;
                    break;
                }
            }
            string content = "abc";
            // note PrintJobName and MimeType come from the CONFIG file
            string localMimeType = "text/plain";
            gcpService.PrintDocument(localPrinterID,"Title",content, localMimeType);
        }
    }
}
