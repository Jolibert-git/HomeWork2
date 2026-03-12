using Homework2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Domain.Repository
{
    public interface IAuthorRepository: IGenericRepository<Author>
    {
        //select Author with him books 
        Task<Author?> GetAuthorBooks(int id);
    }
}
