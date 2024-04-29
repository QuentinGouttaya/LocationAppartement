using Microsoft.AspNetCore.Mvc;
using GSBAppartement.Domain.Appartement;
using GSBAppartement.Repository.Interfaces;
using GSBAppartement.Domain.Personnes;

namespace GSBAppartement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppartementController : ControllerBase
    {
        private readonly IAppartementRepository _appartementRepository;

        public AppartementController(IAppartementRepository appartementRepository)
        {
            _appartementRepository = appartementRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Appartement>> GetAll()
        {
            return await _appartementRepository.GetAllAsync();
        }

        [HttpGet("{appartementId}")]
        public async Task<ActionResult<Appartement>> GetById(Guid appartementId)
        {
            var appartement = await _appartementRepository.GetByIdAsync(appartementId);

            if (appartement == null)
            {
                return NotFound();
            }

            return appartement;
        }

        [HttpGet("/{idProprietaire}/appartements")]
        public async Task<IEnumerable<Appartement>> GetProprietaireAppartementsByIdAsync(Guid idProprietaire)
        {
            var appartements = await _appartementRepository.GetProprietairesAppartementsByIdAsync(idProprietaire);

            return appartements;
        }

        [HttpGet("{appartementId}/locataires")]
        public async Task<IEnumerable<Locataire>> GetLocatairesByAppartementId(Guid appartementId)
        {
            return await _appartementRepository.GetLocatairesByAppartementIdAsync(appartementId);
        }

    }
}
