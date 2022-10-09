using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTemplateUploader
{

    public class Metadata
    {
        public string recordType { get; set; }
        public bool droti { get; set; }
        public bool duid { get; set; }
        public string letter { get; set; }
        public string logo { get; set; }
        public DateTime dateFrom { get; set; }
        public string dateCancel { get; set; }
        public DateTime dateCreation { get; set; }
        public object nameOnTemplate { get; set; }
        public string systemSet { get; set; }
        public bool hasPrintComponent { get; set; }
        public bool isEditorManaged { get; set; }
        public string id { get; set; }
        public string documentType { get; set; }
        public string tribe { get; set; }
        public string idTemp { get; set; }
        public string systAdmin { get; set; }
        public string templateName { get; set; }
        public DateTime lastChange { get; set; }
        public DateTime created { get; set; }
        public bool active { get; set; }
        public string system { get; set; }
        public string owner { get; set; }
        public object ownerValidated { get; set; }
        public string idOwner { get; set; }
        public string version { get; set; }
        public List<string> tags { get; set; }
        public object masterTemplateId { get; set; }
        public object masterTemplateIds { get; set; }
        public string templateAuthor { get; set; }
        public object templateAuthorValidated { get; set; }
        public object squad { get; set; }
        public string channel { get; set; }
        public int distributionChannel { get; set; }
        public Distributionchannel[] distributionChannels { get; set; }
        public string status { get; set; }
        public string sourceFileStatus { get; set; }
        public Status[] statuses { get; set; }
        public Sourcefilestatus[] sourceFileStatuses { get; set; }
        public bool isLegal { get; set; }
        public object description { get; set; }
        public string changeDescription { get; set; }
        public object note { get; set; }
        public object attachments { get; set; }
        public Lastchangeauthor lastChangeAuthor { get; set; }
        public object externalDependencies { get; set; }
        public object[] segments { get; set; }
        public string aip { get; set; }
        public List<string> languages { get; set; }
        public Usage[] usages { get; set; }
        public int usageAggregated { get; set; }
        public string secretDescription { get; set; }
        public bool bioSignature { get; set; }
        public object messageSubject { get; set; }
        public string _etag { get; set; }
        public List<string> sourceFiles { get; set; }
        public object processingType { get; set; }
        public object processingPath { get; set; }
        public object links { get; set; }
        public bool isDirty { get; set; }
        public object taskLink { get; set; }
        public object isPersonalized { get; set; }
        public string selfService { get; set; }
        public string isReviewedByTemplateSquad { get; set; }

        public Metadata()
        {
            this.languages = new List<string>();
            this.tags = new List<string>();
            this.sourceFiles = new List<string>();
        }

    }

    public class Lastchangeauthor
    {
        public string id { get; set; }
        public string name { get; set; }
        public object email { get; set; }
    }

    public class Distributionchannel
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public string id { get; set; }
        public string environment { get; set; }
        public string status { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime? validTo { get; set; }
        public string stakeholder { get; set; }
        public string documentPart { get; set; }
    }

    public class Sourcefilestatus
    {
        public string id { get; set; }
        public string environment { get; set; }
        public string status { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime? validTo { get; set; }
        public object stakeholder { get; set; }
        public string documentPart { get; set; }
    }

    public class Usage
    {
        public string id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public int value { get; set; }
        public string usageType { get; set; }
    }

}
