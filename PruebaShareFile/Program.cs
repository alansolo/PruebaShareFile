using ShareFile.Api.Client;
using ShareFile.Api.Client.Security.Authentication.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace PruebaShareFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //var redirectUri = new Uri("https://secure.sharefile.com/oauth/oauthcomplete.aspx");

            //var state = Guid.NewGuid().ToString();

            var sfClient = new ShareFileClient("https://ppgindustries.sharefile.com/share/view/66482373c0dc4c48/fob2b3c3-f8ec-4de8-893c-5a1b8d4d02c3");

            var oua = new OAuthService(sfClient, "k697344", "Nala200531+*");


            var oauthToken = oua.PasswordGrantAsync("k697344", "Nala200531+*", "", "");

            // Add credentials and update sfClient with new BaseUri
            sfClient.AddOAuthCredentials(oua);
            sfClient.BaseUri = oauthToken.GetUri();

            //var sesion = sfClient.Sessions.Login();

            //var user = sfClient.Users.Get().ExecuteAsync();

            //var folder = sfClient.Items.Get().ExecuteAsync();

            //var oauthService = new OAuthService(sfClient, "[client_id]", "[client_secret]");

            //var authorizationUrl = oauthService.GetAuthorizationUrl("sharefile.com", "code", "clientId", redirectUri.ToString(),
            //        state);

            string usuarioSharePoint = "K697344";
            string passwordSharePoint = "Nala200531+*";

            string urlCompleto = "https://ppgindustries.sharefile.com/share/view/66482373c0dc4c48/fob2b3c3-f8ec-4de8-893c-5a1b8d4d02c3";
            string pathArchivoCompleto = "\\\\10.104.175.150\\Campania\\WSCampania\\Reporte\\7f70795a-788f-4f8b-83dc-db81459b2c29.pdf";

            using (WebClient client = new WebClient())
            {
               
                client.Credentials = new NetworkCredential(usuarioSharePoint, passwordSharePoint);
                client.UploadFile(urlCompleto, "PUT", pathArchivoCompleto);
                client.DownloadFile("\\\\10.104.175.150\\Campania\\WSCampania\\Reporte", "0 Indice Gral Powder.xls");
            }

        }
    }
}
