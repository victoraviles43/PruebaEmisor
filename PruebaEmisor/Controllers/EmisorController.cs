using BL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SL.Controllers
{
    [Route("api/emisor/")]
    [ApiController]
    public class EmisorController : ControllerBase
    {
        [EnableCors("CORS")]
        [Route("GetAll")]
        [HttpGet]
        public IActionResult Emisor()
        {

            ML.Result result = BL.Emisor.GetEmisores();

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("CORS")]
        [HttpGet]
        [Route("GetById{idEmisor}")]
        //GET api/asignatura/5
        public IActionResult SelectEmisor(string idEmisor)
        {
            ML.Result result = BL.Emisor.GetEmisor(idEmisor);

            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return NotFound();
            }
        }
        [EnableCors("CORS")]
        [HttpPost]
        [Route("Add")]
        public IActionResult InsertEmisor([FromBody] ML.Emisor emisor)
        {
            ML.Result result = BL.Emisor.InsertEmisor(emisor);
         ;

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("CORS")]
        [HttpPost]
        [Route("Update")]
        public IActionResult ActualizarEmisor(string idEmisor, [FromBody] ML.Emisor emisor)
        {

            ML.Result result = BL.Emisor.UpdateEmisor(emisor);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [EnableCors("CORS")]
        [HttpGet]
        [Route("Delete{IdEmisor}")]
        //GET api/asignatura/5
        public IActionResult EliminarEmisor(string IdEmisor)
        {
            ML.Emisor emisor = new ML.Emisor();
            emisor.idEmisor = IdEmisor;


            ML.Result result = BL.Emisor.DeleteEmisor(emisor);
         
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
