namespace NossoMercadoLivre.Models.ViewModels
{
    public class ErrorResponseViewModel
    {
        public Error Error { get; set; }
    }

    public class Error
    {
        public Error() { }

        public Error(string message, string type, int code)
        {
            this.Message = message;
            this.Type = type;
            this.Code = code;
        }

        /// <summary>
        /// Mensagem descrevendo o erro.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Tipo da exceção.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 100  Usuário já tem um certifiado valido para esse Login.
        /// 101  Login não encontrado.
        /// 102  Usuário não autenticado.
        /// 103  Usuário já integrou um cartão com esse login.
        /// 104  Parâmetro inválido.
        /// 105  Erro inesperado.
        /// 106  Erro na comunicação com o Nubank.
        /// 107  Esse cartão não possui categorias associadas ao Nubank. Ou não foi possível achar uma associação com as categorias do Nubank.
        /// 108  Login ou senha inválidos.
        /// 109  Código inválido.
        /// </summary>
        public int Code { get; set; }
    }
}
