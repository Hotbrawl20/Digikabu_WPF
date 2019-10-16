using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DigikabuWPF
{
    class WebsiteCon
    {
        static string UN { get; set; }
        static string PW { get; set; }

        static HttpClient client = new HttpClient(new HttpClientHandler
        {
            AllowAutoRedirect = true,
            UseCookies = true,
            CookieContainer = new CookieContainer()
        });
        public static async Task<string> Einloggen(string username, string passwort)
        {
            UN = username;
            PW = passwort;
            try
            {
                var values = new Dictionary<string, string>
                 {
                 { "UserName", UN },
                 { "Password", PW }
                 };

                FormUrlEncodedContent content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://digikabu.de/Login/Proceed", content);

                var responseString = await response.Content.ReadAsStringAsync();


                if (responseString.Contains("Falscher Benutzername"))
                {
                    return "Falscher Benutzername oder Passwort!";
                }
                else
                {
                    return "Erfolgreich eingeloggt!";
                }
            }
            catch (Exception)
            {
                return "Konnte nicht mit server verbinden!";


            }
        }
        private static async void relog()
        {
            var values = new Dictionary<string, string>
                 {
                 { "UserName", UN },
                 { "Password", PW }
                 };

            FormUrlEncodedContent content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://digikabu.de/Login/Proceed", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> GetUNKL()
        {
            relog();
            string retval = string.Empty;
            var response = await client.GetAsync("https://digikabu.de/Main");

            var responseString = await response.Content.ReadAsStringAsync();
            if (!responseString.Contains("<input class=\"form - control\" type=\"password\" id=\"Password\" name=\"Password\" />"))
            {
                foreach (string s in responseString.Split('>'))
                {
                    //Content = Text
                    //Visibility = Visible
                    //Visibility.Visible = true
                    if (s.Contains(")</span"))
                    {
                        string[] split = s.Split(' ');
                        retval = fix(split[0]) + " " + fix(split[1]);
                        string klasse = split[2].Trim(new char[] { '(', ')' });
                        string[] klassesplit = klasse.Split(')');
                        retval +=";"+klassesplit[0];

                    }

                }
                
            }
            return retval;
        }
        static string fix(string toFix)
        {
            string ret = string.Empty;
            if (toFix.Contains("&#x"))
            {
                ret = toFix;
                ret = ret.Replace("&#xFC;", "ü");
                ret = ret.Replace("&#xDF;", "ß");
                ret = ret.Replace("&#xF6;", "ö");
                ret = ret.Replace("&#xE4;", "ä");
            }
            else
            {
                ret = toFix;
            }
            return ret;
        }
    }
}
