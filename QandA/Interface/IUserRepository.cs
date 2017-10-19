using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Interface
{
    public interface IUserRepository
    {
        UserEx GetUser(int Id);
        void Save(UserEx n);
    }
}
