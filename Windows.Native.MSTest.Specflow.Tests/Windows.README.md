# Windows - Test Automation (Open-Source)

## Microsoft UI Automation (UIA)
UIA is an excellent choice for stability, reliability, and future support within the Windows ecosystem. Its native integration and Microsoft's backing make it a strong contender. 
Available through the `System.Windows.Automation` namespace in .NET, providing direct access in your C# code.

<details>
<summary>Strength</summary>

* *Native*: Tightly integrated with the Windows UI framework, ensuring broad compatibility with most Windows applications.

* *Mature and Well-Maintained*: Backed by Microsoft, offering stability and ongoing updates. If you're comfortable with a more intricate API, UIA offers powerful control.
</details>

<details>
<summary>Consideration</summary>

* *Steeper Learning Curve*: Can have a complex API, especially for beginners.
</details></br>

**Reference**
* Overview: https://learn.microsoft.com/en-us/dotnet/framework/ui-automation/ui-automation-overview
* For Automated Testing: https://learn.microsoft.com/en-us/dotnet/framework/ui-automation/using-ui-automation-for-automated-testing
* Automation Client for Managed Code: https://learn.microsoft.com/en-us/dotnet/framework/ui-automation/ui-automation-clients-for-managed-code


## FlaUI
FlaUI wraps almost everything from Microsoft UI Automation, but also provides the native objects in case someone has a special need which is not covered (yet) by FlaUI. Some ideas are copied from the UIAComWrapper project or TestStack.White but rewritten from scratch to have a clean codebase.

<details>
<summary>Strength</summary>

* *Easy to Use*: Its API is considered approachable compared to Microsoft UI Automation (UIA), making it easier to learn for developers new to UI automation.
* *Cross-Platform Compatibility (Limited)*: While primarily focused on Windows, FlaUI attempts to provide some level of compatibility with other platforms like macOS through its UIA3 backend.
</details>

<details>
<summary>Shortcomings</summary>
* *Maturity*: Fewer resources (tutorials, examples) and potentially lower stability, especially for complex automation scenarios.
* *Limited Features*: Evaluate your specific automation needs to ensure FlaUI can handle them effectively.
</details></br>

**Reference**
* HYR Tutorials (YouTube): https://www.youtube.com/playlist?list=PLacgMXFs7kl_fuSSe6lp6YRaeAp6vqra9
* GitHub repository: https://github.com/FlaUI/FlaUI
* Lambda Test: https://www.lambdatest.com/automation-testing-advisor/csharp/FlaUI


## Windows Application Driver (WinAppDriver)
Windows Application Driver (WinAppDriver) is a service to support Selenium-like UI Test Automation on Windows Applications. This service supports testing Universal Windows Platform (UWP), Windows Forms (WinForms), Windows Presentation Foundation (WPF), and Classic Windows (Win32) apps.

<details>
<summary>Strength</summary>

* *Web Automation Expertise*: Leverages Selenium WebDriver, providing familiarity if you've worked with web automation.
* *Cross-Platform Potential*: WebDriver can be used for web and some desktop automation across platforms.
* *Active Development*: WinAppDriver, the Windows-specific implementation for WebDriver, has an active development community.
</details>

<details>
<summary>Consideration</summary>

* *Potential Compatibility Issues*: WinAppDriver might not be as universally compatible with native Windows apps as UIA.
* *Dependency on Third-Party Tools*: Relies on WebDriver and WinAppDriver, adding dependencies to manage.
* *Windows platform*: Compatible with only Windows 10 PCs as of this writing.
</details></br>

**Reference**
* GitHub repo - WinAppDriver: https://github.com/microsoft/WinAppDriver
* WinAppDriver UI Recorder Tool: https://github.com/microsoft/WinAppDriver/tree/master/Tools/UIRecorder
* Test Automation University (applitools): https://testautomationu.applitools.com/winappdriver-tutorial/
* BrowserStack (Appium WinAppDriver): https://www.browserstack.com/guide/test-windows-desktop-app-using-appium-winappdriver
