using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MobileGame.Services.AndroidDbPathService
{
    internal class AndroidDbPAth : IPath
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.Personal),filename);
        }
    }
}
