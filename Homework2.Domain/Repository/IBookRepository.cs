using Homework2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Domain.Repository
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        //select Author with him books 
        Task<Book?> BookWithCommentAsync(int id);
    }
}
