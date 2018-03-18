# ![logo](https://i.imgur.com/7STCWxn.png) Unlimited Update Works



## Demo

![alt tag](https://i.imgur.com/jUr36rC.gif)

## Description
*Features:*
* This software checks for newly released “Security Only” Microsoft OS updates in the [Microsoft Update Catalog](https://www.catalog.update.microsoft.com/Home.aspx) and provides a non-intrusive balloon tip notification when new updates are found so they can be manually installed by the user: if the notification is clicked a web page searching for the found update on the Microsoft Update Catalog will be opened on the default browser. 
* The target OS of the default settings is Windows 7 x64, however it should work with all the Microsoft operating systems which receive security only updates (Windows Embedded Standard 7, Windows Embedded Standard 8, Windows Server 2008 R2, Windows Server 2012, Windows Server 2012 R2; I can’t seem to find security only updates for Windows 8/8.1 on the catalog, so I’m not sure about those) if properly configured.
* Checks if found updates are already installed.
* Does not rely on the Windows Update service.
* User configurable through a GUI accessible by right clicking the tray icon and clicking on “Manage”. The user configured values can be saved back to the config.xml file which will be loaded each time the program starts.
* Low CPU and memory usage: 0% CPU usage when idle, ~4% when checking for updates. *v1.1 Edit: actively using the newly implemented direct download link fetching capabilities (i.e. while fetching download links, not while idling) spawns an headless Chrome/Firefox process which will use the same ammount of resources as a normal web browser.*

**.NET Framework 4.6.1 or later is required.**

*What it doesn’t do:*
* It does not automatically download or install updates for you: you will need to open the Microsoft Update Catalog website by clicking the balloon tip or right clicking on the tray icon and clicking on “Update found” and proceed with manual download of the update and installation. *v1.1 Edit: while automatic update downloads or installs are still not possible automatic direct download link fetching has been implemented.*
* It does not support multiple pages of results.
* It does not check for updates released earlier than the current month. Technically this can be done manually through the update parser, but it’s highly inefficient: if you need to catch up on older updates you should use [WSUS Offline](http://download.wsusoffline.net/) (it also supports filtering out non security only updates).
* It doesn’t annoy you (unless you configure it to).

*Why:*

I, like many others, don’t like the direction in which Microsoft is heading. I believe keeping your OS fully patched with security updates is important, but with security updates I mean actual *security* updates which patch newly discovered exploits, not [telemetry](https://winaero.com/blog/telemetry-and-data-collection-are-coming-to-windows-7-and-windows-8-too/)  or [CPU blacklisting](https://arstechnica.com/information-technology/2017/04/new-processors-are-now-blocked-from-receiving-updates-on-old-windows/) updates which then get pushed to “Security Monthly Quality Rollups”.
There’s also the fact that the Windows Update service is incredibly buggy: it gets stuck constantly when checking for updates and sometimes it randomly uses a lot of CPU power while idling. I’d rather not deal with it anymore: nowadays I keep it disabled and enable it when I have to install an update.

*How:*

The update parsing is performed by scraping the raw HTML from the [Microsoft Update Catalog](https://www.catalog.update.microsoft.com/Home.aspx) search result pages ([like this one](https://www.catalog.update.microsoft.com/Search.aspx?q=2018-02%20Security%20Only%20Quality%20Update%20for%20Windows%207%20for%20x64-based%20Systems)
The keywords can be configured through the GUI (see below) and the placeholder keywords “YEAR” and “MONTH” will be replaced by the program with the current year and month: this is needed because the search terms need to be very specific to produce a single page of results and to only check recent updates.
The scraped HTML is then checked against the three different regular expressions (configurable in case Microsoft changes something in the catalog’s HTML) which identify the update title, kb number and release date.
*v1.1 Edit: Automatic direct download link fetching has been implemented through [Selenium](https://github.com/SeleniumHQ/selenium) with Chrome and Firefox support, and will automate the whole process of opening the web browser, clicking the downlod button and getting the direct link to the .msu file (the link will be copied to the clipboard).*


## GUI/Configuration
The GUI may seem a bit convoluted at first, here’s a few tips:
* Don’t touch the Regex textboxes unless something breaks in the future (chances are the program and/or the readme will probably be updated if this happens).
* I recommend [adding the software to system startup](https://www.howtogeek.com/208224/how-to-add-programs-files-and-folders-to-system-startup-in-windows-8.1/).
* If you want to be notified about Windows 7 x64 updates you don’t need to change the URL.
* If you want to be notified another OS’ updates edit this part of the URL: `Windows%207`. For example, for Windows Server 2008 R2 the URL should be `https://www.catalog.update.microsoft.com/Search.aspx?q=YEAR-MONTH%20Security%20Only%20Quality%20Update%20for%20Windows%20Server%202008%20R2%20for%20x64-based%20Systems`.
* The update parser tab is only supposed to be used to test your options or to force an update check.
* The “Use reminder instead of rechecking when updates are found” checkbox is there for a reason: checking for updates is a more CPU intensive task than reminding to install the previously found ones.

## Compiling & testing
This project has been compiled with Visual Studio Community 2017 and tested on Windows 7 x64.

## License
This software utilizes [Selenium](https://github.com/SeleniumHQ/selenium), which is published under the [Apache 2.0 License](https://github.com/Wyse-/UnlimitedUpdateWorks/blob/master/LICENSE_Selenium).

This software utilizes [Selenium.Firefox.WebDriver](https://github.com/jbaranda/nupkg-selenium-webdrivers) and [Selenium.WebDriver.ChromeDriver](https://github.com/jsakamoto/nupkg-selenium-webdriver-chromedriver/), both published under [The Unlicense](https://github.com/Wyse-/UnlimitedUpdateWorks/blob/master/LICENSE)
