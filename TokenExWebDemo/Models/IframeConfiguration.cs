using System.ComponentModel.DataAnnotations;

namespace TokenExWebDemo.Models
{
    public class IframeConfiguration
    {
        /// <summary>
        /// The fully qualified origin of your application
        /// </summary>
        [Required]
        public string Origin { get; set; }

        /// <summary>
        /// The timestamp when the authentication key was generated, in yyyyMMddHHmmss format. NOTE: This value must match the one provided when generating your Authentication Key.
        /// </summary>
        [Required]
        public string Timestamp { get; set; }

        /// <summary>
        /// Your TokenEx ID
        /// </summary>
        [Required]
        public string TokenExID { get; set; }

        /// <summary>
        /// The generated Authentication Key
        /// </summary>
        [Required]
        public string AuthenticationKey { get; set; }

        /// <summary>
        /// The JSON value of the Token Scheme to be used. NOTE: This must be the same as the Token Scheme used to create your Authentication Key.
        /// </summary>
        [Required]
        public int TokenScheme { get; set; }
    }
}