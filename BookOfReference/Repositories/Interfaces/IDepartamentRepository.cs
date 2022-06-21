﻿using BookOfReference.DTO;
using BookOfReference.Models;

namespace BookOfReference.Repositories.Interfaces
{
    public interface IDepartamentRepository
    {
        public Task<int> CreateAsync(CreateDepartamentDTO departamentDTO);
        public Task<IEnumerable<Departament>> GetAllDepartamentsAsync();
        public Task<IEnumerable<Departament>> GetDepartamentsByIdAsync(int departamentId);
        public Task<Departament> GetDepartamentsByNameAsync(string departamentName);
        public Task<int> UpdateAsync(int id, CreateDepartamentDTO departamentDTO);
        public Task<IEnumerable<Departament>> DeleteAsync(int departamentId);
    }
}
