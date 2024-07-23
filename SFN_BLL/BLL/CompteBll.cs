using SFN_BLL.IBLL;
using SFN_DATA.DATA;
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
    public class CompteBll : ICompteBll
    {
        private ICompteData data;
        private IDecrypte _IDecrypte;
        private IAuditData _IAuditData;
        public CompteBll(ICompteData compteData, IAuditData auditData, IDecrypte decrypte) 
        { 
            data = compteData;
            _IAuditData = auditData;
            _IDecrypte = decrypte;
        }


        public Reponse CreateCompte(JsonCompte json)
        {
            try
            {
                var entity = MappingJsonEntity(json);
                var reponse = data.CreateCompte(entity);
                if (reponse.isSucces)
                {
                    JsonAudit jsonAudit = new()
                    {
                        actionAudit = "Compte créé avec succes, numéro de compte " + json.numCompte ,
                        matriculeUser = "SYS000",
                        fonctAuditer = "CreateCompte"
                    };
                    _IAuditData.Post(jsonAudit);
                }
                else
                {
                    JsonAudit jsonAudit = new()
                    {
                        actionAudit = "Echec de la création du compte, numéro de compte " + json.numCompte + " ,Message : " + reponse.msg,
                        matriculeUser = "SYS000",
                        fonctAuditer = "CreateCompte"
                    };
                    _IAuditData.Post(jsonAudit);
                }
                return reponse;
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors de la création du compte : "+ json.numCompte + " , Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "CreateCompte"
                };
                _IAuditData.Post(jsonAudit);
                return new() { isSucces = false, msg = jsonAudit.actionAudit };
            }
        }

        public Reponse DeleteCompte(string numCompte)
        {
            try
            {
                //var entity = MappingJsonEntity(json);
                var reponse = data.DeleteCompte(numCompte);
                if (reponse.isSucces)
                {
                    JsonAudit jsonAudit = new()
                    {
                        actionAudit = "Compte supprimé avec succes, numéro de compte " + numCompte,
                        matriculeUser = "SYS000",
                        fonctAuditer = "DeleteCompte"
                    };
                    _IAuditData.Post(jsonAudit);
                }
                else
                {
                    JsonAudit jsonAudit = new()
                    {
                        actionAudit = "Echec de la suppression du compte, numéro de compte " + numCompte + " ,Message : " + reponse.msg,
                        matriculeUser = "SYS000",
                        fonctAuditer = "DeleteCompte"
                    };
                    _IAuditData.Post(jsonAudit);
                }
                return reponse;
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors de la suppression du compte : " + numCompte + " , Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "DeleteCompte"
                };
                _IAuditData.Post(jsonAudit);
                return new() { isSucces = false, msg = jsonAudit.actionAudit };
            }
        }

        public string GenerateRandom(int size)
        {
            try
            {
                return data.GenerateRandom(size);
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors de la génération du numéro de compte ou du numéro de carte, Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "GenerateRandom"
                };
                _IAuditData.Post(jsonAudit);
                return null;
            }
        }

        public JsonCompte GetCompteByNumCompte(string numCompte)
        {
            try
            {
                var entity = data.GetCompteByNumCompte(numCompte);
                return MappingEntityJson(entity,false);
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors de la récupération des informations du compte, Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "GetCompteByNumCompte"
                };
                _IAuditData.Post(jsonAudit);
                return new();
            }
        }

        public List<JsonCompte> GetListCompte(int PageIndex = 0, int PageSize = 10)
        {
            try
            {
                List<JsonCompte> List = new();
                 var _list = data.GetListCompte(PageIndex,PageSize);
                foreach (var entity in _list)
                {
                    List.Add(MappingEntityJson(entity,true));
                }

                return List;
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors de la récupération de la liste des comptes, Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "GetListCompte"
                };
                _IAuditData.Post(jsonAudit);
                return null;
            }
        }

        public Reponse UpdateCompte(JsonCompte json)
        {
            try
            {
                var entity = MappingJsonEntity(json);
                var reponse = data.UpdateCompte(entity);
                if (reponse.isSucces)
                {
                    JsonAudit jsonAudit = new()
                    {
                        actionAudit = "Compte MAJ avec succes, numéro de compte " + json.numCompte,
                        matriculeUser = "SYS000",
                        fonctAuditer = "UpdateCompte"
                    };
                    _IAuditData.Post(jsonAudit);
                }
                else
                {
                    JsonAudit jsonAudit = new()
                    {
                        actionAudit = "Echec de la MAJ du compte, numéro de compte " + json.numCompte + " ,Message : " + reponse.msg,
                        matriculeUser = "SYS000",
                        fonctAuditer = "UpdateCompte"
                    };
                    _IAuditData.Post(jsonAudit);
                }
                return reponse;
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors de la MAJ du compte : " + json.numCompte + " , Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "UpdateCompte"
                };
                _IAuditData.Post(jsonAudit);
                return new() { isSucces = false, msg = jsonAudit.actionAudit };
            }
        }


        private JsonCompte MappingEntityJson(EntityCompte entity,bool isCrypte) {
            try
            {
                return new()
                {
                    adresse = entity.Adresse,
                    dateCreation = entity.DateCreation,
                    dateModification = entity.DateModification != null ? entity.DateModification.Value : null,
                    libelleCompte = entity.LibelleCompte,
                    nomAgence = entity.NomAgence,
                    numCompte = entity.NumCompte, 
                    numeroCarte = isCrypte == true? entity.NumeroCarte: _IDecrypte.DecryptStringAES(entity.NumeroCarte, "vfi05w5tz1") ,//fonction pour décrypter,
                    statutCompte = entity.StatutCompte,
                    typeCompte = entity.TypeCompte,
                    save = true
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
        private EntityCompte MappingJsonEntity(JsonCompte json) {
            try
            {
               return new()
                {
                    Adresse = json.adresse,
                    LibelleCompte = json.libelleCompte,
                    NomAgence = json.nomAgence,
                    NumCompte = json.numCompte,
                    NumeroCarte = _IDecrypte.EncryptStringAES(json.numeroCarte ,"vfi05w5tz1"),  // fonction pour crypter,
                    StatutCompte = json.statutCompte,
                    DateCreation = DateTime.Now,
                    DateModification = DateTime.Now,
                    TypeCompte = json.typeCompte,
                };   
            }
            catch (Exception ex)
            {
                JsonAudit jsonAudit = new()
                {
                    actionAudit = "Erreur lors du mapping de données du format json vers l'entité, Message d'erreur: " + ex.Message,
                    matriculeUser = "SYS000",
                    fonctAuditer = "MappingJsonEntity"
                };
                _IAuditData.Post(jsonAudit);
                return null;
            }
        }
    }
}
