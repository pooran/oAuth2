using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OAuth2.Controllers
{
    public class oAuth2Controller : ApiController
    {
        private oAuthEntities db = new oAuthEntities();

        public Guid Authorize(Guid CustomerKey, Guid CustomerSecret)
        {
            Provision provision = db.Provisions.Where(x => x.CustomerId == CustomerKey && x.Secret == CustomerSecret).FirstOrDefault();
            if (provision == null) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            else
            {
                Token token = new Token();
                token.ExpiryDate = DateTime.Now.AddMinutes(30);
                token.TokenId = Guid.NewGuid();
                token.Provision = provision;
                token.ProvisionId = provision.ProvisionId;
                db.Tokens.Add(token);
                db.SaveChanges();
                return token.TokenId;
            }
        }

        public string  Validate(Guid id)
        {
            Token token = db.Tokens.Where(x => x.TokenId == id && x.ExpiryDate > DateTime.Now).FirstOrDefault();
            if (token == null) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.Unauthorized));
            else
            {
                Provision provision = db.Provisions.Where(x => x.ProvisionId == token.ProvisionId).FirstOrDefault();
                return provision.CustomAppData;
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}