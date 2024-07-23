using Microsoft.IdentityModel.Tokens;
using SFN_BLL.IBLL;
using SFN_DATA.IDATA;
using SFN_MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SFN_BLL.BLL
{
    public class TokenBll : ITokenBll
    {
        private ILogicielBll _ILogicielBll;
        private IAuditData _IAuditData;
        public TokenBll(ILogicielBll logicielBll, IAuditData auditData)
        {
            _ILogicielBll = logicielBll;
            _IAuditData = auditData;
        }
        public object GetToken(JsonLogiciel _JsonLogiciel)
        {
            if (_JsonLogiciel == null)
            {

                //_logger.LogInformation("erreur de génération de token pour " + _JsonLogiciel.libelleLogiciel + ", message de retour Logiciel inexistant");
                return new { data = "Logiciel inexistant" };
            }
            try
            {
                var HostName_Port = "HostName:Port";
                string key = "525B298A-684C-4DDA-85E6-3A62B2412AD1"; //Secret key which will be used later during validation    
                var issuer = HostName_Port.Trim();  //normally this will be your site URL    

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //Create a List of Claims, Keep claims name short    
                var permClaims = new List<Claim>();
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                //_JsonLogiciel.TokenId = Guid.Parse(permClaims[0].Value);
                permClaims.Add(new Claim("code", _JsonLogiciel.codeLogiciel.Trim()));
                permClaims.Add(new Claim("idLogiciel", _JsonLogiciel.idLogiciel.ToString().Trim()));

                var tempsdevaliditerToken = double.Parse(_JsonLogiciel.tempsValiderToken.ToString());
                //Create Security Token object by giving required parameters    
                var token = new JwtSecurityToken(issuer, //Issure    
                                issuer,  //Audience    
                                permClaims,
                                expires: DateTime.Now.AddDays(tempsdevaliditerToken),
                                signingCredentials: credentials
                                );
                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                _JsonLogiciel.tokenLogiciel = jwt_token;

                //sauvegarde du token dans la BD
                var result = _ILogicielBll.UpdateLogiciel(_JsonLogiciel);
                if (result.isSucces)
                {
                    //_logger.LogTrace(jwt_token);
                    //_logger.LogInformation("Token générer pour " + _JsonLogiciel.libelleLogiciel);
                    return new { data = jwt_token };
                }
                else
                {
                    //_logger.LogInformation("erreur de génération de token pour " + _JsonLogiciel.libelleLogiciel + ", message de retour " + result.message);
                    return new { data = "error" };
                }
            }
            catch (Exception ex)
            {

                //_logger.LogInformation("erreur de génération de token pour " + _JsonLogiciel.libelleLogiciel + ", message de retour " + ex.Message);
                return new { data = "Message d'erreur: " + ex.Message };
            }
        }
    }
}
