using Hillerød_Sejlklub_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface ICommentRepo
    {
        List<Comment> ReturnAllCommentFromMembers();

        void RemoveComment();
        
    }
}
