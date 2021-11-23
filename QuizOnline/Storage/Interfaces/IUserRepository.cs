using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUser(string name);
    }
}
