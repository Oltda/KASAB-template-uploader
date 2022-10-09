using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace WordTemplateUploader
{


    class UploadInstruction
    {
        public List<Metadata> metadataList { get; set; }

        public List<string> newTemplates { get; set; }

        public List<string> oldTemplates { get; set; }

       

        public UploadInstruction()
        {
            this.metadataList = new List<Metadata>();
            this.newTemplates = new List<string>();
            this.oldTemplates = new List<string>();
        }
    }

    class UploadManager
    {
        public string token { get; set; }

        public async Task<string> ValidateToken()
        {

            HttpClient testKasabClient = ApiCalls.connectTestKasab(this.token);
            var validatedUser = await testKasabClient.GetAsync("/api/User/me");
            var userRes = await validatedUser.Content.ReadAsStringAsync();
            return userRes;
        }

        public async Task<string> WhisperData()
        {
            HttpClient testKasabClient = ApiCalls.connectTestKasab(this.token);
            var whisperResult = await testKasabClient.GetAsync("/api/Lookup/whisperData?fromStoredData=false");
            var stringResult = await whisperResult.Content.ReadAsStringAsync();
            return stringResult;
        }


        public async Task<List<EomClass>> FindReplaceEOM(string lookupTerm, string system)
        {

            HttpClient testKasabClient = ApiCalls.connectTestKasab(this.token);
            var findTemplates = await testKasabClient.GetAsync($"/api/Template/search?systAdmin={system}&nameOwner={lookupTerm}&page=1");
            var stringResult = await findTemplates.Content.ReadAsStringAsync();

         

            List<EomClass> result = JsonSerializer.Deserialize<List<EomClass>>(stringResult);

            return result;
        }

        public async Task<List<Metadata>> FindReplaceCSSAB(string lookupTerm, string system)
        {

            HttpClient testKasabClient = ApiCalls.connectTestKasab(this.token);
            var findTemplates = await testKasabClient.GetAsync($"/api/Template/search?systAdmin={system}&nameOwner={lookupTerm}&page=1");
            var stringResult = await findTemplates.Content.ReadAsStringAsync();

            List<Metadata> result = JsonSerializer.Deserialize<List<Metadata>>(stringResult);

            return result;
        }



        public async Task<string> ReplaceEom(List<EomClass> result, string newTerm)
        {
            HttpClient testKasabClient = ApiCalls.connectTestKasab(this.token);
            foreach (EomClass temp in result)
            {
                temp.owner = newTerm;

                var contentMaster = new StringContent(JsonSerializer.Serialize(temp), Encoding.UTF8, "application/json");

                var updateMaster = await testKasabClient.PutAsync("/api/Template", contentMaster);

                var updateMasterJson = await updateMaster.Content.ReadAsStringAsync();

                if(updateMasterJson.Contains("Not authorized"))
                {
                    return "error";
                }
                
            }

            return "Ok";
        }


        public async Task<string> ReplaceCSSAB(List<Metadata> result, string newTerm)
        {
            HttpClient testKasabClient = ApiCalls.connectTestKasab(this.token);
            foreach (Metadata temp in result)
            {
                temp.owner = newTerm;

                var contentMaster = new StringContent(JsonSerializer.Serialize(temp), Encoding.UTF8, "application/json");

                var updateMaster = await testKasabClient.PutAsync("/api/Template", contentMaster);

                var updateMasterJson = await updateMaster.Content.ReadAsStringAsync();
                if (updateMasterJson.Contains("Not authorized"))
                {
                    return "error";
                }            

            }

            return "Ok";
        }





        public async Task<string> LookUpTemplate(string msType)
        {

            HttpClient testKasabClient = ApiCalls.connectTestKasab(this.token);
            var masterSearchResp = await testKasabClient.GetAsync($"api/Template/search?master=true&idtemp={msType}&page=1");
            string masterSearchRespjson = await masterSearchResp.Content.ReadAsStringAsync();
            return masterSearchRespjson;
        }


        public async Task<UploadInstruction> GetMetadataList(List<string> idList)
        {

           

            HttpClient testKasabClient = ApiCalls.connectTestKasab(this.token);
            List<Metadata> metadataList = new List<Metadata>();
            UploadInstruction UploadInstruction = new UploadInstruction();

            if(idList.Count == 0)
            {
                return UploadInstruction;
            }


            foreach (string id in idList)
            {                                             

                var masterSearchResp = await testKasabClient.GetAsync($"api/Template/search?master=true&idtemp={id}&page=1");

                string masterSearchRespjson = await masterSearchResp.Content.ReadAsStringAsync();

    

                if (masterSearchRespjson == "[]")
                {
                    Metadata NewTemplate = new Metadata();
                    NewTemplate.idTemp = id;
                    NewTemplate.id = "5485931c-31ed-489b-b751-af9db787e655";
                    metadataList.Add(NewTemplate);

                    UploadInstruction.metadataList.Add(NewTemplate);
                    UploadInstruction.newTemplates.Add(NewTemplate.idTemp);
                }
                else
                {
                    List<Metadata> resultList = JsonSerializer.Deserialize<List<Metadata>>(masterSearchRespjson);

                    if(resultList.Count > 1)
                    {
                        foreach(Metadata result in resultList)
                        {
                            
                            if(result.idTemp == id)
                            {
                                metadataList.Add(result);

                                UploadInstruction.metadataList.Add(result);
                                UploadInstruction.oldTemplates.Add(result.idTemp);
                            }
                            
                        }
                    }
                    else
                    {
                        Metadata TemplMetadata = JsonSerializer.Deserialize<List<Metadata>>(masterSearchRespjson)[0];

                        metadataList.Add(TemplMetadata);

                        UploadInstruction.metadataList.Add(TemplMetadata);
                        UploadInstruction.oldTemplates.Add(TemplMetadata.idTemp);
                    }

                    
                }

               
            }

            return UploadInstruction;
        }

        public async Task<string> PutTemplate(Metadata TemplateData, string directoryPath)
        {


            HttpClient testKasabClient = ApiCalls.connectTestKasab(this.token);


            var contentMaster = new StringContent(JsonSerializer.Serialize(TemplateData), Encoding.UTF8, "application/json");

            var updateMaster = await testKasabClient.PutAsync("/api/Template", contentMaster);

            var updateMasterJson = await updateMaster.Content.ReadAsStringAsync();

            
     

            if (!updateMasterJson.Contains("error") && TemplateData.sourceFiles.Count > 0)
            {
        
                await FileManager.UploadFile(testKasabClient, directoryPath, TemplateData.sourceFiles[0], TemplateData.idTemp);

            }

            if (TemplateData.sourceFiles.Count < 1)
            {
                return "source file error: zdrojovy soubor neni uveden nebo neni ve slozce";
            }


            return updateMasterJson;
        }

        public async Task<string> PostNewTemplate(Metadata TemplateData, string directoryPath)
        {

            HttpClient testKasabClient = ApiCalls.connectTestKasab(this.token);
            var contentMaster = new StringContent(JsonSerializer.Serialize(TemplateData), Encoding.UTF8, "application/json");

            var postMaster = await testKasabClient.PostAsync("/api/Template", contentMaster);

            var postMasterJson = await postMaster.Content.ReadAsStringAsync();


           
            if (!postMasterJson.Contains("error") && TemplateData.sourceFiles.Count > 0)
            {
                await FileManager.UploadFile(testKasabClient, directoryPath, TemplateData.sourceFiles[0], TemplateData.idTemp);
            }
            if (TemplateData.sourceFiles.Count < 1)
            {
                return "source file error: zdrojovy soubor neni uveden nebo neni ve slozce";
            }

            return postMasterJson;
        }

    }
}
