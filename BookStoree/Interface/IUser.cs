using BookStoree.ActionClass.Account;
using BookStoree.Models;

namespace BookStoree.Interface
{
    public interface IUser
    {
        public List<string> AddAccount(AccountCreatecs account);

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> DeleteClient(int id);
        public List<Client> GetClient(string name);
        public List<Client> GetClientDTO();

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<Client> UpdateClients(string name, Client client);

        internal List<Client> GetClient()
        {
            throw new NotImplementedException();
        }
    }
}

   