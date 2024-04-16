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
            var proprietaires = await _proprietaireRepository.GetAllAsync();
            foreach (var proprietaire in proprietaires)
            {
                var appartements = await _proprietaireRepository.GetProprietaireAppartementsByIdAsync(proprietaire.ProprietaireId);
                proprietaire.Appartements = appartements;
            }


            return proprietaires;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proprietaire>> GetById(Guid id)
        {
            var proprietaire = await _proprietaireRepository.GetByIdAsync(id);
            if (proprietaire == null)
            {
                return NotFound();
            }
            proprietaire.Appartements = await _proprietaireRepository.GetProprietaireAppartementsByIdAsync(proprietaire.ProprietaireId);

            return proprietaire;
        }


        [HttpGet("/{id}/appartements")]
        public async Task<IEnumerable<Appartement>> GetProprietaireAppartementsByIdAsync(Guid idProprietaire)
        {
            var appartements = await _proprietaireRepository.GetProprietaireAppartementsByIdAsync(idProprietaire);

            return appartements;
        }



    }
}
