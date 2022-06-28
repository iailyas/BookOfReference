

using Domain.DTO;
using Domain.Models;

namespace Domain.Service.Interfaces
{
    public interface IDepartamentService
    {
        public Task CreateAsync(CreateDepartamentDTO departamentDTO);
        public Task<IEnumerable<Departament>> GetAllDepartamentsAsync();
        public Task<IEnumerable<Departament>> GetDepartamentsByIdAsync(int departamentId);
        public Task<Departament> GetDepartamentsByNameAsync(string departamentName);
        public Task<int> UpdateAsync(int id, CreateDepartamentDTO departamentDTO);
        public Task<IEnumerable<Departament>> DeleteAsync(int departamentId);
        public Task<IEnumerable<Departament>> AddWorkerToDepartament(int id, CreateWorkerDTO workerDTO);
    }
}
