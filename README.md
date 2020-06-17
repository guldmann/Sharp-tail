# Sharp-tail
Sharp-tail is a attempt to write a C# win-forms log reader.
To get faster text render a UWP ListBoxControl is used to render log data.

### Current version
Alpha 1 

## What do sharp-tail do so far.
Read user selected files and shows it in a "logView" sharp-tail will then monitor files for changes.
*	Tail files, If changes appear in file new rows will get added to the "logView".
*	Monitored files will get presented in tabs, when non focused tab get changes to log file tab will change colour.
*	Colure “rules” to find and highlight log rows matching rule with set colure.
*	Filter out rows matching colure rules to only show rows of interest.
*	Go to end, will keep last log row in focus.
*   Remember last opened files and ask user to reopen files at start.
*   Search and focus on row containing search word.
*   Right click on tab to rename it.
*   Save open files as a group for fast reopen.
*   Open all files in a folder by drag and drop or by menu 



### Keayboard shortcuts

* [F11] Toggle full screen 
* [ctrl] + mouse wheel zoom in and out 
* [+] Zoom in on text
* [-] Zoom out on text
* [CTRL] + [T] Toggle filter text
* [CTRL] + [C] Copy marked text
* [CTRL] + [F]  Open Find
* [F3]  Find next
* [CTRL] + [E] Go to end (stay at last line when file update)