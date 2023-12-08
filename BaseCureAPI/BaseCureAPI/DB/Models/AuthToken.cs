using System.ComponentModel.DataAnnotations.Schema;

namespace BaseCureAPI.DB.Models
{
    public class AuthToken
    {
        public int AuthTokenID { get; set; }
        public string Vrijednost { get; set; }
        public virtual Korisnici? Korisnik { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string? IpAdresa { get; set; }
        public string Code2F { get; set; }
        public bool Is2FOtkljucan { get; set; }
    }
}
