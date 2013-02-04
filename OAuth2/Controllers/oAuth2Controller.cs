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
        private OAuth2Entities db = new OAuth2Entities();

        // GET api/oAuth2
        public IEnumerable<Token> GetTokens()
        {
            var tokens = db.Tokens.Include(t => t.Provision);
            return tokens.AsEnumerable();
        }

        // GET api/oAuth2/5
        public Token GetToken(Guid id)
        {
            Token token = db.Tokens.Find(id);
            if (token == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return token;
        }

        // PUT api/oAuth2/5
        public HttpResponseMessage PutToken(Guid id, Token token)
        {
            if (ModelState.IsValid && id == token.TokenId)
            {
                db.Entry(token).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/oAuth2
        public HttpResponseMessage PostToken(Token token)
        {
            if (ModelState.IsValid)
            {
                db.Tokens.Add(token);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, token);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = token.TokenId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/oAuth2/5
        public HttpResponseMessage DeleteToken(Guid id)
        {
            Token token = db.Tokens.Find(id);
            if (token == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Tokens.Remove(token);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, token);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}