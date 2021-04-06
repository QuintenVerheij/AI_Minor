using Fysio_API.Dto;
using Fysio_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API
{
    interface IFysioRepository
    {
        void AddClient(Client client);
        Client GetClient(int clientId);
        IEnumerable<Client> GetClientsTherapist(int therapistId);

        void AddTherapist(Therapist therapist);
        Therapist GetTherapist(int therapistId);
        void AttachClientToTherapist(int clientId, int therapistId);

    }
}
