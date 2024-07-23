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
    public class CompteData : ICompteData
    {
        private SFN_BDContext db;
        public CompteData()
        {
        }
        public Reponse CreateCompte(EntityCompte entityCompte)
        {
            try
            {
                db = new();
                var compte = db.EntityCompte.FirstOrDefault(a => a.NumCompte == entityCompte.NumCompte);
                if (compte == null)
                {
                    compte = new()
                    {
                        Adresse = entityCompte.Adresse,
                        DateCreation = DateTime.Now,
                        LibelleCompte = entityCompte.LibelleCompte,
                        NomAgence = entityCompte.NomAgence,
                        NumCompte = entityCompte.NumCompte,
                        NumeroCarte = entityCompte.NumeroCarte,
                        StatutCompte = entityCompte.StatutCompte,
                        TypeCompte = entityCompte.TypeCompte
                    };
                    db.EntityCompte.Add(compte);
                    db.SaveChanges();
                    return new() { isSucces = true, msg = Message.Succes };
                }
                else
                {
                    return new() { isSucces = false, msg = Message.Echouer };
                }
            }
            catch (Exception ex)
            {
                return new() { isSucces = false, msg = Message.Echouer + " " + ex.Message };
                //_logger.LogInformation("CLASS " + this.GetType().Name + " : Echec de GetAliasBy message de retour " + ex.Message + " " + numcompte);
                return null;
            }
        }

        public Reponse DeleteCompte(string numCompte)
        {
            try
            {
                db = new();
                var compte = db.EntityCompte.FirstOrDefault(a => a.NumCompte == numCompte);
                if (compte != null)
                {
                    db.EntityCompte.Remove(compte);
                    db.SaveChanges();
                    return new() { isSucces = true, msg = Message.SuccesDelete };
                }
                else
                {
                    return new() { isSucces = false, msg = Message.EchouerDelete };
                }
            }
            catch (Exception ex)
            {
                return new() { isSucces = false, msg = Message.EchouerDelete + " " + ex.Message };
                //_logger.LogInformation("CLASS " + this.GetType().Name + " : Echec de GetAliasBy message de retour " + ex.Message + " " + numcompte);
                return null;
            }

        }

        public EntityCompte GetCompteByNumCompte(string numCompte)
        {
            try
            {
                db = new();
                return db.EntityCompte.FirstOrDefault(a => a.NumCompte == numCompte);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<EntityCompte> GetListCompte(int PageIndex = 0, int PageSize = 10)
        {
            try
            {
                db = new();
                if (PageIndex == 1 || PageIndex == 0)
                {
                    return db.EntityCompte.Take(PageSize).ToList();
                }
                else
                {
                    return db.EntityCompte.Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Reponse UpdateCompte(EntityCompte entityCompte)
        {
            try
            {
                db = new();
                var compte = db.EntityCompte.FirstOrDefault(a => a.NumCompte == entityCompte.NumCompte);
                if (compte != null)
                {
                    compte.Adresse = entityCompte.Adresse;
                    compte.DateModification = DateTime.UtcNow;
                    compte.StatutCompte = entityCompte.StatutCompte;
                    db.EntityCompte.Update(compte);
                    db.SaveChanges();
                    return new() { isSucces = true, msg = Message.Succes };
                }
                else
                {
                    return new() { isSucces = false, msg = Message.Echouer };
                }
            }
            catch (Exception ex)
            {
                return new() { isSucces = false, msg = Message.Echouer + " " + ex.Message };
                //_logger.LogInformation("CLASS " + this.GetType().Name + " : Echec de GetAliasBy message de retour " + ex.Message + " " + numcompte);
                //return null;
            }
        }

        public string GenerateRandom(int size)
        {
            var num = GenerateRandomNum(size);
            db = new();
            var compte = db.EntityCompte.FirstOrDefault(a => a.NumCompte == num || a.NumeroCarte == num);
            while (compte != null)
            {
                num = GenerateRandomNum(size);
                compte = db.EntityCompte.FirstOrDefault(a => a.NumCompte == num || a.NumeroCarte == num);
            }
            return num;
        }

        #region Fonctioncomplementairestring GenerateRandom(int size);
        public string GenerateRandomNum(int size)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                builder.Append(random.Next(10));
            }
            return builder.ToString();
        }
        #endregion
    }
}
