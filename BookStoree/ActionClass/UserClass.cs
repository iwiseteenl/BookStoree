using BookStoree.ActionClass.Account;
using BookStoree.Interface;
using BookStoree.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoree.ActionClass
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClass : IUser
    {
        private readonly BookstoreContext _context;
        private string? name;

        public UserClass(BookstoreContext context)
        {
            _context = context;
        }

        public List<string> AddAccount(AccountCreatecs account)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(account.phoneNumber))
                    return new List<string> { "Поле с номером телефона не заполнено" };

                if (account.phoneNumber.Length < 11)
                    return new List<string> { "Номер телефона не может быть меньше или больше 11 символов" };
                Client createUser = new Client()
                {

                    Name = account.Name,
                    PhoneNumber = account.phoneNumber,
                    EMail = account.Email,
                    Surname = account.surname

                };

                _context.Add(createUser);
                _context.SaveChanges();

                long ClientId = createUser.ClientId;

                Results.Created();
                return [$"Пользователь успешно создан Id - {ClientId}"];
            }
            catch (Exception)
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }
        }
        public List<Client> GetClient()
        {
            try
            {
                var data = _context.Clients.Where(u => u.Name == name).Select(x => new Client
                {
                    Name = x.Name,
                    EMail = x.EMail,
                    ClientId = x.ClientId,
                    PhoneNumber = x.PhoneNumber,
                    AddressId = x.AddressId,
                    Surname= x.Surname
                }
                 ).ToList();
                return (List<Client>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<Client> UpdateClients(string name, Client client)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClient(string name)
        {
            try
            {
                var data = _context.Clients.Where(u => u.Name == name).Select(x => new Client
                {
                    Name = x.Name,
                    EMail = x.EMail,
                    ClientId = x.ClientId,
                    PhoneNumber = x.PhoneNumber,
                    AddressId = x.AddressId,
                    Surname = x.Surname
                }
                ).ToList();
                return (List<Client>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public List<string> DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> DeleteClientDTO(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClientDTO(string name)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClientDTO()
        {
            throw new NotImplementedException();
        }

        public List<Client> UpdateClientsDTO(string name, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
