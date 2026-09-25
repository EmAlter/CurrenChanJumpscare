# Curren-Chan Jumpscare
This is a simple jumpscare application for Windows that displays a video of Curren-Chan from Umamusume randomly on the screen.<br>

![Requires .NET 8.0](https://img.shields.io/badge/REQUIRES-.NET%208.0-512BD4?logo=dotnet&style=flat-square)

## Features
* **Randomized Intervals:** Set your own minimum and maximum time limits.
* **Audio Toggle:** Choose to play the jumpscare with or without sound.
* **Unobtrusive:** Runs silently in the background via the Windows System Tray.
* **Single Instance:** Prevents multiple instances from running simultaneously.

## Downloading and Running
Download the latest release. There are 2 options:

* CurrenChanJumpscare-FrameworkDependent.zip --> This version requires the .NET 8.0 Runtime to be installed on your system. You can download it from the official Microsoft website [.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* CurrenChanJumpscare-SelfContained.zip --> This version is self-contained and does not require any additional dependencies.

After downloading, extract the contents of the zip file to a folder of your choice. Then, run the `CurrenChanJumpscare.exe` file to start the application.

> **Note:** Windows or your antivirus software may flag the application as a potential threat. This is a common false positive due to:
> - The application being an unsigned executable (lacking a paid digital certificate).
> - The `.exe` being compiled as a single-file application, a behavior that often triggers heuristic security warnings.
> 
> You can safely ignore the warning (on Windows Defender, click **More info** -> **Run anyway**). The source code is entirely open and available in this repository for you to review.

When you open the application, you will see this window:<br>
![Settings Window](https://github.com/user-attachments/assets/c3683134-b8b5-40a3-9e09-0c20feaa6f1c)

Choose your preferred settings and click **Start in Background**.<br> 
The application will run in the background, you can exit or change the settings by clicking the icon in the system tray.

[![Buy Me a Coffee](https://img.shields.io/badge/Buy%20Me%20a%20Coffee-ffdd00?style=flat&logo=buy-me-a-coffee&logoColor=black)](https://www.buymeacoffee.com/emalter)
