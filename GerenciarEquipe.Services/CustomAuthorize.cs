using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciarEquipe.Services
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {

                context.Result = new RedirectResult("/Erro/Desautorizado"); // Give error controller or Url name
            }
            else
            {
                context.Result = new RedirectResult("/Login");
            }
        }
    }
}