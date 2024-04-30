using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.Electron.xUnit.Gherkin.Tests.Drivers;


namespace Desktop.Electron.xUnit.Gherkin.Tests.Support;

internal interface IDriverFactory
{
    public abstract IDriver CreateDriver();
}
