using Fysio_API.Dto;
using Fysio_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API
{
    public class FysioRepository : IFysioRepository
    {
        private readonly FysioDbContext _fysioDbContext;
        public FysioRepository(FysioDbContext fysioDbContext)
        {
            _fysioDbContext = fysioDbContext;
        }

        public void AddClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            _fysioDbContext.Add(client);
            
        }

        public void AddTherapist(TherapistDto_In therapist)
        {
            throw new NotImplementedException();
        }

        public void AttachClientToTherapist(int clientId, int therapistId)
        {
            throw new NotImplementedException();
        }

        public Client GetClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClientsTherapist(int therapistId)
        {
            throw new NotImplementedException();
        }

        public Therapist GetTherapist(int therapistId)
        {
            throw new NotImplementedException();
        }
    }
}
