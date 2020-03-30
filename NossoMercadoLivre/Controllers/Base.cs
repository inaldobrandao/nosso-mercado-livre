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

        protected async Task<User> GetLoggedUser(IUserRepository userRepository)
        {
            return await userRepository.FindById(GetUserId());
        }

        public Action<Action> Transacao = delegate (Action func)
        {
            using TransactionScope transacao = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            func();
            transacao.Complete();
        };
    }
}
