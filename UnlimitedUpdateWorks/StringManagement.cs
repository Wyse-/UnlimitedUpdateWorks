using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnlimitedUpdateWorks
{
    class StringManagement
    {
        /// <summary>
        /// Replaces the placeholder "YEAR" and "MONTH" used in the Microsoft Update Catalog url with the current year and month.
        /// </summary>
        /// <param name="url">Microsoft Update Catalog url containing the keywords YEAR and MONTH.</param>
        /// <returns>The provided url with YEAR and MONTH replaced with the current year and month.</returns>
        public static string ReplaceYearMonth(string url)
        {
            string replacedUrl;
            replacedUrl = url.Replace("YEAR", DateTime.Now.Year.ToString());

            if (DateTime.Now.Month >= 1 && DateTime.Now.Month <= 9)
            {
                replacedUrl = replacedUrl.Replace("MONTH", "0" + DateTime.Now.Month.ToString());
            }
            else
            {
                replacedUrl = replacedUrl.Replace("MONTH", DateTime.Now.Month.ToString());
            }
            return replacedUrl;
        }
    }
}
