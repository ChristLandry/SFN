using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_MODEL.MODEL
{
    public class Reponse
    {
        public bool isSucces { get; set; }
        public string msg { get; set; }
    }

    public static class Constance
    {
        public static Guid? Null_Guid { get { return null; } }
        public static Guid Zero_Guid { get { return Guid.Parse("00000000-0000-0000-0000-000000000000"); } }
    }

    public static class Message
    {
        public static string Succes { get { return "Enregistrement effectué avec succès"; } }
        public static string EchouerDelete { get { return "Suppression échoué"; } }
        public static string SuccesDelete { get { return "Suppression effectué avec succès"; } }
        public static string Echouer { get { return "Enregistrement échoué"; } }
        public static string Existe { get { return "Enregistrement échoué, cet élément existe en base de données"; } }
        public static string Erreur { get { return "Enregistrement échoué, car une erreur a été générée"; } }
        public static string LoginFailed { get { return "Veuillez saisir un login et un mot de passe correct !"; } }
        public static string LoginFailedUser { get { return "L'utilisateur est soit désactivé, soit inexistant !"; } }
        public static string ControleLogin { get { return "Veuillez SVP saisir un identifiant et un mot de passe !"; } }
    }
}
