using GSBAppartement.Domain.Personnes;
using GSBAppartement.Repository.Interfaces;
using GSBAppartement.Domain.Demande;
using Microsoft.AspNetCore.Mvc;
using GSBAppartement.Domain.Utility;

namespace GSBAppartement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> GetAll()
        {
            var clients = await _clientRepository.GetAllAsync();
            foreach (var client in clients)
            {
                var demandes = await _clientRepository.GetDemandesByClientIdAsync(client.ClientId);
                client.Demandes = demandes;
            }
            return clients;
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<Client>> GetById(Guid clientId)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }

        [HttpGet("demandes/")]
        public async Task<IEnumerable<Demande>> GetAllDemandes()
        {
            return await _clientRepository.GetAllDemandesAsync();
        }


        [HttpGet("{clientId}/demandes")]
        public async Task<IEnumerable<Demande>> GetDemandesByClientId(Guid clientId)
        {
            return await _clientRepository.GetDemandesByClientIdAsync(clientId);
        }

        [HttpDelete("{clientId}/delete")]
        public async Task<ActionResult> Delete(Guid clientId)
        {
            await _clientRepository.DeleteAsync(clientId);
            return NoContent();
        }


        [HttpPost("/demande/{demandeId}/accept")]
        public async Task<ActionResult> AcceptDemande(DemandeAcceptModel model)
        {
            try
            {
                await _clientRepository.AcceptDemandeAsync(model.DemandeId, model.ClientId, model.Rib);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("/client/add")]
        public async Task Add(Client client)
        {
            await _clientRepository.AddAsync(client);

        }
    }
}








