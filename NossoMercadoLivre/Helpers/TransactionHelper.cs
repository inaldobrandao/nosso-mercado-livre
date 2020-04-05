using System;
using System.Transactions;

namespace NossoMercadoLivre.Helpers
{
    public static class TransactionHelper
    {
        public static Action<Action> Transaction = delegate (Action func)
        {
            using TransactionScope transacao = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            func();
            transacao.Complete();
        };
    }
}
