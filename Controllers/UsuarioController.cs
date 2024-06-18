using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bionet.Context;
using Microsoft.AspNetCore.Mvc;
using Bionet.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bionet.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly BionetContext _context;

        public UsuarioController(BionetContext context){
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Usuario), 200)]
        public IActionResult Create(Usuario usuario){
            _context.Add(usuario);
            _context.SaveChanges();
            //return CreatedAtAction(nameof(ObterPorId), new{id = usuario.Id}, usuario);
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id){
            var usuario = _context.Usuarios.Find(id);
            if(usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpGet("ObterPorEmail{email}")]
        public IActionResult ObterPorNome(string email){
            var usuarios = _context.Usuarios.Where(x => x.Email.Contains(email));
            
            if(usuarios.Count() == 0) return NotFound("Nenhum usuário encontrado.");
            //if(usuarios.Any()) return NotFound();
            return Ok(usuarios);
        }

        [HttpGet("ObterPorNumeroIdentificador{numeroIdentificador}")]
        public IActionResult ObterPorNumeroIdentificador(string numeroIdentificador){
            var usuarios = _context.Usuarios.Where(x => x.NumeroIdentificador.Contains(numeroIdentificador));
            if(usuarios.Count() == 0) return NotFound("Nenhum usuário encontrado.");
            //if(usuarios.Any()) return NotFound();
            return Ok(usuarios);
        }

        [HttpGet("ObterAtivos")]
        public IActionResult ObterAtivos(){

            var usuarios = _context.Usuarios.Where(x => x.Ativo == true);
            if(usuarios.Count() == 0) return NotFound("Nenhum usuário ativo encontrado.");
            return Ok(usuarios);
        }

        [HttpGet("ObterInativos")]
        public IActionResult ObterInativos(){

            var usuarios = _context.Usuarios.Where(x => x.Ativo == false);
            if(usuarios.Count() == 0) return NotFound("Nenhum usuário inativo encontrado.");
            return Ok(usuarios);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos(){
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario){
            var usuarioBanco = _context.Usuarios.Find(id);
            if (usuarioBanco == null) return NotFound();

            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Email = usuario.Email;
            usuarioBanco.Tipo = usuario.Tipo;
            usuarioBanco.NumeroIdentificador = usuario.Nome;
            usuarioBanco.Endereco = usuario.Endereco;
            usuarioBanco.Ativo = usuario.Ativo;

            _context.Usuarios.Update(usuarioBanco);
            _context.SaveChanges();
            return Ok(usuarioBanco);
          
            //return Ok();
        }
        [HttpPut("AlterarSenha{id}")]
        public IActionResult AlterarSenha(int id, string senhaNova){
            //Recebe senha nova criptografada.
            var usuarioBanco = _context.Usuarios.Find(id);
            if(usuarioBanco == null) return NotFound($"Usuário com id {id} não encontrado!");
            usuarioBanco.Senha = senhaNova;

            _context.Usuarios.Update(usuarioBanco);
            _context.SaveChanges();           
            return Ok("Senha alterada com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){
            var usuarioBanco = _context.Usuarios.Find(id);
            if (usuarioBanco == null) return NotFound();
            
            _context.Usuarios.Remove(usuarioBanco);
            _context.SaveChanges();
            string mensagemSucesso = $"Usuário com ID: {id} removido com sucesso!";
            return Ok(mensagemSucesso);
        }

        [HttpDelete("DeletarPorNumeroIdentificador{numeroIdentificador}")]
        public IActionResult DeletarPorNumeroIdentificador(string numeroIdentificador){            
             List<Usuario> usuarioBanco = _context.Usuarios.Where(x =>
             x.NumeroIdentificador == numeroIdentificador).ToList();
            if (usuarioBanco.Count == 0) return NotFound();
            _context.Usuarios.Remove(usuarioBanco[0]);
            _context.SaveChanges();
            return Ok();
        }

        



    }
}