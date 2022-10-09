using System.Collections.Generic;


namespace WordTemplateUploader
{


    public class WhisperDataClass
    {
        public bool isFromStoredData { get; set; }
        public List<string> systems { get; set; }
        public List<string> tribes { get; set; }
        public List<string> systAdmins { get; set; }
        public List<string> systemAdminsAllowedTemplateFileDownload { get; set; }
        public List<string> owners { get; set; }
        public List<string> tags { get; set; }
        public List<string> squads { get; set; }
        public List<string> attachmentTypes { get; set; }
        public List<string> aips { get; set; }
        public List<string> logos { get; set; }
        public List<string> templateStatuses { get; set; }
        public List<string> segments { get; set; }
        public List<string> languages { get; set; }
        public List<string> nameOnTemplates { get; set; }
        public List<string> documentParts { get; set; }
        public List<string> environments { get; set; }
        public List<string> channels { get; set; }
        public List<Role> roles { get; set; }  
        public List<string> colorSchemes { get; set; }
        public List<string> templateListViewModes { get; set; }
        public List<string> systemSets { get; set; }
        public List<string> wordSystemSets { get; set; }
        public List<string> templateAuthors { get; set; }
        public List<string> letters { get; set; }
        public List<string> systemModes { get; set; }
        public List<string> processingTypes { get; set; }
        public List<string> templateLinkTypes { get; set; }
        public List<string> entryPages { get; set; }
        public List<string> isPersonalizeds { get; set; }
        public List<string> selfServices { get; set; }
        public List<string> isReviewedByTemplateSquads { get; set; }
    }

    public class Role
    {
        public List<string> externalIds { get; set; }
        public Accessrights accessRights { get; set; }
        public int value { get; set; }
        public string name { get; set; }
    }

    public class Accessrights
    {
        public bool canRead { get; set; }
        public bool canWrite { get; set; }
        public bool canDelete { get; set; }
        public bool canReadSensitive { get; set; }
        public bool canWriteSensitive { get; set; }
        public bool canWriteBusiness { get; set; }
        public bool canWriteTechnical { get; set; }
        public bool canWriteOther { get; set; }
        public int flags { get; set; }
    }

}
