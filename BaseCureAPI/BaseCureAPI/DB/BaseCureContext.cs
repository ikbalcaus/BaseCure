using System;
using System.Collections.Generic;
using BaseCureAPI.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BaseCureAPI.DB
{
    public partial class BasecureContext : DbContext
    {
        public BasecureContext()
        {
        }

        public BasecureContext(DbContextOptions<BasecureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthToken> AuthTokens { get; set; } = null!;
        public virtual DbSet<Dijagnoze> Dijagnozes { get; set; } = null!;
        public virtual DbSet<Gradovi> Gradovis { get; set; } = null!;
        public virtual DbSet<Korisnici> Korisnicis { get; set; } = null!;
        public virtual DbSet<LaboratorijskiRezultati> LaboratorijskiRezultatis { get; set; } = null!;
        public virtual DbSet<Lijekovi> Lijekovis { get; set; } = null!;
        public virtual DbSet<Ljekari> Ljekaris { get; set; } = null!;
        public virtual DbSet<Napomene> Napomenes { get; set; } = null!;
        public virtual DbSet<Narudzbe> Narudzbes { get; set; } = null!;
        public virtual DbSet<Osoblje> Osobljes { get; set; } = null!;
        public virtual DbSet<Pacijenti> Pacijentis { get; set; } = null!;
        public virtual DbSet<Poruke> Porukes { get; set; } = null!;
        public virtual DbSet<Pregledi> Pregledis { get; set; } = null!;
        public virtual DbSet<Recepti> Receptis { get; set; } = null!;
        public virtual DbSet<Terapije> Terapijes { get; set; } = null!;
        public virtual DbSet<Termini> Terminis { get; set; } = null!;
        public virtual DbSet<TipoviUstanova> TipoviUstanovas { get; set; } = null!;
        public virtual DbSet<Uloge> Uloges { get; set; } = null!;
        public virtual DbSet<UstanoveZdravstva> UstanoveZdravstvas { get; set; } = null!;
        public virtual DbSet<ZdravstveniKartoni> ZdravstveniKartonis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Basecure;Trusted_Connection=true;User ID=;Password=;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthToken>(entity =>
            {
                entity.ToTable("AuthToken");

                entity.Property(e => e.AuthTokenId)
                    .ValueGeneratedNever()
                    .HasColumnName("auth_token_id");

                entity.Property(e => e.Code2f)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("code2f");

                entity.Property(e => e.IpAdresa)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ip_adresa");

                entity.Property(e => e.Is2fOtkljucan)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("is_2f_otkljucan");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.Vrijednost)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("vrijednost");

                entity.Property(e => e.VrijemeEvidentiranja)
                    .HasColumnType("datetime")
                    .HasColumnName("vrijeme_evidentiranja");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.AuthTokens)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK__AuthToken__koris__160F4887");
            });

            modelBuilder.Entity<Dijagnoze>(entity =>
            {
                entity.HasKey(e => e.DijagnozaId)
                    .HasName("PK__Dijagnoz__A34E4E8C5BD7A785");

                entity.ToTable("Dijagnoze");

                entity.Property(e => e.DijagnozaId)
                    .ValueGeneratedNever()
                    .HasColumnName("dijagnoza_id");

                entity.Property(e => e.DatumDijagnoze)
                    .HasColumnType("date")
                    .HasColumnName("datum_dijagnoze");

                entity.Property(e => e.NazivDijagnoze)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("naziv_dijagnoze");
            });

            modelBuilder.Entity<Gradovi>(entity =>
            {
                entity.HasKey(e => e.GradId)
                    .HasName("PK__Gradovi__F8C78A45807D5559");

                entity.ToTable("Gradovi");

                entity.Property(e => e.GradId)
                    .ValueGeneratedNever()
                    .HasColumnName("grad_id");

                entity.Property(e => e.Entitet)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("entitet");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.KorisnikId)
                    .HasName("PK__Korisnic__B84D9F56A69A8486");

                entity.ToTable("Korisnici");

                entity.Property(e => e.KorisnikId)
                    .ValueGeneratedNever()
                    .HasColumnName("korisnik_id");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("adresa");

                entity.Property(e => e.BrojTelefona)
                    .HasMaxLength(25)
                    .HasColumnName("broj_telefona");

                entity.Property(e => e.Code2fa)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("code2fa");

                entity.Property(e => e.DatumRodjenja)
                    .HasColumnType("date")
                    .HasColumnName("datum_rodjenja");

                entity.Property(e => e.GradId).HasColumnName("grad_id");

                entity.Property(e => e.HashLozinke)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("hash_lozinke");

                entity.Property(e => e.Ime)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ime");

                entity.Property(e => e.MailAdresa)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("mail_adresa");

                entity.Property(e => e.OsobljeId).HasColumnName("osoblje_id");

                entity.Property(e => e.Prezime)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("prezime");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Korisnicis)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK__Korisnici__grad___44CA3770");

                entity.HasOne(d => d.Osoblje)
                    .WithMany(p => p.Korisnicis)
                    .HasForeignKey(d => d.OsobljeId)
                    .HasConstraintName("FK__Korisnici__osobl__45BE5BA9");

                entity.Property(e => e.KonekcijskiId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("konekcijski_id");
            });

            modelBuilder.Entity<LaboratorijskiRezultati>(entity =>
            {
                entity.HasKey(e => e.RezultatId)
                    .HasName("PK__Laborato__FB858D87442E1142");

                entity.ToTable("LaboratorijskiRezultati");

                entity.Property(e => e.RezultatId)
                    .ValueGeneratedNever()
                    .HasColumnName("rezultat_id");

                entity.Property(e => e.DatumAnalize)
                    .HasColumnType("datetime")
                    .HasColumnName("datum_analize");

                entity.Property(e => e.KartonId).HasColumnName("karton_id");

                entity.Property(e => e.RezultatiAnalize)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rezultati_analize");

                entity.Property(e => e.VrstaAnalize)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("vrsta_analize");

                entity.HasOne(d => d.Karton)
                    .WithMany(p => p.LaboratorijskiRezultatis)
                    .HasForeignKey(d => d.KartonId)
                    .HasConstraintName("FK__Laborator__karto__46E78A0C");
            });

            modelBuilder.Entity<Lijekovi>(entity =>
            {
                entity.HasKey(e => e.LijekId)
                    .HasName("PK__Lijekovi__0C12572B97C36743");

                entity.ToTable("Lijekovi");

                entity.Property(e => e.LijekId)
                    .ValueGeneratedNever()
                    .HasColumnName("lijek_id");

                entity.Property(e => e.Cijena).HasColumnName("cijena");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("naziv");

                entity.Property(e => e.Opis)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("opis");

                entity.Property(e => e.Slika).HasColumnName("slika");

                entity.Property(e => e.UstanovaId).HasColumnName("ustanova_id");

                entity.Property(e => e.ZahtijevaRecept).HasColumnName("zahtijeva_recept");

                entity.HasOne(d => d.Ustanova)
                    .WithMany(p => p.Lijekovis)
                    .HasForeignKey(d => d.UstanovaId)
                    .HasConstraintName("FK__Lijekovi__ustano__2739D489");
            });

            modelBuilder.Entity<Ljekari>(entity =>
            {
                entity.HasKey(e => e.LjekarId)
                    .HasName("PK__Ljekari__1EDECCBAD0ACFBEC");

                entity.ToTable("Ljekari");

                entity.Property(e => e.LjekarId)
                    .ValueGeneratedNever()
                    .HasColumnName("ljekar_id");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.Opis)
                    .HasMaxLength(255)
                    .HasColumnName("opis");

                entity.Property(e => e.Specijalizacija)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("specijalizacija");

                entity.Property(e => e.UstanovaId).HasColumnName("ustanova_id");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Ljekaris)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK__Ljekari__korisni__1B9317B3");

                entity.HasOne(d => d.Ustanova)
                    .WithMany(p => p.Ljekaris)
                    .HasForeignKey(d => d.UstanovaId)
                    .HasConstraintName("FK__Ljekari__ustanov__1A9EF37A");

                entity.Property(e => e.Slika).HasColumnName("slika");
            });

            modelBuilder.Entity<Napomene>(entity =>
            {
                entity.HasKey(e => e.NapomenaId)
                    .HasName("PK__Napomene__4B9D0366746F933F");

                entity.ToTable("Napomene");

                entity.Property(e => e.NapomenaId)
                    .ValueGeneratedNever()
                    .HasColumnName("napomena_id");

                entity.Property(e => e.DatumKreiranja)
                    .HasColumnType("datetime")
                    .HasColumnName("datum_kreiranja");

                entity.Property(e => e.KartonId).HasColumnName("karton_id");

                entity.Property(e => e.NaslovNapomene)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("naslov_napomene");

                entity.Property(e => e.TekstNapomene)
                    .HasColumnType("text")
                    .HasColumnName("tekst_napomene");

                entity.HasOne(d => d.Karton)
                    .WithMany(p => p.Napomenes)
                    .HasForeignKey(d => d.KartonId)
                    .HasConstraintName("FK__Napomene__karton__49C3F6B7");
            });

            modelBuilder.Entity<Narudzbe>(entity =>
            {
                entity.HasKey(e => e.NarudzbaId)
                    .HasName("PK__Lijekovi__26E2BC6DD049B088");

                entity.ToTable("Narudzbe");

                entity.Property(e => e.NarudzbaId)
                    .ValueGeneratedNever()
                    .HasColumnName("narudzba_id");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(255)
                    .HasColumnName("adresa");

                entity.Property(e => e.BrojTelefona)
                    .HasMaxLength(25)
                    .HasColumnName("broj_telefona");

                entity.Property(e => e.DatumVrijeme)
                    .HasColumnType("datetime")
                    .HasColumnName("datum_vrijeme");

                entity.Property(e => e.GradId).HasColumnName("grad_id");

                entity.Property(e => e.ImePrezime)
                    .HasMaxLength(255)
                    .HasColumnName("ime_prezime");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.LijekId).HasColumnName("lijek_id");

                entity.Property(e => e.Mailadresa)
                    .HasMaxLength(255)
                    .HasColumnName("mailadresa");

                entity.Property(e => e.RedniBroj).HasColumnName("redni_broj");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Narudzbes)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK__Narudzbe__grad_i__6166761E");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Narudzbes)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK__LijekoviK__koris__3C34F16F");

                entity.HasOne(d => d.Lijek)
                    .WithMany(p => p.Narudzbes)
                    .HasForeignKey(d => d.LijekId)
                    .HasConstraintName("FK__LijekoviK__lijek__3D2915A8");
            });

            modelBuilder.Entity<Osoblje>(entity =>
            {
                entity.ToTable("Osoblje");

                entity.Property(e => e.OsobljeId)
                    .ValueGeneratedNever()
                    .HasColumnName("osoblje_id");

                entity.Property(e => e.LjekarId).HasColumnName("ljekar_id");

                entity.Property(e => e.PunoIme)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("puno_ime");

                entity.Property(e => e.UlogaId).HasColumnName("uloga_id");

                entity.Property(e => e.UstanovaId).HasColumnName("ustanova_id");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.Osobljes)
                    .HasForeignKey(d => d.UlogaId)
                    .HasConstraintName("FK__Osoblje__uloga_i__46B27FE2");

                entity.HasOne(d => d.Ustanova)
                    .WithMany(p => p.Osobljes)
                    .HasForeignKey(d => d.UstanovaId)
                    .HasConstraintName("FK__Osoblje__ustanov__2B3F6F97");
            });

            modelBuilder.Entity<Pacijenti>(entity =>
            {
                entity.HasKey(e => e.PacijentId)
                    .HasName("PK__Pacijent__2D69AC70C505BA07");

                entity.ToTable("Pacijenti");

                entity.Property(e => e.PacijentId)
                    .ValueGeneratedNever()
                    .HasColumnName("pacijent_id");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.KrvnaGrupa).HasMaxLength(5);

                entity.Property(e => e.Tezina).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Visina).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Pacijentis)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK__Pacijenti__koris__47A6A41B");
            });

            modelBuilder.Entity<Poruke>(entity =>
            {
                entity.HasKey(e => e.PorukaId)
                    .HasName("PK__Poruke__9D276F6D10459F44");

                entity.ToTable("Poruke");

                entity.Property(e => e.PorukaId)
                    .ValueGeneratedNever()
                    .HasColumnName("poruka_id");

                entity.Property(e => e.DatumVrijeme)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnName("datum_vrijeme");

                entity.Property(e => e.PosiljaocId).HasColumnName("posiljaoc_id");

                entity.HasOne(d => d.Posiljaoc)
                    .WithMany(p => p.PorukePosiljaocs)
                    .HasForeignKey(d => d.PosiljaocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Poruke__Posiljao__308E3499");

                entity.Property(e => e.PrimaocId).HasColumnName("primaoc_id");

                entity.HasOne(d => d.Primaoc)
                    .WithMany(p => p.PorukePrimaocs)
                    .HasForeignKey(d => d.PrimaocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Poruke__PrimaocI__318258D2");

                entity.Property(e => e.Poruka).HasColumnName("poruka");

                entity.Property(e => e.Procitana).HasColumnName("procitana");
            });

            modelBuilder.Entity<Pregledi>(entity =>
            {
                entity.HasKey(e => e.PregledId)
                    .HasName("PK__Pregledi__46C8583B2B340B33");

                entity.ToTable("Pregledi");

                entity.Property(e => e.PregledId)
                    .ValueGeneratedNever()
                    .HasColumnName("pregled_id");

                entity.Property(e => e.DatumPregleda)
                    .HasColumnType("datetime")
                    .HasColumnName("datum_pregleda");

                entity.Property(e => e.DijagnozaId).HasColumnName("dijagnoza_id");

                entity.Property(e => e.LjekarId).HasColumnName("ljekar_id");

                entity.Property(e => e.Rezultati)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rezultati");

                entity.HasOne(d => d.Dijagnoza)
                    .WithMany(p => p.Pregledis)
                    .HasForeignKey(d => d.DijagnozaId)
                    .HasConstraintName("FK__Pregledi__dijagn__34C8D9D1");

                entity.HasOne(d => d.Ljekar)
                    .WithMany(p => p.Pregledis)
                    .HasForeignKey(d => d.LjekarId)
                    .HasConstraintName("FK__Pregledi__ljekar__52593CB8");
            });

            modelBuilder.Entity<Recepti>(entity =>
            {
                entity.HasKey(e => e.ReceptId)
                    .HasName("PK__Recepti__4B832CF3F694F291");

                entity.ToTable("Recepti");

                entity.Property(e => e.ReceptId)
                    .ValueGeneratedNever()
                    .HasColumnName("recept_id");

                entity.Property(e => e.DatumReceptiranja)
                    .HasColumnType("date")
                    .HasColumnName("datum_receptiranja");

                entity.Property(e => e.LijekId).HasColumnName("lijek_id");

                entity.Property(e => e.LjekarId).HasColumnName("ljekar_id");

                entity.Property(e => e.TerapijaId).HasColumnName("terapija_id");

                entity.HasOne(d => d.Lijek)
                    .WithMany(p => p.Receptis)
                    .HasForeignKey(d => d.LijekId)
                    .HasConstraintName("FK__Recepti__lijek_i__4316F928");

                entity.HasOne(d => d.Ljekar)
                    .WithMany(p => p.Receptis)
                    .HasForeignKey(d => d.LjekarId)
                    .HasConstraintName("FK__Recepti__ljekar___534D60F1");

                entity.HasOne(d => d.Terapija)
                    .WithMany(p => p.Receptis)
                    .HasForeignKey(d => d.TerapijaId)
                    .HasConstraintName("FK__Recepti__terapij__440B1D61");
            });

            modelBuilder.Entity<Terapije>(entity =>
            {
                entity.HasKey(e => e.TerapijaId)
                    .HasName("PK__Terapije__DC77D19B375748D2");

                entity.ToTable("Terapije");

                entity.Property(e => e.TerapijaId)
                    .ValueGeneratedNever()
                    .HasColumnName("terapija_id");

                entity.Property(e => e.KartonId).HasColumnName("karton_id");

                entity.Property(e => e.KrajTerapije)
                    .HasColumnType("date")
                    .HasColumnName("kraj_terapije");

                entity.Property(e => e.NazivTerapije)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("naziv_terapije");

                entity.Property(e => e.PocetakTerapije)
                    .HasColumnType("date")
                    .HasColumnName("pocetak_terapije");

                entity.HasOne(d => d.Karton)
                    .WithMany(p => p.Terapijes)
                    .HasForeignKey(d => d.KartonId)
                    .HasConstraintName("FK__Terapije__karton__3B75D760");
            });

            modelBuilder.Entity<Termini>(entity =>
            {
                entity.HasKey(e => e.TerminId)
                    .HasName("PK__Termini__714C62A819DFE20A");

                entity.ToTable("Termini");

                entity.Property(e => e.TerminId)
                    .ValueGeneratedNever()
                    .HasColumnName("termin_id");

                entity.Property(e => e.DatumTermina)
                    .HasColumnType("datetime")
                    .HasColumnName("datum_termina");

                entity.Property(e => e.LjekarId).HasColumnName("ljekar_id");

                entity.Property(e => e.PacijentId).HasColumnName("pacijent_id");

                entity.Property(e => e.UstanovaId).HasColumnName("ustanova_id");

                entity.HasOne(d => d.Ljekar)
                    .WithMany(p => p.Terminis)
                    .HasForeignKey(d => d.LjekarId)
                    .HasConstraintName("FK__Termini__ljekar___5165187F");

                entity.HasOne(d => d.Pacijent)
                    .WithMany(p => p.Terminis)
                    .HasForeignKey(d => d.PacijentId)
                    .HasConstraintName("FK__Termini__pacijen__300424B4");

                entity.HasOne(d => d.Ustanova)
                    .WithMany(p => p.Terminis)
                    .HasForeignKey(d => d.UstanovaId)
                    .HasConstraintName("FK__Termini__ustanov__2F10007B");
            });

            modelBuilder.Entity<TipoviUstanova>(entity =>
            {
                entity.HasKey(e => e.TipUstanoveId)
                    .HasName("PK__TipoviUs__BBD5B854959A80EE");

                entity.ToTable("TipoviUstanova");

                entity.Property(e => e.TipUstanoveId)
                    .ValueGeneratedNever()
                    .HasColumnName("tip_ustanove_id");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<Uloge>(entity =>
            {
                entity.HasKey(e => e.UlogaId)
                    .HasName("PK__Uloge__03C8E0D87069389C");

                entity.ToTable("Uloge");

                entity.Property(e => e.UlogaId)
                    .ValueGeneratedNever()
                    .HasColumnName("uloga_id");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<UstanoveZdravstva>(entity =>
            {
                entity.HasKey(e => e.UstanovaId)
                    .HasName("PK__Ustanove__5C9BF779681C94EE");

                entity.ToTable("UstanoveZdravstva");

                entity.Property(e => e.UstanovaId)
                    .ValueGeneratedNever()
                    .HasColumnName("ustanova_id");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("adresa");

                entity.Property(e => e.BrojTelefona)
                    .HasMaxLength(25)
                    .HasColumnName("broj_telefona");

                entity.Property(e => e.CijenaDostave).HasColumnName("cijena_dostave");

                entity.Property(e => e.GradId).HasColumnName("grad_id");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.MailAdresa)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("mail_adresa");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("naziv");

                entity.Property(e => e.Opis)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("opis");

                entity.Property(e => e.Slika).HasColumnName("slika");

                entity.Property(e => e.TipUstanoveId).HasColumnName("tip_ustanove_id");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.UstanoveZdravstvas)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK__UstanoveZ__grad___4D5F7D71");

                entity.HasOne(d => d.TipUstanove)
                    .WithMany(p => p.UstanoveZdravstvas)
                    .HasForeignKey(d => d.TipUstanoveId)
                    .HasConstraintName("FK__UstanoveZ__tip_u__43D61337");
            });

            modelBuilder.Entity<ZdravstveniKartoni>(entity =>
            {
                entity.HasKey(e => e.KartonId)
                    .HasName("PK__Zdravstv__343D9B086C4B1945");

                entity.ToTable("ZdravstveniKartoni");

                entity.Property(e => e.KartonId)
                    .ValueGeneratedNever()
                    .HasColumnName("karton_id");

                entity.Property(e => e.DatumIzdavanja)
                    .HasColumnType("datetime")
                    .HasColumnName("datum_izdavanja");

                entity.Property(e => e.PacijentId).HasColumnName("pacijent_id");

                entity.Property(e => e.PregledId).HasColumnName("pregled_id");

                entity.Property(e => e.Sadrzaj)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("sadrzaj");

                entity.HasOne(d => d.Pacijent)
                    .WithMany(p => p.ZdravstveniKartonis)
                    .HasForeignKey(d => d.PacijentId)
                    .HasConstraintName("FK__Zdravstve__pacij__37A5467C");

                entity.HasOne(d => d.Pregled)
                    .WithMany(p => p.ZdravstveniKartonis)
                    .HasForeignKey(d => d.PregledId)
                    .HasConstraintName("FK__Zdravstve__pregl__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
