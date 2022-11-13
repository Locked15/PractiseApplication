using PractiseApplication.Models;
using PractiseApplication.Models.Entities;
using System.Linq;

namespace PractiseApplication.Controllers
{
    /// <summary>
    /// Register controller class.
    /// Part of MVC-Architecture.
    /// </summary>
    class EntryPointController
    {
        #region Properties.

        /// <summary>
        /// Model of the page.
        /// Contains properties, that will be binded later.
        /// </summary>
        public EntryPointModel Model { get; set; } = null!;
        #endregion

        #region Contructors.

        /// <summary>
        /// Contructs a new instance of the object.
        /// </summary>
        public EntryPointController()
        {
            Model = new EntryPointModel()
            {
                SaveLogin = true,
                Login = string.Empty
            };
        }
        #endregion

        #region Functions.

        /// <summary>
        /// Tries to sign in with sent credentials.
        /// Seeks user with same data, that have been sent, then returns it.
        /// </summary>
        /// <param name="credentials">Data-pack with user information. Contains login and password.</param>
        /// <param name="user">Returned value. Contains found user. May be NULL, if user not found.</param>
        /// <returns>Success of the search.</returns>
        internal bool TryToSignIn((string? name, string password) credentials, out User? user)
        {
            user = BaseContext.Instance.Users.FirstOrDefault(u => u.Login == credentials.name && u.Password == credentials.password);

            return user != null;
        }
        #endregion
    }
}
