using BirdsBE.Models;
using BirdsBE.Models.InputModel;
using BirdsBE.UnitOfWork;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Core
{
    public class ProcessCore : IProcessCore
    {
        private readonly IUnitOfWork unitOfWork;

        public ProcessCore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<OutPutModel> BirdRegister(Birds bird)
        {
            throw new NotImplementedException();
        }

        public Task<OutPutModel> CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public async Task<OutPutModel> CreateUser(Users user)
        {
            try
            {
                string id = GenerateNumericGuid();
                user.AccountId = id;
                user.Account.AccountId = id;

                var result = await unitOfWork.User.InsertUser(user);
                unitOfWork.Commit();
                bool success = result >= 0 ? true : false;

                OutPutModel response = new()
                {
                    ProcessID = Guid.NewGuid().ToString(),
                    Message = success ? "Usuario Crado con exito" : "Ocurrió un error al crear el usuario",
                    Success = success
                };

                return response;
            }
            catch (Exception ex)
            {
                unitOfWork.Dispose();
                throw new Exception(ex.Message);
            }
        }

        public async Task<OutPutModel> UpdateUser(Users user)
        {
            try
            {
                var result = await unitOfWork.User.UpdateUser(user.Alias);
                unitOfWork.Commit();
                bool success = result ? true : false;

                OutPutModel response = new()
                {
                    ProcessID = Guid.NewGuid().ToString(),
                    Message = success ? "Usuario Actualizado con exito" : "Ocurrió un error al actualizar el usuario",
                    Success = success
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<OutPutModel> UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        private string GenerateNumericGuid()
        {
            Guid guid = Guid.NewGuid(); // Generar un nuevo GUID

            // Obtener el arreglo de bytes del GUID
            byte[] guidBytes = guid.ToByteArray();

            // Convertir los bytes a una cadena numérica
            StringBuilder numericGuid = new StringBuilder();
            foreach (byte b in guidBytes)
            {
                numericGuid.Append(b.ToString("D3")); // D3 asegura que siempre tenga tres dígitos
            }

            return numericGuid.ToString();
        }

    }
}
