using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    internal static class Parametros
    {
        public static string GetConnectionString()
        {
            string dbFile = @"C:\Users\altai\Documents\ProgramaGoDev.mdf";
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbFile};Integrated Security=True;Connect Timeout=60";
        }
    }
}
