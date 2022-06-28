

using Domain.DTO;
using Domain.Models;
using Domain.RepositryInterfaces;
using Domain.Service.Interfaces;

namespace Domain.Service
{
    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository repository;

        public DepartamentService(IDepartamentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Departament>> AddWorkerToDepartament(int id, CreateWorkerDTO workerDTO)
        {
            return await repository.AddWorkerToDepartament(id, workerDTO);
        }

        public async Task CreateAsync(CreateDepartamentDTO departamentDTO)
        {
            await repository.CreateAsync(departamentDTO);
        }

        public async Task<IEnumerable<Departament>> DeleteAsync(int departamentId)
        {
            return await repository.DeleteAsync(departamentId);
        }

        public async Task<IEnumerable<Departament>> GetAllDepartamentsAsync()
        {
            return await repository.GetAllDepartamentsAsync();
        }

        public async Task<IEnumerable<Departament>> GetDepartamentsByIdAsync(int departamentId)
        {
            return await repository.GetDepartamentsByIdAsync(departamentId);
        }

        public async Task<Departament> GetDepartamentsByNameAsync(string departamentName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(int id, CreateDepartamentDTO departamentDTO)
        {
            return await repository.UpdateAsync(id, departamentDTO);
        }
    }
}
