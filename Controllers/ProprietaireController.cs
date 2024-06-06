using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GSBAppartement.Domain.Personnes;
using GSBAppartement.Repository.Interfaces;
using GSBAppartement.Domain.Appartement;


namespace GSBAppartement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProprietaireController : ControllerBase
    {
        private readonly IProprietaireRepository _proprietaireRepository;

        public ProprietaireController(IProprietaireRepository proprietaireRepository)
        {
            _proprietaireRepository = proprietaireRepository;
        }



        [HttpGet]
        public async Task<IEnumerable<Proprietaire>> GetAll()
        {
            return await _proprietaireRepository.GetAllAsync();
        }

        [HttpGet("{idProprietaire}")]
        public async Task<ActionResult<Proprietaire>> GetById(Guid idProprietaire)
        {
            var proprietaire = await _proprietaireRepository.GetByIdAsync(idProprietaire);
            if (proprietaire == null)
            {
                return NotFound();
            }

            return proprietaire;
        }

        [HttpPost("/proprietaire/add")]
        public async Task<ActionResult<Proprietaire>> AddAsync(Proprietaire proprietaire)
        {
            if (proprietaire == null)
            {
                return BadRequest();
            }

            proprietaire.Appartements = new List<Appartement>();

            return await _proprietaireRepository.AddAsync(proprietaire);
        }







    }
}
