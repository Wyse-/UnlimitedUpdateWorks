using System.IO;

namespace UnlimitedUpdateWorks
{
    /// <summary>
    /// This class contains the methods which handle the update filtering.
    /// </summary>
    class UpdateFilters
    {
        /// <summary>
        /// Determines if a given update is already installed by checking for regular expression matches of the KB number in the WindowsUpdate.log file.
        /// </summary>
        /// <remarks>
        /// This is not the most efficient way to do this (for example if the update is installed with wusa.exe in the command line and logging is not enabled it will not show up in the log;
        /// however it's the least CPU intensive way I know of.
        /// </remarks>
        /// <param name="kb">KB number of the update.</param>
        /// <returns>
        /// True if the given update is installed.
        /// False if it's not installed.
        /// </returns>
        public static bool IsInstalled(string kb)
        {
            using (StreamReader str = new StreamReader(@"C:\Windows\WindowsUpdate.log"))
            {
                System.Text.RegularExpressions.Regex rgxKB = new System.Text.RegularExpressions.Regex(kb);
                string line;

                while ((line = str.ReadLine()) != null)
                {
                    if (rgxKB.IsMatch(line))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if an update is compatible. This is done by checking if the update's target product matches the reference product (i.e. the product filter value in the GUI).
        /// </summary>
        /// <param name="product">The target product of the update.</param>
        /// <param name="referenceProduct">Product name contained in the product filter.</param>
        /// <returns>
        /// True if the update is compatible.
        /// False if it's not compatible.
        /// </returns>
        public static bool IsCompatible(string product, string referenceProduct)
        {
            if (product == referenceProduct)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines if an update is security only. This is done by checking if its name contains the regular expression "Security Only".
        /// </summary>
        /// <param name="title">The full title of the update.</param>
        /// <returns>
        /// True if the update is security only.
        /// False if it's not security only.
        /// </returns>
        public static bool IsSecOnly(string title)
        {
            System.Text.RegularExpressions.Regex rgxSecOnly = new System.Text.RegularExpressions.Regex("Security Only");
            if (rgxSecOnly.IsMatch(title))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
