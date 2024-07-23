using SFN_BLL.IBLL;
using SFN_DATA.ENTITY;
using SFN_DATA.IDATA;
using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_BLL.BLL
{
    public class LogicielBll : ILogicielBll
    {
        private ILogicielData data;
        private IAuditData _IAuditData;
        public LogicielBll(ILogicielData logicielData, IAuditData auditData)
        {
            data = logicielData;
            _IAuditData = auditData;
        }
        public JsonLogiciel GetLogicielByCode(string code)
        {
            try
            {
                var entity = data.GetLogicielByCode(code);
                return MappingEntityJson(entity);
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors de la récupération des informations du logiciel, Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "GetCompteByNumCompte"
                };
                _IAuditData.Post(jsonAudit);
                return new();
            }
        }

        public Reponse UpdateLogiciel(JsonLogiciel json)
        {
            try
            {
                var entity = MappingJsonEntity(json);
                var reponse = data.UpdateLogiciel(entity);
                if (reponse.isSucces)
                {
                    JsonAudit jsonAudit = new()
                    {
                        actionAudit = "logiciel MAJ avec succes, code logiciel " + json.codeLogiciel,
                        matriculeUser = "SYS000",
                        fonctAuditer = "UpdateLogiciel"
                    };
                    _IAuditData.Post(jsonAudit);
                }
                else
                {
                    JsonAudit jsonAudit = new()
                    {
                        actionAudit = "Echec de la MAJ du logiciel,code logiciel " + json.codeLogiciel + " ,Message : " + reponse.msg,
                        matriculeUser = "SYS000",
                        fonctAuditer = "UpdateLogiciel"
                    };
                    _IAuditData.Post(jsonAudit);
                }
                return reponse;
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors de la MAJ du logiciel : " + json.codeLogiciel + " , Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "UpdateLogiciel"
                };
                _IAuditData.Post(jsonAudit);
                return new() { isSucces = false, msg = jsonAudit.actionAudit };
            }
        }

        private JsonLogiciel MappingEntityJson(EntityLogiciel entity) {
            try
            {
                return new()
                {
                    codeLogiciel = entity.CodeLogiciel,
                    idLogiciel = entity.IdLogiciel,
                    tempsValiderToken = entity.TempsValiderToken,
                    tokenLogiciel = entity.TokenLogiciel,
                };
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors du mapping de données de l'entité vers le format json, Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "MappingEntityJson"
                };
                _IAuditData.Post(jsonAudit);
                return null;
            }
        }
        private EntityLogiciel MappingJsonEntity(JsonLogiciel json) {
            try
            {
                return new()
                {
                    CodeLogiciel = json.codeLogiciel,
                    IdLogiciel = json.idLogiciel,
                    TokenLogiciel = json.tokenLogiciel,
                };
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors du mapping de données du format json vers l'entité, Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "MappingJsonEntity Logiciel"
                };
                _IAuditData.Post(jsonAudit);
                return null;
            }
        }
    }
}
