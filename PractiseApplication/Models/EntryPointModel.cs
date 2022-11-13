namespace PractiseApplication.Models
{
    /// <summary>
    /// Model class for "EntryPoint" window.
    /// </summary>
    class EntryPointModel
    {
        /// <summary>
        /// Contains current user login.
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Constains current user password.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Allow program to save login, to fastly regenerate it on the next time?
        /// </summary>
        public bool SaveLogin { get; set; }

        /// <summary>
        /// Show password or not?
        /// </summary>
        public bool ShowPassword { get; set; }
    }
}
