using System;
using System.Collections.Generic;


namespace WordTemplateUploader
{
    public class EomClass
    {
        public string msType { get; set; }
        public string msVariant { get; set; }
        public int smsCapacity { get; set; }
        public int letterCapacity { get; set; }
        public int pushCapacity { get; set; }
        public int emailCapacity { get; set; }
        public object[] channelCapacity { get; set; }
        public object trnScr { get; set; }
        public object certificate { get; set; }
        public string emailSystem { get; set; }
        public double priority { get; set; }
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
        public object owner { get; set; }
        public object ownerValidated { get; set; }
        public object idOwner { get; set; }
        public object version { get; set; }
        public string[] tags { get; set; }
        public string masterTemplateId { get; set; }
        public string[] masterTemplateIds { get; set; }
        public string templateAuthor { get; set; }
        public object templateAuthorValidated { get; set; }
        public object squad { get; set; }
        public string channel { get; set; }
        public int distributionChannel { get; set; }
        public List<ChannelList> distributionChannels { get; set; }
        public string status { get; set; }
        public string sourceFileStatus { get; set; }
        public List<Status> statuses { get; set; }
        public List<Sourcefilestatus> sourceFileStatuses { get; set; }
        public bool isLegal { get; set; }
        public string description { get; set; }
        public string changeDescription { get; set; }
        public object note { get; set; }
        public object attachments { get; set; }
        public Lastchangeauthor lastChangeAuthor { get; set; }
        public object externalDependencies { get; set; }
        public object segments { get; set; }
        public string aip { get; set; }
        public List<string> languages { get; set; }
        public object usages { get; set; }
        public int usageAggregated { get; set; }
        public object secretDescription { get; set; }
        public bool bioSignature { get; set; }
        public object messageSubject { get; set; }
        public string _etag { get; set; }
        public object sourceFiles { get; set; }
        public object processingType { get; set; }
        public object processingPath { get; set; }
        public object links { get; set; }
        public bool isDirty { get; set; }
        public object taskLink { get; set; }
        public object isPersonalized { get; set; }
        public string selfService { get; set; }
        public string isReviewedByTemplateSquad { get; set; }

        public EomClass()
        {
            this.languages = new List<string>();
            this.distributionChannels = new List<ChannelList>();
        }
    }



    public class ChannelList
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
