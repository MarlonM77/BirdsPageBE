using BirdsBE.Models;
using BirdsBE.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Core
{
    public interface IProcessCore
    {
        public Task<OutPutModel> CreateUser(Users user);
        public Task<OutPutModel> UpdateUser(Users user);
        public Task<OutPutModel> CreateAccount(Account account);
        public Task<OutPutModel> UpdateAccount(Account account);
        public Task<OutPutModel> BirdRegister(Birds bird);

    }
}
