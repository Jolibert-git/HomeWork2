using Homework2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Domain.Repository
{
    public interface ICommentRepository: IGenericRepository<Comment>
    {
        //select comment with specific word
        Task<List<Comment>> SearchInComments(string keyword);
    }
}
