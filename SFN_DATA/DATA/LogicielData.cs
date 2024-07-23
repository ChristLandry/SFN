using SFN_DATA.ENTITY;
using SFN_DATA.IDATA;
using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_DATA.DATA
{
    public class LogicielData : ILogicielData
    {
        private SFN_BDContext db;
        public LogicielData()
        {
        }
        public EntityLogiciel GetLogicielByCode(string code)
        {
            try
            {
                db = new();
                return db.EntityLogiciel.FirstOrDefault(a => a.CodeLogiciel == code);
            }
            catch (Exception ex)
            {
                //_logger.LogInformation("CLASS " + this.GetType().Name + " : Echec de GetAliasBy message de retour " + ex.Message + " " + numcompte);
                return null;
            }
        }

        public Reponse UpdateLogiciel(EntityLogiciel entityLogiciel)
        {
            try
            {
                db = new();
                var logiciel = db.EntityLogiciel.FirstOrDefault(a => a.CodeLogiciel == entityLogiciel.CodeLogiciel);
                if (logiciel != null)
                {
                    logiciel.TokenLogiciel = entityLogiciel.TokenLogiciel;
                    db.EntityLogiciel.Update(logiciel);
                    db.SaveChanges();
                    return new() { isSucces=true, msg=Message.Succes};
                }
                else
                {
                    return new() { isSucces = false, msg = Message.Echouer };
                }
            }
            catch (Exception ex)
            {
                return new() { isSucces = false, msg = Message.Echouer + " "+ ex.Message};
                //_logger.LogInformation("CLASS " + this.GetType().Name + " : Echec de GetAliasBy message de retour " + ex.Message + " " + numcompte);
                return null;
            }
        }
    }
}
