using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Json
{
    public class JsonScan
    {
        public object Artikelbeskrivning { get; set; }
        public object Artikelegenskap { get; set; }
        public string Produktkod { get; set; }
        public object OvrigObligatoriskMarkning { get; set; }
        public int MaximalaAntaletMinstaEnheterIforpackningen { get; set; }
        public string Hyllkantstext { get; set; }
        public string Storlek { get; set; }
        public object TullstatistisktNummer { get; set; }
        public string Datumstandard { get; set; }
        public float MangdFardigVara { get; set; }
        public int MangdPris { get; set; }
        public object MangdFardigVaraAvser { get; set; }
        public int AntalMinstaEnheterIforpackningen { get; set; }
        public int MinstaEnhetViktVolym { get; set; }
        public object MinstaEnhetSort { get; set; }
        public object Hemsida { get; set; }
        public float Nettovikt { get; set; }
        public float Nettovolym { get; set; }
        public bool AvgiftErlagdForForpackningsmaterial { get; set; }
        public float Skattesats { get; set; }
        public bool MinstaEnhetCirkaViktVolym { get; set; }
        public float Alkoholhalt { get; set; }
        public int T4203_Argang { get; set; }
        public float Staplingshojd { get; set; }
        public int NordisktVarunummerLakemedel { get; set; }
        public bool KravObrutenKylkedja { get; set; }
        public int PLUNummer { get; set; }
        public object Faktortyp { get; set; }
        public float Faktor { get; set; }
        public object T4202_LokaltUrsprung { get; set; }
        public object Ursprungsland { get; set; }
        public int RelativLuftfuktighetMin { get; set; }
        public float TemperaturMax { get; set; }
        public float TemperaturMin { get; set; }
        public int RelativLuftfuktighetMax { get; set; }
        public int TotalHallbarhetAntalDagar { get; set; }
        public int HallbarhetMinAntalDagarLeverantor { get; set; }
        public object InformationOvrig { get; set; }
        public int Emballagevikt { get; set; }
        public object Allergenpastaende { get; set; }
        public float Kubikmeter { get; set; }
        public float Kvadratmeter { get; set; }
        public float Langd { get; set; }
        public int AntalPortioner { get; set; }
        public bool PrismarktAvleverantor { get; set; }
        public string Ingrediensforteckning { get; set; }
        public bool ArtikelEJAvseddForFoodservicemarknaden { get; set; }
        public int Druvsort { get; set; }
        public object FarligarDelarBorttagbara { get; set; }
        public object UppfyllerRoHS { get; set; }
        public object Palltyp { get; set; }
        public int T0157_Tryckkanslighet { get; set; }
        public float Pris { get; set; }
        public object ValutaPaPriset { get; set; }
        public bool InnehallerEjAllergener { get; set; }
        public object Ursprungsdeklaration { get; set; }
        public object IngrediensforteckningIckeLivsmedel { get; set; }
        public object OvrigMarkning { get; set; }
        public object SlutdatumForVariant { get; set; }
        public object Halsopastaende { get; set; }
        public object Naringspastaende { get; set; }
        public int Malmarknadsomrade { get; set; }
        public int Sillvikt { get; set; }
        public bool BatterierIngar { get; set; }
        public bool BatterierKravs { get; set; }
        public object Batteriteknik { get; set; }
        public object Batterityp { get; set; }
        public int T4750_AntalInbyggdaBatterier { get; set; }
        public float Batterivikt { get; set; }
        public object T4204_SökbegreppEhandel { get; set; }
        public object T4228_ArtensVetenskapligaNamnKod { get; set; }
        public object T4229_ArtensVetenskapligaNamn { get; set; }
        public object T4231_Produktionsmetod { get; set; }
        public object T4232_Forvaringsstatus { get; set; }
        public object T4242_Temperaturstatus { get; set; }
        public object T4245_PresentationsformKod { get; set; }
        public object T4246_BeredningsformKod { get; set; }
        public object InbyggdaBatterier { get; set; }
        public string GTIN { get; set; }
        public object TillverkarensArtikelnummer { get; set; }
        public string Artikelbenamning { get; set; }
        public object RegleratProduktnamn { get; set; }
        public object Forvaringsinstruktion { get; set; }
        public bool Variabelmattsindikator { get; set; }
        public float Bruttovikt { get; set; }
        public float Bredd { get; set; }
        public float Djup { get; set; }
        public float Hojd { get; set; }
        public bool Returemballage { get; set; }
        public int FarligtGodsKod { get; set; }
        public object FarligtGodsKlass { get; set; }
        public object FarligtGodsForpackningsgrupp { get; set; }
        public string GPCKod { get; set; }
        public DateTime GiltigFROM { get; set; }
        public DateTime Publiceringsdatum { get; set; }
        public bool FakturerbarEnhet { get; set; }
        public object Slutdatum { get; set; }
        public object GiltighetsdatumPris { get; set; }
        public DateTime Tillganglighetstidpunkt { get; set; }
        public object SistaTillganglighetstidpunkt { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime SenastAndradDatum { get; set; }
        public object Flampunkt { get; set; }
        public object KodBegransadMangd { get; set; }
        public object OfficiellTransportbenamning { get; set; }
        public object OspecificeradTransportbenamning { get; set; }
        public object TunnelrestriktionADR { get; set; }
        public object KlassificeringskodFarligtgods { get; set; }
        public object Transportkategori { get; set; }
        public bool Konsumentartikel { get; set; }
        public bool BestallningsbarForpackning { get; set; }
        public object RabattOlaglig { get; set; }
        public int Garantiloptid { get; set; }
        public object Konsumentdatum { get; set; }
        public bool Tjanst { get; set; }
        public object Sasongsindikator { get; set; }
        public object Engangskop { get; set; }
        public int AntalReturnerbaraEnheter { get; set; }
        public object Staplingsriktning { get; set; }
        public object Staplingstyp { get; set; }
        public float MaxTransportTemperatur { get; set; }
        public float MinTransportTemperatur { get; set; }
        public object Anvandningsinstruktioner { get; set; }
        public int HallbarhetEfterOppning { get; set; }
        public object Riskfras { get; set; }
        public object KodlistutgivareRiskfras { get; set; }
        public object Klassificeringssystem { get; set; }
        public object FarligtGodsBegransadMangd { get; set; }
        public object FarligtGodsOvrigInfo { get; set; }
        public object FarligtGodsSarbestammelser { get; set; }
        public object T3495_Artikelavisering { get; set; }
        public string T4032_TypAvUtgangsdatum { get; set; }
        public object T3742_ForstaLeveransdatum { get; set; }
        public object Undervarumarke { get; set; }
        public string Niva { get; set; }
        public string Produktbladslank { get; set; }
        public object KompletterandeProduktklass { get; set; }
        public object T4200_AllmänPubliceringstidpunkt { get; set; }
        public object T3848_TypAvTryckkanslighet { get; set; }
        public object[] Varningsetiketter { get; set; }
        public object[] Sasongskoder { get; set; }
        public object[] Produktklasser { get; set; }
        public Maskinellmarkningar[] MaskinellMarkningar { get; set; }
        public Bilder[] Bilder { get; set; }
        public object[] ReferenserTillAndraArtiklar { get; set; }
        public object[] MSRKritierier { get; set; }
        public object[] Kravspecifikationer { get; set; }
        public object[] Receptlinks { get; set; }
        public object[] Allergener { get; set; }
        public object[] Markningar { get; set; }
        public object[] Ingredienser { get; set; }
        public object[] Tillagningsinformation { get; set; }
        public Tillverkningslander[] Tillverkningslander { get; set; }
        public Naringsinfo[] Naringsinfo { get; set; }
        public Serveringsforslag[] Serveringsforslag { get; set; }
        public object[] Diettyper { get; set; }
        public object[] Tillagningsmetoder { get; set; }
        public object[] Farger { get; set; }
        public object[] VillkorForsaljning { get; set; }
        public Varumarke Varumarke { get; set; }
        public Nettoinnehall[] Nettoinnehall { get; set; }
        public object[] Kontakter { get; set; }
        public object[] Faroangivelser { get; set; }
        public object[] Sakerhet { get; set; }
        public Forpackningar[] Forpackningar { get; set; }
        public object[] Tillsatser { get; set; }
        public object[] Substanser { get; set; }
        public object[] Fangstzoner { get; set; }
        public object[] Marknadsbudskap { get; set; }
        public object[] KortMarknadsbudskap { get; set; }
        public object[] Komponenter { get; set; }
    }

    public class Varumarke
    {
        public string Varumarket { get; set; }
        public string AgareGLN { get; set; }
        public string AgareNamn { get; set; }
        public Tillverkare Tillverkare { get; set; }
    }

    public class Tillverkare
    {
        public string Namn { get; set; }
        public object EAN { get; set; }
    }

    public class Maskinellmarkningar
    {
        public object MaskinellMarkning { get; set; }
        public object TypAvMarkning { get; set; }
        public string Databarartyp { get; set; }
    }

    public class Bilder
    {
        public string Informationstyp { get; set; }
        public string Innehallsbeskrivning { get; set; }
        public object Filformat { get; set; }
        public object Filnamn { get; set; }
        public string Lank { get; set; }
    }

    public class Tillverkningslander
    {
        public string Land { get; set; }
        public string Kod { get; set; }
    }

    public class Naringsinfo
    {
        public string Tillagningsstatus { get; set; }
        public object Intagningsrekommendationstyp { get; set; }
        public object Portionsstorlek { get; set; }
        public float Basmangdsdeklaration { get; set; }
        public string Mattkvalificerarebasmangd { get; set; }
        public Naringsvarden[] Naringsvarden { get; set; }
    }

    public class Naringsvarden
    {
        public string Benamning { get; set; }
        public string Kod { get; set; }
        public float Mangd { get; set; }
        public string Enhet { get; set; }
        public string Enhetskod { get; set; }
        public string Precision { get; set; }
        public float Dagsintag { get; set; }
    }

    public class Serveringsforslag
    {
        public object Forslag { get; set; }
    }

    public class Nettoinnehall
    {
        public object Enhet { get; set; }
        public float Mängd { get; set; }
        public int Typkod { get; set; }
        public string Typ { get; set; }
    }

    public class Forpackningar
    {
        public string Forpackningstyp { get; set; }
        public object Palltyp { get; set; }
        public object Emballagevikt { get; set; }
        public object T4201_emballagehöjd_mm { get; set; }
        public object EmballageViktEnhet { get; set; }
        public object Forpakningsfunktion { get; set; }
        public object ForpackningsmaterialKod { get; set; }
        public object Vikt { get; set; }
        public object Viktenhet { get; set; }
        public object PantForReturnerbarForpackningKod { get; set; }
        public object Antalenheter { get; set; }
        public object AntalenhetKod { get; set; }
        public object Pantsystemregion { get; set; }
        public object Forpackningsegenskap { get; set; }
        public Forpackningsmaterial[] Forpackningsmaterial { get; set; }
    }

    public class Forpackningsmaterial
    {
        public string T1188_ForpackningsmaterialKod { get; set; }
        public int T1189_Vikt { get; set; }
        public object T3780_ViktEnhet { get; set; }
        public object T4243_ForpackningsmaterialetsFargKod { get; set; }
        public object T4244_ForpackningsmaterialetsBelaggning { get; set; }
    }
}
