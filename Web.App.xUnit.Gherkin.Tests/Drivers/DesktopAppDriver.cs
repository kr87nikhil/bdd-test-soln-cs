using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.App.xUnit.Gherkin.Tests.Drivers;

internal abstract class DesktopAppDriver
{
}

internal class MacAppDriver : DesktopAppDriver
{
}

internal class WindowsAppDriver: DesktopAppDriver
{
}
