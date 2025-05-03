namespace RedesSociaisApp.Application.Responses;

public record AlterarContaResponse (
   int Id, 
   string NomeCompleto, 
   DateTime DataNasc, 
   string Telefone
);
