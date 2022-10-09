using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Text.Json;

namespace WordTemplateUploader
{
    

    class ExcelParser : IDisposable
    {
        public string path { get; set;}

        public int sheetNum { get; set; }

        public Dictionary<int, string> colDictionary { get; set; }

        public Dictionary<string, int> reverseColDictionary { get; set; }

        public int idTempColIndex { get; set; }

        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;


        public int GetSheetNumber(string sheetName)
        {


            wb = excel.Workbooks.Open(this.path);

            int sheetCount = wb.Worksheets.Count;


            for (int i = 1; i <= sheetCount; i++)
            {
                ws = wb.Worksheets[i];

                string sheetNameAtIndex = ws.Name;

         

                if (sheetNameAtIndex == sheetName)
                {

              
                    return i;
                }
            }


            Dispose();
            return 1;
        }
        
        public void WriteResults(List<string> ok, Dictionary<string, string> wrongData, WhisperDataClass WhisperData)
        {
          

            wb = excel.Workbooks.Open(this.path);

            ws = wb.Worksheets[this.sheetNum];
            int row = 3;
            while (ws.Cells[row, 3].Value2 != null)
            {

                string id = ws.Cells[row, this.idTempColIndex].Value2;
                string cleanId = id.Split('\u0022')[1];
                if (ok.Contains(cleanId))
                {
                    ws.Cells[row, 32].Value = "OK";
                    ws.Cells[row, 33].Value = "";
                    for (int x = 1; x < 32; x++)
                    {
                        ws.Cells[row, x].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }
          
                }

                if (wrongData.ContainsKey(cleanId))
                {
                    ws.Cells[row, 32].Value = wrongData[cleanId];

                     string correctionSuggestion = "Vyplňte jednu z následujících hodnot u slopcu";

                    if (wrongData[cleanId].Contains("source file error"))
                    {

                        ws.Cells[row, this.reverseColDictionary["sourceFiles"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                       
                    }

                    if (wrongData[cleanId].Contains("SelfService contains wrong value"))
                    {

                        ws.Cells[row, this.reverseColDictionary["selfService"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        correctionSuggestion += " SelfService: " + JsonSerializer.Serialize(WhisperData.selfServices);
                      
                    }

                    if (wrongData[cleanId].Contains("IsReviewedByTemplateSquad contains wrong value"))
                    {


                        ws.Cells[row, this.reverseColDictionary["isReviewedByTemplateSquad"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        correctionSuggestion += " Revize squadem šablon: " + JsonSerializer.Serialize(WhisperData.isReviewedByTemplateSquads);
                    }
                    else
                    {
                        ws.Cells[row, this.reverseColDictionary["isReviewedByTemplateSquad"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }


                    if (wrongData[cleanId].Contains("AIP contains wrong value"))
                    {
                        ws.Cells[row, this.reverseColDictionary["aip"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                       correctionSuggestion += " Důvěrnost: " + JsonSerializer.Serialize(WhisperData.aips);
                    }
                    else
                    {
                        ws.Cells[row, this.reverseColDictionary["aip"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }


                    if (wrongData[cleanId].Contains("Tribe contains wrong value"))
                    {
                        ws.Cells[row, this.reverseColDictionary["tribe"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        correctionSuggestion += " Tribe: " + JsonSerializer.Serialize(WhisperData.tribes);
                    }
                    else
                    {
                        ws.Cells[row, this.reverseColDictionary["tribe"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }

                    if (wrongData[cleanId].Contains("System contains wrong value"))
                    {
                        ws.Cells[row, this.reverseColDictionary["system"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        correctionSuggestion += " Systém SRC: " + JsonSerializer.Serialize(WhisperData.systems);
                    }
                    else
                    {
                        ws.Cells[row, this.reverseColDictionary["system"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }


                    if (wrongData[cleanId].Contains("Languages contains wrong value"))
                    {
                        ws.Cells[row, this.reverseColDictionary["languages"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        correctionSuggestion += " Jazyky: " + JsonSerializer.Serialize(WhisperData.languages);
                    }
                    else
                    {
                        ws.Cells[row, this.reverseColDictionary["languages"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }

                    if (wrongData[cleanId].Contains("SystAdmin contains wrong value"))
                    {
                        ws.Cells[row, this.reverseColDictionary["systAdmin"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                       correctionSuggestion += " Systém admin: " + JsonSerializer.Serialize(WhisperData.systAdmins);
                    }
                    else
                    {
                        ws.Cells[row, this.reverseColDictionary["systAdmin"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }

                    if (wrongData[cleanId].Contains("Logo contains wrong value"))
                    {
                        ws.Cells[row, this.reverseColDictionary["logo"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        correctionSuggestion += " Logo: " + JsonSerializer.Serialize(WhisperData.logos);
                    }
                    else
                    {
                        ws.Cells[row, this.reverseColDictionary["logo"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }

                    if (wrongData[cleanId].Contains("SystemSet contains wrong value"))
                    {
                        ws.Cells[row, this.reverseColDictionary["systemSet"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        correctionSuggestion += " Systémová sada: " + JsonSerializer.Serialize(WhisperData.systemSets);
                    }
                    else
                    {
                        ws.Cells[row, this.reverseColDictionary["systemSet"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }


                    if (wrongData[cleanId].Contains("NameOnTemplate contains wrong value"))
                    {
                        ws.Cells[row, this.reverseColDictionary["nameOnTemplate"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        correctionSuggestion += " Jméno v šabloně: " + JsonSerializer.Serialize(WhisperData.nameOnTemplates);
                    }
                    else
                    {
                        ws.Cells[row, this.reverseColDictionary["nameOnTemplate"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }
                    ws.Cells[row, 33].Value = correctionSuggestion;
                }
                
                row++;

            }

               
        }


        public List<string> GetTemplateIds()
        {
            GetColumnIndices();
        
            wb = excel.Workbooks.Open(this.path);

            ws = wb.Worksheets[this.sheetNum];
      

            List<string> idList = new List<string>();
            int i = 3;
            while (ws.Cells[i, this.idTempColIndex].Value2 != null)
            {

                string id = ws.Cells[i, this.idTempColIndex].Value2;
                try
                {
                    string cleanId = id.Split('\u0022')[1];
                    idList.Add(cleanId);
                }
                catch (IndexOutOfRangeException)
                {
                    List<string> emptyList = new List<string>();
              
                    return emptyList;
                }
           

                i++;
            }

            return idList;
        }


        public Dictionary<int, string> GetColumnIndices()
        {
            Dictionary<int, string> columnIndices = new Dictionary<int, string>();

            Dictionary<string, int> revertColumnIndices = new Dictionary<string, int>();

            wb = excel.Workbooks.Open(this.path);

            ws = wb.Worksheets[this.sheetNum];

            int column = 1;
            while(ws.Cells[1, column].Value2 != null)
            {

                if(ws.Cells[1, column].Value2 == "idTemp")
                {
                    this.idTempColIndex = column;
                }

                columnIndices[column] = ws.Cells[1, column].Value2;

                revertColumnIndices[ws.Cells[1, column].Value2] = column;

                column++;
            }

           

            this.reverseColDictionary = revertColumnIndices;
            this.colDictionary = columnIndices;
            return columnIndices;
        }


        public List<Metadata> UpdateMetadataList(List<Metadata> metadataList)
        {

           if(metadataList.Count == 0)
            {
                return metadataList;
            }
         

            wb = excel.Workbooks.Open(this.path);

            ws = wb.Worksheets[this.sheetNum];

            int row = 3;
            int listIndex = 0;
            while (ws.Cells[row, this.idTempColIndex].Value2 != null)
            {

  

                Metadata Metadata = metadataList[listIndex];

                int x = 1;
                while (ws.Cells[1, x].Value2 != null) { 

            
                    if (ws.Cells[row, x].Value2 != null)
                    {
                       

                        switch (this.colDictionary[x])
                        {
                            case "active":

                                if (ws.Cells[row, x].Value2)
                                {
                                    Metadata.active = true;
                                }
                                else
                                {
                                    Metadata.active = false;
                                }

                               

                                break;
                            case "idTemp":


                                Metadata.idTemp = ws.Cells[row, x].Value2.Split('\u0022')[1];
                               
                                break;
                            case "templateName":
   
                                Metadata.templateName = ws.Cells[row, x].Value2.Split('\u0022')[1];
                            
                                break;
                            case "changeDescription":

                                Metadata.changeDescription = ws.Cells[row, x].Value2.Split('\u0022')[1];
                             
                                break;


                            case "version":

     
                                Metadata.version = ws.Cells[row, x].Value2.Split('\u0022')[1];
                        

                                break;
                            case "lastChange":

   
                                string loadedString = ws.Cells[row, x].Value2.Split('\u0022')[1];


                                DateTime loadedDate = DateTime.ParseExact(loadedString, "dd.MM.yyyy", null);

                                Metadata.lastChange = loadedDate;
                     
                                break;
                            case "templateAuthor":
             
                                Metadata.templateAuthor = ws.Cells[row, x].Value2.Split('\u0022')[1];
                          
                                break;
                            case "isPersonalized":

                                if (ws.Cells[row, x].Value2 == "null")
                                {
                                    Metadata.isPersonalized = null;
                                }
                                else
                                {
                                    Metadata.isPersonalized = ws.Cells[row, x].Value2.Split('\u0022')[1];
                                }
                     
                                break;


                            case "selfService":

  
                                if (ws.Cells[row, x].Value2 == "null")
                                {
                                    Metadata.selfService = null;
                                }
                                else
                                {
                                    Metadata.selfService = ws.Cells[row, x].Value2.Split('\u0022')[1];
                                }

                         
                                break;
                            case "isReviewedByTemplateSquad":


                                if (ws.Cells[row, x].Value2 == "null")
                                {
                                    Metadata.isReviewedByTemplateSquad = null;
                                }
                                else
                                {
                                    Metadata.isReviewedByTemplateSquad = ws.Cells[row, x].Value2.Split('\u0022')[1];
                                }

                    
                                break;
                            case "owner":

                                Metadata.owner = ws.Cells[row, x].Value2.Split('\u0022')[1];
                     
                                break;
                            case "idOwner":

                                Metadata.idOwner = ws.Cells[row, x].Value2.Split('\u0022')[1];
                           
                                break;


                            case "tribe":


                                Metadata.tribe = ws.Cells[row, x].Value2.Split('\u0022')[1];
                         

                                break;

                            case "tags":




                                List<string> tagList = new List<string>();

                                string stringValueTag = ws.Cells[row, x].Value2;
                                var tagDirty = stringValueTag.Split(',').ToList();

                                foreach (string tag in tagDirty)
                                {

                                    tagList.Add(tag.Split('\u0022')[1]);
                                }


                                Metadata.tags = tagList;
           
                          

                                break;

                            case "description":


                                Metadata.description = ws.Cells[row, x].Value2.Split('\u0022')[1];
                            

                                break;
                            case "languages":

        
                                List<string> languageList = new List<string>();

                                string stringValue = ws.Cells[row, x].Value2;
                                var languagesDirty = stringValue.Split(',').ToList();

                                foreach (string lang in languagesDirty)
                                {

                                    languageList.Add(lang.Split('\u0022')[1]);
                                }


                                Metadata.languages = languageList;
              
                                break;
                            case "logo":

                                Metadata.logo = ws.Cells[row, x].Value2.Split('\u0022')[1];
       
                                break;

                            case "dateCreation":
       

                                string loadedStringCreation = ws.Cells[row, x].Value2.Split('\u0022')[1];


                                DateTime creationDate = DateTime.ParseExact(loadedStringCreation, "yyyy-MM-ddThh:mm:ssZ", null);


                                Metadata.dateCreation = creationDate;
                      
                                break;
                            case "nameOnTemplate":
      
                                Metadata.nameOnTemplate = ws.Cells[row, x].Value2.Split('\u0022')[1];
           
                                break;

                            case "dateCancel":


                                if (ws.Cells[row, x].Value2 == "null")
                                {
                                    Metadata.dateCancel = null;
                                }
                                else
                                {
                                    string loadedStringCancel = ws.Cells[row, x].Value2.Split('\u0022')[1];
                                    Metadata.dateCancel = loadedStringCancel;
                                }  

                                break;
                            case "aip":

                                Metadata.aip = ws.Cells[row, x].Value2.Split('\u0022')[1];
               
                                break;
                            case "secretDescription":

                                Metadata.secretDescription = ws.Cells[row, x].Value2.Split('\u0022')[1];
                 
                                break;
                            case "letter":

                                Metadata.letter = ws.Cells[row, x].Value2.Split('\u0022')[1];
                      
                                break;


                            case "bioSignature":


                                Metadata.bioSignature = ws.Cells[row, x].Value2;
                        

                                break;
                            case "registrace":

                              

                                break;
                            case "recordType":
      
                                if (ws.Cells[row, x].Value2 == "null")
                                {
                                    Metadata.recordType = null;
                                }
                                else
                                {
                                    Metadata.recordType = ws.Cells[row, x].Value2.Split('\u0022')[1];
                                }

                  
                                break;
                            case "systemSet":

                                Metadata.systemSet = ws.Cells[row, x].Value2.Split('\u0022')[1];
          
                                break;
                            case "sourceFiles":
    
                                List<string> sourceList = new List<string>();

                                string stringValueSource = ws.Cells[row, x].Value2;
                                var sourceDirty = stringValueSource.Split(',').ToList();

                                foreach (string source in sourceDirty)
                                {
                                    sourceList.Add(source.Split('\u0022')[1]);
                                }


                                Metadata.sourceFiles = sourceList;
      
                                
                                break;


                            case "systAdmin":

                                Metadata.systAdmin = ws.Cells[row, x].Value2.Split('\u0022')[1];
                            
                                break;
                            case "system":


                                Metadata.system = ws.Cells[row, x].Value2.Split('\u0022')[1];
                               
                                break;
                        }
                    }
                    x++;
                }

                row++;
                listIndex++;
            }




            return metadataList;
        }



 

        public void Dispose()
        {
 
            excel.ActiveWorkbook.Save();
            excel.ActiveWorkbook.Close();
            excel.Quit();
        }


    }
}
