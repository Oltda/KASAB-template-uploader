
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;

namespace WordTemplateUploader
{
    class FileManager
    {
        public static async Task UploadFile(HttpClient httpClient, string path, string templateFileName, string idTemp)
        {

            templateFileName = templateFileName.Split('/')[templateFileName.Split('/').Length - 1];

            var filePath =  path + '/' + templateFileName;

            using (var multipartFormContent = new MultipartFormDataContent())
            {

                var fileStreamContent = new StreamContent(File.OpenRead(filePath));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/msword");

                multipartFormContent.Add(fileStreamContent, name: "file", fileName: templateFileName);

                var response = await httpClient.PostAsync($"/api/Storage?fileName={templateFileName}&idTemp={idTemp}&systAdmin=CSSAB", multipartFormContent);
                var resultFileUpload = await response.Content.ReadAsStringAsync();

            }
        }


        public static void MoveOneFile(string fullPath, string basePath, string directoryName)
        {


            var splitPath = fullPath.Split('\\');
            var fileName = splitPath[splitPath.Length - 1];
            string path2 = $"{basePath}\\{directoryName}\\{fileName}";

            if (!Directory.Exists($"{basePath}\\{directoryName}"))
            {
                Directory.CreateDirectory($"{basePath}\\{directoryName}");
            }
            string path1 = $"{basePath}\\{fileName}";


            File.Move(path1, path2);

        }


    }
}
