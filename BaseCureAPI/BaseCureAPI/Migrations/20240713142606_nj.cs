using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseCureAPI.Migrations
{
    public partial class nj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dijagnoze",
                columns: table => new
                {
                    dijagnoza_id = table.Column<int>(type: "int", nullable: false),
                    naziv_dijagnoze = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    datum_dijagnoze = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dijagnoz__A34E4E8C5BD7A785", x => x.dijagnoza_id);
                });

            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    grad_id = table.Column<int>(type: "int", nullable: false),
                    naziv = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    entitet = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Gradovi__F8C78A45807D5559", x => x.grad_id);
                });

            migrationBuilder.CreateTable(
                name: "TipoviUstanova",
                columns: table => new
                {
                    tip_ustanove_id = table.Column<int>(type: "int", nullable: false),
                    naziv = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoviUs__BBD5B854959A80EE", x => x.tip_ustanove_id);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    uloga_id = table.Column<int>(type: "int", nullable: false),
                    naziv = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Uloge__03C8E0D87069389C", x => x.uloga_id);
                });

            migrationBuilder.CreateTable(
                name: "UstanoveZdravstva",
                columns: table => new
                {
                    ustanova_id = table.Column<int>(type: "int", nullable: false),
                    naziv = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    adresa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    opis = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    tip_ustanove_id = table.Column<int>(type: "int", nullable: true),
                    grad_id = table.Column<int>(type: "int", nullable: true),
                    cijena_dostave = table.Column<float>(type: "real", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: true),
                    mail_adresa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    broj_telefona = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    image_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ustanove__5C9BF779681C94EE", x => x.ustanova_id);
                    table.ForeignKey(
                        name: "FK__UstanoveZ__grad___4D5F7D71",
                        column: x => x.grad_id,
                        principalTable: "Gradovi",
                        principalColumn: "grad_id");
                    table.ForeignKey(
                        name: "FK__UstanoveZ__tip_u__43D61337",
                        column: x => x.tip_ustanove_id,
                        principalTable: "TipoviUstanova",
                        principalColumn: "tip_ustanove_id");
                });

            migrationBuilder.CreateTable(
                name: "Lijekovi",
                columns: table => new
                {
                    lijek_id = table.Column<int>(type: "int", nullable: false),
                    naziv_lijeka = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    zahtijeva_recept = table.Column<bool>(type: "bit", nullable: true),
                    slika_lijeka = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ustanova_id = table.Column<int>(type: "int", nullable: true),
                    opis_lijeka = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    cijena_lijeka = table.Column<double>(type: "float", nullable: true),
                    kolicina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lijekovi__0C12572B97C36743", x => x.lijek_id);
                    table.ForeignKey(
                        name: "FK__Lijekovi__ustano__2739D489",
                        column: x => x.ustanova_id,
                        principalTable: "UstanoveZdravstva",
                        principalColumn: "ustanova_id");
                });

            migrationBuilder.CreateTable(
                name: "Osoblje",
                columns: table => new
                {
                    osoblje_id = table.Column<int>(type: "int", nullable: false),
                    puno_ime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ustanova_id = table.Column<int>(type: "int", nullable: true),
                    uloga_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoblje", x => x.osoblje_id);
                    table.ForeignKey(
                        name: "FK__Osoblje__uloga_i__46B27FE2",
                        column: x => x.uloga_id,
                        principalTable: "Uloge",
                        principalColumn: "uloga_id");
                    table.ForeignKey(
                        name: "FK__Osoblje__ustanov__2B3F6F97",
                        column: x => x.ustanova_id,
                        principalTable: "UstanoveZdravstva",
                        principalColumn: "ustanova_id");
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    korisnik_id = table.Column<int>(type: "int", nullable: false),
                    hash_lozinke = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    prezime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    adresa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    datum_rodjenja = table.Column<DateTime>(type: "date", nullable: true),
                    mail_adresa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    code2fa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    grad_id = table.Column<int>(type: "int", nullable: true),
                    osoblje_id = table.Column<int>(type: "int", nullable: true),
                    broj_telefona = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnic__B84D9F56A69A8486", x => x.korisnik_id);
                    table.ForeignKey(
                        name: "FK__Korisnici__grad___44CA3770",
                        column: x => x.grad_id,
                        principalTable: "Gradovi",
                        principalColumn: "grad_id");
                    table.ForeignKey(
                        name: "FK__Korisnici__osobl__45BE5BA9",
                        column: x => x.osoblje_id,
                        principalTable: "Osoblje",
                        principalColumn: "osoblje_id");
                });

            migrationBuilder.CreateTable(
                name: "AuthToken",
                columns: table => new
                {
                    auth_token_id = table.Column<int>(type: "int", nullable: false),
                    vrijednost = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    vrijeme_evidentiranja = table.Column<DateTime>(type: "datetime", nullable: true),
                    ip_adresa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    code2f = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    is_2f_otkljucan = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    korisnik_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthToken", x => x.auth_token_id);
                    table.ForeignKey(
                        name: "FK__AuthToken__koris__160F4887",
                        column: x => x.korisnik_id,
                        principalTable: "Korisnici",
                        principalColumn: "korisnik_id");
                });

            migrationBuilder.CreateTable(
                name: "Ljekari",
                columns: table => new
                {
                    ljekar_id = table.Column<int>(type: "int", nullable: false),
                    specijalizacija = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ustanova_id = table.Column<int>(type: "int", nullable: true),
                    korisnik_id = table.Column<int>(type: "int", nullable: true),
                    opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ljekari__1EDECCBAD0ACFBEC", x => x.ljekar_id);
                    table.ForeignKey(
                        name: "FK__Ljekari__korisni__4F7CD00D",
                        column: x => x.korisnik_id,
                        principalTable: "Korisnici",
                        principalColumn: "korisnik_id");
                    table.ForeignKey(
                        name: "FK__Ljekari__ustanov__5070F446",
                        column: x => x.ustanova_id,
                        principalTable: "UstanoveZdravstva",
                        principalColumn: "ustanova_id");
                });

            migrationBuilder.CreateTable(
                name: "Narudzbe",
                columns: table => new
                {
                    narudzba_id = table.Column<int>(type: "int", nullable: false),
                    korisnik_id = table.Column<int>(type: "int", nullable: true),
                    lijek_id = table.Column<int>(type: "int", nullable: true),
                    datum_vrijeme = table.Column<DateTime>(type: "datetime", nullable: true),
                    ime_prezime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    telefonski_broj = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    grad_id = table.Column<int>(type: "int", nullable: true),
                    adresa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    mailadresa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    redni_broj = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lijekovi__26E2BC6DD049B088", x => x.narudzba_id);
                    table.ForeignKey(
                        name: "FK__LijekoviK__koris__3C34F16F",
                        column: x => x.korisnik_id,
                        principalTable: "Korisnici",
                        principalColumn: "korisnik_id");
                    table.ForeignKey(
                        name: "FK__LijekoviK__lijek__3D2915A8",
                        column: x => x.lijek_id,
                        principalTable: "Lijekovi",
                        principalColumn: "lijek_id");
                    table.ForeignKey(
                        name: "FK__Narudzbe__grad_i__6166761E",
                        column: x => x.grad_id,
                        principalTable: "Gradovi",
                        principalColumn: "grad_id");
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    pacijent_id = table.Column<int>(type: "int", nullable: false),
                    Tezina = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Visina = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    KrvnaGrupa = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PritisakSistolicki = table.Column<int>(type: "int", nullable: true),
                    PritisakDistolicki = table.Column<int>(type: "int", nullable: true),
                    Pulz = table.Column<int>(type: "int", nullable: true),
                    Alergije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrenutneBolesti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RanijeBolesti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lijekovi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorodicnaAnamneza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavikePonasanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korisnik_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pacijent__2D69AC70C505BA07", x => x.pacijent_id);
                    table.ForeignKey(
                        name: "FK__Pacijenti__koris__47A6A41B",
                        column: x => x.korisnik_id,
                        principalTable: "Korisnici",
                        principalColumn: "korisnik_id");
                });

            migrationBuilder.CreateTable(
                name: "Pregledi",
                columns: table => new
                {
                    pregled_id = table.Column<int>(type: "int", nullable: false),
                    datum_pregleda = table.Column<DateTime>(type: "datetime", nullable: true),
                    rezultati = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dijagnoza_id = table.Column<int>(type: "int", nullable: true),
                    ljekar_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pregledi__46C8583B2B340B33", x => x.pregled_id);
                    table.ForeignKey(
                        name: "FK__Pregledi__dijagn__34C8D9D1",
                        column: x => x.dijagnoza_id,
                        principalTable: "Dijagnoze",
                        principalColumn: "dijagnoza_id");
                    table.ForeignKey(
                        name: "FK__Pregledi__ljekar__52593CB8",
                        column: x => x.ljekar_id,
                        principalTable: "Ljekari",
                        principalColumn: "ljekar_id");
                });

            migrationBuilder.CreateTable(
                name: "Termini",
                columns: table => new
                {
                    termin_id = table.Column<int>(type: "int", nullable: false),
                    datum_termina = table.Column<DateTime>(type: "datetime", nullable: true),
                    ustanova_id = table.Column<int>(type: "int", nullable: true),
                    pacijent_id = table.Column<int>(type: "int", nullable: true),
                    ljekar_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Termini__714C62A819DFE20A", x => x.termin_id);
                    table.ForeignKey(
                        name: "FK__Termini__ljekar___5165187F",
                        column: x => x.ljekar_id,
                        principalTable: "Ljekari",
                        principalColumn: "ljekar_id");
                    table.ForeignKey(
                        name: "FK__Termini__pacijen__300424B4",
                        column: x => x.pacijent_id,
                        principalTable: "Pacijenti",
                        principalColumn: "pacijent_id");
                    table.ForeignKey(
                        name: "FK__Termini__ustanov__2F10007B",
                        column: x => x.ustanova_id,
                        principalTable: "UstanoveZdravstva",
                        principalColumn: "ustanova_id");
                });

            migrationBuilder.CreateTable(
                name: "ZdravstveniKartoni",
                columns: table => new
                {
                    karton_id = table.Column<int>(type: "int", nullable: false),
                    datum_izdavanja = table.Column<DateTime>(type: "datetime", nullable: true),
                    sadrzaj = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pacijent_id = table.Column<int>(type: "int", nullable: true),
                    pregled_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Zdravstv__343D9B086C4B1945", x => x.karton_id);
                    table.ForeignKey(
                        name: "FK__Zdravstve__pacij__37A5467C",
                        column: x => x.pacijent_id,
                        principalTable: "Pacijenti",
                        principalColumn: "pacijent_id");
                    table.ForeignKey(
                        name: "FK__Zdravstve__pregl__38996AB5",
                        column: x => x.pregled_id,
                        principalTable: "Pregledi",
                        principalColumn: "pregled_id");
                });

            migrationBuilder.CreateTable(
                name: "LaboratorijskiRezultati",
                columns: table => new
                {
                    rezultat_id = table.Column<int>(type: "int", nullable: false),
                    vrsta_analize = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    rezultati_analize = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    datum_analize = table.Column<DateTime>(type: "datetime", nullable: true),
                    karton_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Laborato__FB858D87442E1142", x => x.rezultat_id);
                    table.ForeignKey(
                        name: "FK__Laborator__karto__46E78A0C",
                        column: x => x.karton_id,
                        principalTable: "ZdravstveniKartoni",
                        principalColumn: "karton_id");
                });

            migrationBuilder.CreateTable(
                name: "Napomene",
                columns: table => new
                {
                    napomena_id = table.Column<int>(type: "int", nullable: false),
                    naslov_napomene = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    tekst_napomene = table.Column<string>(type: "text", nullable: true),
                    datum_kreiranja = table.Column<DateTime>(type: "datetime", nullable: true),
                    karton_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Napomene__4B9D0366746F933F", x => x.napomena_id);
                    table.ForeignKey(
                        name: "FK__Napomene__karton__49C3F6B7",
                        column: x => x.karton_id,
                        principalTable: "ZdravstveniKartoni",
                        principalColumn: "karton_id");
                });

            migrationBuilder.CreateTable(
                name: "Terapije",
                columns: table => new
                {
                    terapija_id = table.Column<int>(type: "int", nullable: false),
                    naziv_terapije = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pocetak_terapije = table.Column<DateTime>(type: "date", nullable: true),
                    kraj_terapije = table.Column<DateTime>(type: "date", nullable: true),
                    karton_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Terapije__DC77D19B375748D2", x => x.terapija_id);
                    table.ForeignKey(
                        name: "FK__Terapije__karton__3B75D760",
                        column: x => x.karton_id,
                        principalTable: "ZdravstveniKartoni",
                        principalColumn: "karton_id");
                });

            migrationBuilder.CreateTable(
                name: "Recepti",
                columns: table => new
                {
                    recept_id = table.Column<int>(type: "int", nullable: false),
                    datum_receptiranja = table.Column<DateTime>(type: "date", nullable: true),
                    lijek_id = table.Column<int>(type: "int", nullable: true),
                    terapija_id = table.Column<int>(type: "int", nullable: true),
                    ljekar_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recepti__4B832CF3F694F291", x => x.recept_id);
                    table.ForeignKey(
                        name: "FK__Recepti__lijek_i__4316F928",
                        column: x => x.lijek_id,
                        principalTable: "Lijekovi",
                        principalColumn: "lijek_id");
                    table.ForeignKey(
                        name: "FK__Recepti__ljekar___534D60F1",
                        column: x => x.ljekar_id,
                        principalTable: "Ljekari",
                        principalColumn: "ljekar_id");
                    table.ForeignKey(
                        name: "FK__Recepti__terapij__440B1D61",
                        column: x => x.terapija_id,
                        principalTable: "Terapije",
                        principalColumn: "terapija_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthToken_korisnik_id",
                table: "AuthToken",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_grad_id",
                table: "Korisnici",
                column: "grad_id");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_osoblje_id",
                table: "Korisnici",
                column: "osoblje_id");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratorijskiRezultati_karton_id",
                table: "LaboratorijskiRezultati",
                column: "karton_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lijekovi_ustanova_id",
                table: "Lijekovi",
                column: "ustanova_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ljekari_korisnik_id",
                table: "Ljekari",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ljekari_ustanova_id",
                table: "Ljekari",
                column: "ustanova_id");

            migrationBuilder.CreateIndex(
                name: "IX_Napomene_karton_id",
                table: "Napomene",
                column: "karton_id");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_grad_id",
                table: "Narudzbe",
                column: "grad_id");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_korisnik_id",
                table: "Narudzbe",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_lijek_id",
                table: "Narudzbe",
                column: "lijek_id");

            migrationBuilder.CreateIndex(
                name: "IX_Osoblje_uloga_id",
                table: "Osoblje",
                column: "uloga_id");

            migrationBuilder.CreateIndex(
                name: "IX_Osoblje_ustanova_id",
                table: "Osoblje",
                column: "ustanova_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_korisnik_id",
                table: "Pacijenti",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_dijagnoza_id",
                table: "Pregledi",
                column: "dijagnoza_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_ljekar_id",
                table: "Pregledi",
                column: "ljekar_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recepti_lijek_id",
                table: "Recepti",
                column: "lijek_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recepti_ljekar_id",
                table: "Recepti",
                column: "ljekar_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recepti_terapija_id",
                table: "Recepti",
                column: "terapija_id");

            migrationBuilder.CreateIndex(
                name: "IX_Terapije_karton_id",
                table: "Terapije",
                column: "karton_id");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_ljekar_id",
                table: "Termini",
                column: "ljekar_id");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_pacijent_id",
                table: "Termini",
                column: "pacijent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_ustanova_id",
                table: "Termini",
                column: "ustanova_id");

            migrationBuilder.CreateIndex(
                name: "IX_UstanoveZdravstva_grad_id",
                table: "UstanoveZdravstva",
                column: "grad_id");

            migrationBuilder.CreateIndex(
                name: "IX_UstanoveZdravstva_tip_ustanove_id",
                table: "UstanoveZdravstva",
                column: "tip_ustanove_id");

            migrationBuilder.CreateIndex(
                name: "IX_ZdravstveniKartoni_pacijent_id",
                table: "ZdravstveniKartoni",
                column: "pacijent_id");

            migrationBuilder.CreateIndex(
                name: "IX_ZdravstveniKartoni_pregled_id",
                table: "ZdravstveniKartoni",
                column: "pregled_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthToken");

            migrationBuilder.DropTable(
                name: "LaboratorijskiRezultati");

            migrationBuilder.DropTable(
                name: "Napomene");

            migrationBuilder.DropTable(
                name: "Narudzbe");

            migrationBuilder.DropTable(
                name: "Recepti");

            migrationBuilder.DropTable(
                name: "Termini");

            migrationBuilder.DropTable(
                name: "Lijekovi");

            migrationBuilder.DropTable(
                name: "Terapije");

            migrationBuilder.DropTable(
                name: "ZdravstveniKartoni");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Pregledi");

            migrationBuilder.DropTable(
                name: "Dijagnoze");

            migrationBuilder.DropTable(
                name: "Ljekari");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Osoblje");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "UstanoveZdravstva");

            migrationBuilder.DropTable(
                name: "Gradovi");

            migrationBuilder.DropTable(
                name: "TipoviUstanova");
        }
    }
}
