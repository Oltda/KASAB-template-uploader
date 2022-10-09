using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace WordTemplateUploader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void parseExlBtn_Click(object sender, EventArgs e)
        {

            parseExlBtn.Enabled = false;
            loadingLbl.Visible = true;
            InitiateUpload();
 


        }
        
        ExcelParser excel = new ExcelParser();
        excel.path = getExcelTxtBox.Text;
        bool excelSaved = false;
        public async void  InitiateUpload()
        {

            string filesPath = directoryTxtBox.Text;
            excel.sheetNum = excel.GetSheetNumber(listNameTxtBox.Text);

            UploadManager UploadManager = new UploadManager();
            UploadManager.token = tokenTxtBox.Text;
              

            List<string> idList = excel.GetTemplateIds();
            UploadInstruction UploadInstruction = await UploadManager.GetMetadataList(idList);

          
            try
            {
            
            List<Metadata> updatedMetadataList = excel.UpdateMetadataList(UploadInstruction.metadataList);

            List<string> okData = new List<string>();
            List<string> wrongData = new List<string>();
            Dictionary<string, string> errorData = new Dictionary<string, string>();


            foreach (Metadata item in updatedMetadataList)
            {
                string postResult = "";

                if (UploadInstruction.oldTemplates.Contains(item.idTemp))
                {

                        try
                        {
                           
                            postResult = await UploadManager.PutTemplate(item, filesPath);
                            
                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            MessageBox.Show($"Nastala chyba při nahrávání, soubor .dotm šablony {item.idTemp}  nebyl nalezen v uvedeném adresáři.");
                            errorData.Add(item.idTemp, $"soubor{item.idTemp}.dotm neni v adresari");
                  
                        }
                        catch (System.IO.DirectoryNotFoundException)
                        {
                            MessageBox.Show($"Slozka Instalace {listNameTxtBox.Text} neexistuje");
                            break;
                        }
                    
   
                }
                else
                {

                   
                        try
                        {
                            postResult = await UploadManager.PostNewTemplate(item, filesPath);
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            MessageBox.Show("Nastala chyba pri nahravani nove sablony. Ujistete se, ze jste v excelovem souboru uvedli jmeno zdrojoveho souboru");
                        }
                        
                 }

                if (postResult.Contains("error"))
                {

  
                    wrongData.Add(item.idTemp);
                    errorData.Add(item.idTemp, postResult);
                }
                else
                {
                    okData.Add(item.idTemp);
                }


            }

                var whisperDataCall = await UploadManager.WhisperData();
                WhisperDataClass WhisperData = JsonSerializer.Deserialize<WhisperDataClass>(whisperDataCall);

                excel.WriteResults(okData, errorData, WhisperData);

            }
            catch (System.IndexOutOfRangeException)
            {
                MessageBox.Show("Nastala chyba, při čtění Excelového souboru. Ujistěte se, že jsou zapsané hodnoty s uvozovkami");    
            }

            excel.Dispose();
            excelSaved = true;
            parseExlBtn.Enabled = true;
            loadingLbl.Visible = false;
            MessageBox.Show("Instalace sablon je dokoncena");


        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            directoryTxtBox.Text = dlg.SelectedPath;


            if (Directory.Exists(directoryTxtBox.Text))
            {
        
                var files = Directory.GetFiles(directoryTxtBox.Text, "*.dotm*", SearchOption.TopDirectoryOnly);
     
            }
        }

        private void getExcelBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select file";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "All files (*.*)|*.*|Excel File (*.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                getExcelTxtBox.Text = openFileDialog1.FileName;
            
            }
            else
            {
                getExcelTxtBox.Text = "";
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true);

                if(excel.path != null && !excelSaved)
                {
                    excel.Dispose();
                }
               
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show(" Chcete ukončit aplikaci?          ", "Zavřít aplikaci...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool userValidated = false;
        private async void  tokenTxtBox_TextChanged(object sender, EventArgs e)
        {
            UploadManager UploadManager = new UploadManager();
            UploadManager.token = tokenTxtBox.Text;

            var userRes = await UploadManager.ValidateToken();

            if (userRes == "")
            {
                tickLbl.Visible = false;
                crossLbl.Visible = true;
                userValidated = false;

            }
            else
            {
                tickLbl.Visible = true;
                crossLbl.Visible = false;
                userValidated = true;
            }


        }


        private string CreateWhisperList(List<string> input)
        {

            string result = "";
            foreach(string item in input)
            {
                result += $"{item}\r\n";
            }

            return result;
        }

        private async void WHisperListBox_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (userValidated)
            {
                UploadManager UploadManager = new UploadManager();
                UploadManager.token = tokenTxtBox.Text;

                var whisperDataCall = await UploadManager.WhisperData();

               
                WhisperDataClass WhisperData = JsonSerializer.Deserialize<WhisperDataClass>(whisperDataCall);



                switch (WHisperListBox.SelectedItem.ToString())
                {
                    case "Systemy":
                        WhisperDataTxtBox.Text = CreateWhisperList(WhisperData.systems);
                        break;
                    case "SelfService":

                        WhisperDataTxtBox.Text = CreateWhisperList(WhisperData.selfServices);
                        break;
                    case "Revize squadem šablon":

                        WhisperDataTxtBox.Text = CreateWhisperList(WhisperData.isReviewedByTemplateSquads);
                        break;
                    case "Důvěrnost":

                        WhisperDataTxtBox.Text = CreateWhisperList(WhisperData.aips);
                        break;
                    case "Tribe":

                        WhisperDataTxtBox.Text = CreateWhisperList(WhisperData.tribes);
                        break;

                    case "Jazyky":

                        WhisperDataTxtBox.Text = CreateWhisperList(WhisperData.languages);
                        break;
                    case "Systém admin":

                        WhisperDataTxtBox.Text = CreateWhisperList(WhisperData.systAdmins);
                        break;
                    case "Logo":

                        WhisperDataTxtBox.Text = CreateWhisperList(WhisperData.logos);
                        break;
                    case "Systémová sada":

                        WhisperDataTxtBox.Text = CreateWhisperList(WhisperData.systemSets);
                        break;
                    case "Jméno v šabloně":

                        WhisperDataTxtBox.Text = CreateWhisperList(WhisperData.nameOnTemplates);
                        break;
                }

  

            }
            else
            {
                MessageBox.Show("Zadejte platny token");
            }


        }

        private async void findBtn_Click(object sender, EventArgs e)
        {
            if (userValidated)
            {

                bool failed = false;
                string system = systAdmLstBox.SelectedItem.ToString();

                UploadManager UploadManager = new UploadManager();
                UploadManager.token = tokenTxtBox.Text;

                

                if(system == "eom")
                {
                    List<EomClass> result = await UploadManager.FindReplaceEOM(findWithOwnerTxtBox.Text, system);

                    while (result.Count > 0)
                    {
                        string uploadRes = await UploadManager.ReplaceEom(result, newOwnerTxtBox.Text);
                        if(uploadRes == "error")
                        {
                            failed = true;
                            break;
                            
                        }
                        result = await UploadManager.FindReplaceEOM(findWithOwnerTxtBox.Text, system);
                    }

                }

                if (system == "cssab" || system == "MSOFFICE")
                {
                    List<Metadata> result = await UploadManager.FindReplaceCSSAB(findWithOwnerTxtBox.Text, system);

                    while (result.Count > 0)
                    {
                        string uploadRes = await UploadManager.ReplaceCSSAB(result, newOwnerTxtBox.Text);
                        if (uploadRes == "error")
                        {
                            failed = true;
                            break;

                        }

                        result = await UploadManager.FindReplaceCSSAB(findWithOwnerTxtBox.Text, system);
                    }

                }



                if (failed)
                {
                    MessageBox.Show("Nemáte dostatečná práva");
                }
                else
                {
                    MessageBox.Show("nahrazeno");
                }
                
            }
            else
            {
                MessageBox.Show("Zadejte token");
            }

        }
    }
}
