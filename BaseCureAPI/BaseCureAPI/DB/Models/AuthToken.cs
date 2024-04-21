using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BaseCureAPI.DB.Models
{
    public partial class AuthToken
    {
        public int AuthTokenId { get; set; }
        public string? Vrijednost { get; set; }
        public DateTime? VrijemeEvidentiranja { get; set; }
        public string? IpAdresa { get; set; }
        public string? Code2f { get; set; }
        public string? Is2fOtkljucan { get; set; }
        public int? KorisnikId { get; set; }
        
        public virtual Korisnici? Korisnik { get; set; }
    }
}
