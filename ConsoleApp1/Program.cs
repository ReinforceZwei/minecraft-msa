using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Microsoft Account Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var x = new XboxLive();
            var m = new MinecraftWithXbox();

            var preAuth = x.PreAuth();

            var login = x.UserLogin(email, password, preAuth);

            var xbl = x.XblAuthenticate(login);

            var xsts = x.XSTSAuthenticate(xbl);

            string accessToken = m.LoginWithXbox(xsts.UserHash, xsts.Token);

            bool hasGame = m.UserHasGame(accessToken);

            if (hasGame)
            {
                var profile = m.GetUserProfile(accessToken);
                Console.WriteLine("Minecraft User Name: {0}", profile.UserName);
                Console.WriteLine("UUID: {0}", profile.UUID);
            }

            Console.ReadLine();
        }
    }

    
}
