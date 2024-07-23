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
    public class AuditData : IAuditData
    {
        private SFN_BDContext db;
        public AuditData()
        {
        }
        public List<EntityAudit> GetAllAudit(int PageIndex,int PageSize)
        {
            try
            {
                db = new SFN_BDContext();
                //return db.EntityAudit.Take(100).ToList();

                db = new();
                if (PageIndex == 1 || PageIndex == 0)
                {
                    return db.EntityAudit.Take(PageSize).ToList();
                }
                else
                {
                    return db.EntityAudit.Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Post(object audit)
        {
            try
            {
                db = new();
                var entity = (JsonAudit)audit;
                db.EntityAudit.Add(new()
                {
                    ActionAudit = entity.actionAudit,
                    DateCreationAudit = DateTime.Now,
                    IdAudit = Guid.NewGuid(),
                    MatriculeUser = entity.matriculeUser,
                    FonctAuditer = entity.fonctAuditer,
                });
                db.SaveChanges();
                //return new() { isSucces = true, msg = Message.Succes };
            }
            catch (Exception ex)
            {
                //_logger.LogInformation("CLASS AUDIT: message de retour " + ex.Message);
                //return new() { isSucces = false, msg = Message.Echouer };
            }
        }
    }
}
