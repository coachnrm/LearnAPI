using LearnAPI.Helper;
using LearnAPI.Modal;
using LearnAPI.Models;

namespace LearnAPI.Service
{
    public interface ICustomerService
    {
        Task<List<CustomerModal>> Getall();
        Task<CustomerModal> Getbycode(string code);
        Task<APIResponse> Remove(string code);
        Task<APIResponse> Create(CustomerModal data);
        Task<APIResponse> Update(CustomerModal data, string code);
    }
}