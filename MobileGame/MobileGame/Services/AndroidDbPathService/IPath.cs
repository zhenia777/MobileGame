using System;
using System.Collections.Generic;
using System.Text;

namespace MobileGame.Services.AndroidDbPathService
{
    internal interface IPath
    {
        string GetDatabasePath(string filename);
    }
}
