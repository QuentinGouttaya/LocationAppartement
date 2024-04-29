using GSBAppartement.Domain.Personnes;
using GSBAppartement.Repository.Interfaces;
using GSBAppartement.Domain.Appartement;
using Microsoft.AspNetCore.Mvc;


namespace GSBAppartement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocataireController : ControllerBase
    {
        private readonly ILocataireRepository _locataireRepository;

        public LocataireController(ILocataireRepository locataireRepository)
        {
            _locataireRepository = locataireRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<Locataire>> GetAll()
        {
            return await _locataireRepository.GetAllAsync();
        }


        [HttpGet("{locataireId}")]
        public async Task<ActionResult<Locataire>> GetById(Guid locataireId)
        {
            var locataire = await _locataireRepository.GetByIdAsync(locataireId);
            if (locataire == null)
            {
                return NotFound();
            }
            return locataire;
        }


        [HttpPost]
        public async Task<ActionResult<Locataire>> Add(Guid ClientId, string rib, Guid appartementId)
        {
            await _locataireRepository.AddAsync(ClientId, rib, appartementId);

            return CreatedAtAction(nameof(GetById), new { locataireId = ClientId }, ClientId);
        }


        [HttpDelete("{locataireId}")]
        public async Task<ActionResult> Delete(Guid locataireId)
        {
            await _locataireRepository.DeleteAsync(locataireId);
            return NoContent();
        }


    }
}


