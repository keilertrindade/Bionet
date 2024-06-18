using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bionet.Context;
using Bionet.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bionet.Controllers
{
    [ApiController]
    [Route("Coleta")]
    public class ColetaController : ControllerBase
    {
        private readonly BionetContext _context;
        public ColetaController (BionetContext context){
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coleta), 200)]
        public IActionResult Create (Coleta coleta){

            _context.Add(coleta);
            _context.SaveChanges();
            return Ok(coleta);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id){
            var coleta = _context.Coletas.Find(id);
            if (coleta == null) return NotFound();
            return Ok(coleta);
        }

        [HttpGet("ObterTodas")]
        public IActionResult ObterTodas(){
            var coletas = _context.Coletas.ToList();
            return Ok(coletas);
        }

        [HttpGet("ObterTodasPorUsuarioId{usuarioId}")]
        public IActionResult ObterTodasPorUsuarioId(int usuarioId){
            var coletas = _context.Coletas.Where(
                x => x.UsuarioCriador.Id == usuarioId
            );

            return Ok(coletas);
        }

        [HttpGet("ObterAtivas")]
        public IActionResult ObterAtivas(){
            
            return Ok();
        }

        [HttpGet("ObterInativas")]
        public IActionResult ObterInativas(){
            
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar (int id, Coleta coleta){
            var coletaBanco = _context.Coletas.Find(id);
            return Ok(coleta);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){
            var coletaBanco = _context.Coletas.Find();
            if(coletaBanco == null) return NotFound();
            _context.Coletas.Remove(coletaBanco);
            _context.SaveChanges();
            return Ok();
        }



    }
}