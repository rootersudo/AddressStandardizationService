using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressStandardizationService.models;


namespace AddressStandardizationService.Services
{
    public interface IDadataService
    {
        Task<AddressResponse> StandardizeAddressAsync(AddressRequest request);
    }
}
