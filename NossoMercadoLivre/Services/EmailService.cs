using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Services.Interfaces;
using System;

namespace NossoMercadoLivre.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string title, string description, User userFrom, User userTo, string? urlRedirect)
        {
            Console.WriteLine(title + ": " + description + " \n" + urlRedirect + "\n From: " + userFrom.Username + " / To: " + userTo.Username);
        }
    }
}
