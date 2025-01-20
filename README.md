Duplicate File Remover
======================

> **A .NET Windows Forms app to quickly find duplicate files and put them in the recycle bin.**\
> **Use at your own risk** -- Always back up your data before trying any file-removal tool.

Table of Contents
-----------------

-   [Overview](https://github.com/SunsetQuest/Duplicate-File-Remover-for-Windows/edit/master/README.md#overview)
-   [Features](https://github.com/SunsetQuest/Duplicate-File-Remover-for-Windows/edit/master/README.md#features)
-   [Screenshots](https://github.com/SunsetQuest/Duplicate-File-Remover-for-Windows/edit/master/README.md#screenshots-optional)
-   [Usage](https://github.com/SunsetQuest/Duplicate-File-Remover-for-Windows/edit/master/README.md#usage)
-   [Technical Details](https://github.com/SunsetQuest/Duplicate-File-Remover-for-Windows/edit/master/README.md#technical-details)
-   [Disclaimer](https://github.com/SunsetQuest/Duplicate-File-Remover-for-Windows/edit/master/README.md#disclaimer)
-   [License](https://github.com/SunsetQuest/Duplicate-File-Remover-for-Windows/edit/master/README.md#license)
-   [Credits](https://github.com/SunsetQuest/Duplicate-File-Remover-for-Windows/edit/master/README.md#credits)



Overview
--------

**Duplicate File Remover** is a simple Windows Forms application written in C#. Its primary goal is to help you quickly scan selected folders for duplicate files and remove them (by sending them to your Recycle Bin). This project is open-source under the [MIT License](https://github.com/SunsetQuest/Duplicate-File-Remover-for-Windows/edit/master/README.md#license), so you're free to use, modify, and distribute it.

> **Warning**: The ability to delete files (even to the Recycle Bin) can be risky if you don't know what you're doing. Always keep a backup copy of your data before using any tool that can remove files.



Features
--------

-   **Folder selection**: Add multiple folders (and reorder them if desired).
-   **Progress feedback**: Watch a progress bar update as the app scans and hashes files.
-   **Partial and full hashing**: Quickly filter potential duplicates by file size or partial hash (4KB block) before confirming with a full hash.
-   **Hidden files toggle**: Scan or skip hidden files.
-   **Recycle Bin support**: Files you choose to remove get moved to the Recycle Bin (so there's an extra safety net).
-   **Results view**: Clearly displays duplicates in groups, letting you decide which to keep or delete.



Screenshots (Optional)
----------------------
![image](https://github.com/user-attachments/assets/69a2ca31-a991-476a-abe1-006e11d2a450)

![image](https://github.com/user-attachments/assets/979f57cf-d7cc-4ef5-a69f-da495a117603)

![image](https://github.com/user-attachments/assets/c992ac9c-1102-4292-a4fb-5cc9f21129b6)



Usage
-----

1.  **Download or clone** this repository.
2.  **Open** the `.sln` in Visual Studio (or your favorite C# IDE).
3.  **Build** and **run** the project.
4.  On the **"Select Folders"** tab:
    -   Add or remove folders you want to scan.
    -   Reorder them if needed.
    -   Check "Include hidden files" if you want to scan those.
5.  **Click** "Start Scan." The app will:
    -   Enumerate files.
    -   Compute partial hashes to find potential duplicates.
    -   Confirm duplicates by checking full file hashes for any colliding pairs.
6.  Once scanning completes, you'll see the **"Results"** tab:
    -   Files grouped by duplicates.
    -   By default, only the "extra" duplicates are checked for deletion.
    -   You can check or uncheck any files.
7.  Click **"Send Selected to Recycle Bin"** to remove them. A progress bar shows how many files are being processed.

> **Pro tip**: For very large sets of files (100k+), you may see slower performance. You can always let the app run in the background or modify the code to use additional batch strategies.

* * * * *

Technical Details
-----------------

-   **Technology**: C#, Windows Forms, .NET 7/8 (choose whichever you prefer).
-   **Partial Hash**: Reads the first 4 KB of each file to quickly group potential duplicates.
-   **Full Hash**: Uses MD5 for a final confirmation.
-   **Multi-threaded**: Scanning and file deletion can run on background threads, keeping the UI responsive.

You can modify the hashing algorithms, the chunk size, or the UI logic to suit your own needs.

* * * * *

Disclaimer
----------

**NO WARRANTY**: This tool is provided "as is." Always **back up your data**. The maintainers and contributors can't be responsible if you accidentally remove files you actually need, or if your cat decides to stomp on the keyboard at the worst possible moment. Use your powers responsibly!

* * * * *

License
-------

This project is licensed under the [MIT License](https://chatgpt.com/g/g-p-678d7d1dcb0c81918bd5d8e0315bc70f-duplicate-file-remover/c/LICENSE). In short, you can use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of this software, subject to the license terms in `LICENSE`.

* * * * *

Credits
-------

-   **Primary Code & Inspiration**: [ChatGPT](https://openai.com/blog/chatgpt)
-   **Additional Input & Testing**: Ryan Scott White
-   **Libraries Used**:
    -   .NET's built-in `MD5`
    -   Built-in Microsoft Visual Basic `FileSystem.DeleteFile` for sending to Recycle Bin

We hope this tool makes your life easier. If you find a bug, open an [issue](https://github.com/YourUsername/YourRepoName/issues) or submit a pull request!

:heart: Happy De-duplicating!
