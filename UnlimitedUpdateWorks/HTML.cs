using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace UnlimitedUpdateWorks
{
    /// <summary>
    /// This class contains the methods which handle the raw HTML obtained from the Microsoft Update catalog website.
    /// </summary>
    class HTML
    {
        /// <summary>
        /// Scrapes HTML from the given url.
        /// </summary>
        /// <remarks>
        /// This method is only able to scrape HTML from the given page and has no Javascript support.
        /// In the case of the Microsoft Update Catalog that means multiple pages of search results are not supported, and only the given one will be scraped.
        /// </remarks>
        /// <param name="url">Url to scrape HTML from.</param>
        /// <returns>Raw HTML scraped from the given url.</returns>
        public static string Scrape(string url)
        {
            string httpContent;

            try
            {
                WebClient client = new WebClient();
                httpContent = client.DownloadString(url);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to scrape HTML from provided URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return httpContent;
        }

        /// <summary>
        /// Parses update data from the supplied raw HTML by using multiple regular expressions.
        /// </summary>
        /// <param name="htmlContent">Raw HTML to parse update data from.</param>
        /// <param name="titleRegex">Regular expression used to match the update title line.</param>
        /// <param name="productRegex">Regular expression used to match the update target product line.</param>
        /// <param name="dateRegex">Regular expression used to match the update release date line.</param>
        /// <returns>A list containing all the parsed updates.</returns>
        public static List<Update> ParseUpdates(string htmlContent, string titleRegex, string productRegex, string dateRegex)
        {
            Update tempUpdate = new Update();
            List<Update> updatesList = new List<Update>();
            using (StringReader str = new StringReader(htmlContent))
            {
                string line;
                while ((line = str.ReadLine()) != null)
                {
                    if (Regex.DoesRegexMatch(titleRegex, line))
                    {
                        tempUpdate.Title = str.ReadLine().Trim(' ');
                        tempUpdate.KB = tempUpdate.Title.Split('(')[1].Trim(')');
                    }
                    if (Regex.DoesRegexMatch(productRegex, line))
                    {
                        tempUpdate.Product = str.ReadLine().Trim(' ');
                    }

                    if (Regex.DoesRegexMatch(dateRegex, line))
                    {
                        tempUpdate.Date = DateTime.Parse(str.ReadLine().Trim(' '));
                        updatesList.Add(tempUpdate);
                        tempUpdate = new Update();
                    }

                }
                return updatesList;

            }
        }
    }
}
