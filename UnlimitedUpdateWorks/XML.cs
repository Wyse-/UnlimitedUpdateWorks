using System;
using System.Windows.Forms;
using System.Xml;

namespace UnlimitedUpdateWorks
{
    /// <summary>
    /// This class contains the methods which handle the XML document "config.xml" used to load the default settings, which are user configurable and can be saved back to the XML file through the settings GUI.
    /// </summary>
    class XML
    {

        private static XmlDocument xmlFile = new XmlDocument();

        /// <summary>
        /// Loads XML file.
        /// </summary>
        /// <param name="file">Path and name of the xml file.</param>
        public static void LoadXML(string file)
        {
            try
            {
                xmlFile.Load(file);
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading config.xml");
                throw;
            }
        }

        /// <summary>
        /// Parses XML file.
        /// </summary>
        /// <returns>String array made of the contents of the XML file.</returns>
        public static string[] ParseXML()
        {
            try
            {
                string[] xmlData = new string[13];
                xmlData[0] = xmlFile.SelectSingleNode("//DefaultValues/CatalogURL/text()").Value;
                xmlData[1] = xmlFile.SelectSingleNode("//DefaultValues/TitleRegex/text()").Value;
                xmlData[2] = xmlFile.SelectSingleNode("//DefaultValues/ProductRegex/text()").Value;
                xmlData[3] = xmlFile.SelectSingleNode("//DefaultValues/DateRegex/text()").Value;
                xmlData[4] = xmlFile.SelectSingleNode("//DefaultValues/ProductFilter/text()").Value;
                xmlData[5] = xmlFile.SelectSingleNode("//DefaultValues/SecOnly/text()").Value;
                xmlData[6] = xmlFile.SelectSingleNode("//DefaultValues/IsCompatible/text()").Value;
                xmlData[7] = xmlFile.SelectSingleNode("//DefaultValues/IsInstalled/text()").Value;
                xmlData[8] = xmlFile.SelectSingleNode("//DefaultValues/AutoCheckInterval/text()").Value;
                xmlData[9] = xmlFile.SelectSingleNode("//DefaultValues/AutoCheck/text()").Value;
                xmlData[10] = xmlFile.SelectSingleNode("//DefaultValues/CheckOnStart/text()").Value;
                xmlData[11] = xmlFile.SelectSingleNode("//DefaultValues/Remind/text()").Value;
                xmlData[12] = xmlFile.SelectSingleNode("//DefaultValues/RemindInterval/text()").Value;


                return xmlData;
            }
            catch (Exception)
            {
                MessageBox.Show("Error parsing data from config.xml", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        /// <summary>
        /// Updates XML file with new values, provided as parameters.
        /// </summary>
        /// <param name="catalogUrl">URL of the Microsoft Update Catalog containing the search keywords.</param>
        /// <param name="titleRegex">Regular expression used to identify the line containing the update's full title.</param>
        /// <param name="productRegex">Regular expression used to identify the line containing the update's target product.</param>
        /// <param name="dateRegex">Regular expression used to identify the line containing the update's release date.</param>
        /// <param name="productFilter">Product name which is used to determine whether the update is compatible or not (this should match your OS; e.g. "Windows 7").</param>
        /// <param name="secOnly">Whether to filter out non "Security Only" updates or not.</param>
        /// <param name="isCompatible">Whether to filter out non incompatible (which do not match the product filter) updates or not.</param>
        /// <param name="isInstalled">Whether to filter out already installed updates or not.</param>
        /// <param name="autoCheckInterval">Update auto-checking interval (in minutes).</param>
        /// <param name="autoCheck">Whether to perform auto-cheking or not.</param>
        /// <param name="checkOnStart">Whether to check for updates on program start or not.</param>
        /// <param name="remind">Whether to use the remind function when updates are found or not. This is less CPU intensive than checking for updates.</param>
        /// <param name="remindInterval">Update remind interval (in minutes).</param>
        ///  
        public static void UpdateXML(string catalogUrl, string titleRegex, string productRegex, string dateRegex, string productFilter, string secOnly, string isCompatible, string isInstalled, string autoCheckInterval, string autoCheck, string checkOnStart, string remind, string remindInterval)
        {
            try
            {
                xmlFile.SelectSingleNode("//DefaultValues/CatalogURL/text()").Value = catalogUrl;
                xmlFile.SelectSingleNode("//DefaultValues/TitleRegex/text()").Value = titleRegex;
                xmlFile.SelectSingleNode("//DefaultValues/ProductRegex/text()").Value = productRegex;
                xmlFile.SelectSingleNode("//DefaultValues/DateRegex/text()").Value = dateRegex;
                xmlFile.SelectSingleNode("//DefaultValues/ProductFilter/text()").Value = productFilter;
                xmlFile.SelectSingleNode("//DefaultValues/SecOnly/text()").Value = secOnly;
                xmlFile.SelectSingleNode("//DefaultValues/IsCompatible/text()").Value = isCompatible;
                xmlFile.SelectSingleNode("//DefaultValues/IsInstalled/text()").Value = isInstalled;
                xmlFile.SelectSingleNode("//DefaultValues/AutoCheckInterval/text()").Value = autoCheckInterval;
                xmlFile.SelectSingleNode("//DefaultValues/AutoCheck/text()").Value = autoCheck;
                xmlFile.SelectSingleNode("//DefaultValues/CheckOnStart/text()").Value = checkOnStart;
                xmlFile.SelectSingleNode("//DefaultValues/Remind/text()").Value = remind;
                xmlFile.SelectSingleNode("//DefaultValues/RemindInterval/text()").Value = remindInterval;

                xmlFile.Save("config.xml");
            }
            catch (Exception)
            {
                MessageBox.Show("Error updating config.xml", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


    }
}
