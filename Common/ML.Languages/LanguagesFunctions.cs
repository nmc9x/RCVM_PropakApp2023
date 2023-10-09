using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Languages
{
    public class LanguagesFunctions
    {
        // set language interface 
        public static string GetTranslate(string input, string culture)
        {
            try
            {
                //                System.Reflection.Assembly curAsm = System.Reflection.Assembly.Load("Interface.Language");//.GetExecutingAssembly();
                //#if DEBUG
                //                foreach (string s in curAsm.GetManifestResourceNames())
                //                {
                //                    Console.WriteLine(s);
                //                }
                //#endif
                //
                string strResources = "ML.Languages.Languages";
                System.Resources.ResourceManager rm = new System.Resources.ResourceManager(strResources, System.Reflection.Assembly.GetExecutingAssembly());
                string output = rm.GetString(input, System.Globalization.CultureInfo.CreateSpecificCulture(culture));
                if (output.Trim().Length <= 0)
                {
                    output = input;
                }
                return output;
            }
            catch (Exception ex)
            {
                //Program.Setup.InterfaceLanguage = InterfaceLanguageFlag.English;
                return input;
            }
        }

        public static string GetTranslate(string input)
        {
            return GetTranslate(input, Languages.Culture.ToString());
        }
    }
}
