using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AgendaContatos.Droid.BDPath))]
namespace AgendaContatos.Droid
{
    public class BDPath : IDatabasePath
    {
        public string GetPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, "bancoDados.db3");
        }
    }
}