using System;

namespace UnlimitedUpdateWorks
{
    /// <summary>
    /// This class defines the properties of the Update type.
    /// </summary>
    public class Update
    {
        public string Title { get; set; } // Full title of the update (e.g. "2018-01 Security Only Quality Update for Windows 7 for x64-based Systems (KB4056897)").
        public string KB { get; set; } // Knowledge Base number of the update (e.g. "KB4056897").
        public string Product { get; set; } // Target product of the update (e.g. "Windows 7").
        public DateTime Date { get; set; } // Release date of the update.
        public string HtmlID { get; set; } // Unique id which identifies the update in the Catalog's webpage. Only exposed in the HTML source code; can be used as a regular search parameter.
    }
}
