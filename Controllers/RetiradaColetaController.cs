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
    [Route("RetiradaColeta")]
    public class RetiradaColetaController : ControllerBase
    {
        // GetAll; GetByUserId; GetByColetaId;
        // GetParaRetirada; GetRetiradas
        private readonly BionetContext _context;

        public RetiradaColetaController(BionetContext context){
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(RetiradaColeta retiradaColeta){
            
            _context.Add(retiradaColeta);
            _context.SaveChanges();
            return Ok();
        }


    }
}