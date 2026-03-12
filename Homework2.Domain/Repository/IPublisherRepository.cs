using Homework2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Domain.Repository
{
    public interface IPublisherRepository: IGenericRepository<Publisher>
    {
        //select specific Publishers from specific contry
        Task<List<Publisher>> GetPublishersByCountryAsync(string country);
    }
}
