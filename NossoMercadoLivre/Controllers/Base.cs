using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Repositories;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;

namespace NossoMercadoLivre.Controllers
{
    public abstract class Base : Controller
    {
        protected string GetUserId()
        {
            return User.FindFirstValue("id");
        }
    }
}
