// See https://aka.ms/new-console-template for more information

using REVChopp.Core;
using REVChopp.Data;

var repo = new UsuarioRepository();
var usuarios = repo.ListarUsuarios();

foreach (var u in usuarios)
{
    Console.WriteLine($"{u.Id}: {u.Nome} ({u.NivelAcesso})");
}

Sistema.MenuPrincipal();