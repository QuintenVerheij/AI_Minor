using Fysio_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Helpers
{
    public class PairingCodesHelper
    {
        private readonly FysioDbContext _fysioDbContext;
        private Random _random;
        public PairingCodesHelper(FysioDbContext fysioDbContext)
        {
            _fysioDbContext = fysioDbContext;
            _random = new Random();
        }

        public void New(string therapistId)
        {
            List<string> existingCodes = _fysioDbContext.PairingCodes.Select(pc => pc.Code).ToList();

            while (true)
            {
                string code = _random.Next(10000).ToString().PadLeft(5, '0');
                if (!existingCodes.Contains(code))
                {
                    _fysioDbContext.PairingCodes.Add(
                        new PairingCodes
                        {
                            TherapistId = therapistId,
                            Code = code
                        });
                    break;
                }
            }
        }
    }
}
