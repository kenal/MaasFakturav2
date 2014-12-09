using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Mass.Data;
using System.Data.Linq;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Linq.SqlClient;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MassServis" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MassServis.svc or MassServis.svc.cs at the Solution Explorer and start debugging
    [ServiceContract]
    public class MassServis
    {
    
      [OperationContract]
        public int LoginValidacija(string username, string pass)
        {
            using(DataBaseModelDataContext context = new DataBaseModelDataContext())
            {

                var x = (from a in context.tbl_korisniks where (a.username.Equals(username) && a.password.Equals(pass)) select new { a.id_korisnik }).SingleOrDefault();
            if (x != null)
            {
                if (x.id_korisnik != 0)
                    return x.id_korisnik;
                else return 0;
            }

            else
                { return 0; }
            }   
        }
       [OperationContract]
       public void UnesiDobavljaca(tbl_dobavljac dobavljac)
       {
           using (DataBaseModelDataContext context = new DataBaseModelDataContext())
           {
               context.tbl_dobavljacs.InsertOnSubmit(dobavljac);
               context.SubmitChanges();
           }
       }
       [OperationContract]
       public ObservableCollection<tbl_dobavljac> ListaDobavljaca()
       {
           ObservableCollection<tbl_dobavljac> Lista = new ObservableCollection<tbl_dobavljac>();
           using (DataBaseModelDataContext context = new DataBaseModelDataContext())
           {
               var x = from a in context.tbl_dobavljacs select a;
               Lista.Clear();
               foreach (var p in x)
               {
                   Lista.Add(new tbl_dobavljac { 
                   id_dobavljac=p.id_dobavljac,
                   broj_dobavljaca=p.broj_dobavljaca,
                   ime=p.ime,
                   tip=p.tip,
                   prezime=p.prezime,
                   adresa=p.adresa,
                   tel1=p.tel1,
                   tel2=p.tel2,
                   mobitel=p.mobitel,
                   skype=p.skype,
                   fax=p.skype,
                   email=p.email,
                   banka=p.banka,
                   blz=p.blz,
                   KtoNr=p.KtoNr,
                   bic=p.bic,
                   iban=p.iban,
                   vlasnik_racuna=p.vlasnik_racuna,
                   biljeska=p.biljeska,
                   id_korisnik_FK=p.id_korisnik_FK,
                   promet=p.promet,
                   nacin_placanja=p.nacin_placanja,
                   zemlja=p.zemlja,
                   popust=p.popust,
                   broj_dana=p.broj_dana,
                   gotovina=p.gotovina,
                   rabat=p.rabat,
                   ziro_racun=p.ziro_racun,
                   porez=p.porez
                   });
               }
             
           }
           return Lista;
       }

        [OperationContract]
        public void ObrisiDobavljaca(int brDobavljaca)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_dobavljacs where a.broj_dobavljaca == brDobavljaca select a;

                foreach (var p in query)
                {
                    context.tbl_dobavljacs.DeleteOnSubmit(p);
                    context.SubmitChanges();
                }
            }
        }

        [OperationContract]
   public void UpdateDobavljac(tbl_dobavljac d)
   {
       using(DataBaseModelDataContext context = new DataBaseModelDataContext())
       {
           tbl_dobavljac dobavljac = (from a in context.tbl_dobavljacs where a.id_dobavljac == d.id_dobavljac select a).FirstOrDefault();
           dobavljac.broj_dobavljaca = d.broj_dobavljaca;
           dobavljac.tip = d.tip;
           dobavljac.ime = d.ime;
           dobavljac.prezime = d.prezime;
           dobavljac.adresa = d.adresa;
           dobavljac.tel1 = d.tel1;
           dobavljac.tel2 = d.tel2;
           dobavljac.mobitel = d.mobitel;
           dobavljac.skype = d.skype;
           dobavljac.fax = d.fax;
           dobavljac.email = d.email;
           dobavljac.banka = d.banka;
           dobavljac.blz = d.blz;
           dobavljac.KtoNr = d.KtoNr;
           dobavljac.bic = d.bic;
           dobavljac.iban = d.iban;
           dobavljac.vlasnik_racuna = d.vlasnik_racuna;
           dobavljac.biljeska = d.biljeska;
           dobavljac.id_korisnik_FK = d.id_korisnik_FK;
           dobavljac.promet = d.promet;
           dobavljac.nacin_placanja = d.nacin_placanja;
           dobavljac.zemlja = d.zemlja;
           dobavljac.poslovanje = d.poslovanje;
           dobavljac.popust = d.popust;
           dobavljac.broj_dana = d.broj_dana;
           dobavljac.gotovina = d.gotovina;
           dobavljac.rabat = d.rabat;
           dobavljac.ziro_racun = d.ziro_racun;
           dobavljac.porez = d.porez;
           context.SubmitChanges();
       }
   }

        [OperationContract]
        public void UnesiRadnika(int broj,int titula,string ime,string prezime,string adresa,string tel1,string tel2,string mobitel,string fax,string skype,string email,float zarada,float satnica,string odmor, string odmor_na,float broj_plate,
            string bolovanje, string banka, string blz,string bic, string KtoNr, string Iban, string vlasnik, string biljeske, DateTime datum, int id)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                string datum1;
                datum1 = datum.ToString("yyyy-MM-dd");

                tbl_radnik r = new tbl_radnik();
                r.sifra_radnik = broj;
                r.tip = titula;
                r.ime = ime;
                r.prezime = prezime;
                r.adresa = adresa;
                r.tel1 = tel1;
                r.tel2 = tel2;
                r.mobitel = mobitel;
                r.fax = fax;
                r.skype=skype;
                r.email = email;
                r.zarada = Convert.ToDecimal(zarada);
                r.satnica = Convert.ToDecimal(satnica);
                r.odmor = odmor;
                r.odmor_na = odmor_na;
                r.broj_plate = Convert.ToDecimal(broj_plate);
                r.bolovanje = bolovanje;
                r.banka = banka;
                r.blz = blz;
                r.bic = bic;
                r.KtoNr = KtoNr;
                r.iban = Iban;
                r.vlasnik_racuna = vlasnik;
                r.biljeska = biljeske;
                datum = Convert.ToDateTime(datum1);
                r.datum = datum;
                r.id_korisnik_FK = id;
                r.status = true;
                context.tbl_radniks.InsertOnSubmit(r);
                context.SubmitChanges();
            }
        }
        [OperationContract]
        public ObservableCollection<tbl_radnik> ListaRadnika()
        {
            ObservableCollection<tbl_radnik> Lista = new ObservableCollection<tbl_radnik>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_radniks select a;
                Lista.Clear();
                foreach (var p in query)
                {
                    Lista.Add(new tbl_radnik
                    {
                       id_radnik=p.id_radnik,
                       sifra_radnik=p.sifra_radnik,
                       tip=p.tip,
                       ime=p.ime,
                       prezime=p.prezime,
                       adresa=p.adresa,
                       tel1=p.tel1,
                       tel2=p.tel2,
                       mobitel=p.mobitel,
                       fax=p.fax,
                       email=p.email,
                       zarada=p.zarada,
                       satnica=p.satnica,
                       odmor=p.odmor,
                       odmor_na=p.odmor_na,
                       broj_plate=p.broj_plate,
                       broj_nedelja=p.broj_nedelja,
                       bolovanje=p.bolovanje,
                       banka=p.banka,
                       blz=p.blz,
                       bic=p.bic,
                       KtoNr=p.KtoNr,
                       iban=p.iban,
                       skype=p.skype,
                       vlasnik_racuna=p.vlasnik_racuna,
                       biljeska=p.biljeska,
                       datum=p.datum,
                       id_korisnik_FK=p.id_korisnik_FK,
                       folder=p.folder,
                       status=p.status
                    });
                }
                return Lista;
            }
        }

        [OperationContract]
        public void UnesiKupca(tbl_kupac kupac)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                context.tbl_kupacs.InsertOnSubmit(kupac);
                context.SubmitChanges();
            }
        }
        [OperationContract]
        public ObservableCollection<tbl_korisnik> ComboKorisnici()
        {
            ObservableCollection<tbl_korisnik> Lista = new ObservableCollection<tbl_korisnik>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_korisniks select a;

                foreach (var p in query)
                {
                    Lista.Add(new tbl_korisnik{
                    id_korisnik= p.id_korisnik,
                    ime=p.ime,
                    prezime=p.prezime,
                    mail=p.mail,
                    username=p.username,
                    password=p.password,
                    tip=p.tip,
                    telefon=p.telefon,
                    aktivan=p.aktivan,
                    slika=p.slika,
                    pocetna=p.pocetna
                    });
                }
                return Lista;
            }
        }

        [OperationContract]
        public ObservableCollection<tbl_korisnik> ComboKorisniciPoruke(int id)
        {
            ObservableCollection<tbl_korisnik> Lista = new ObservableCollection<tbl_korisnik>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_korisniks where a.id_korisnik != id select a;

                foreach (var p in query)
                {
                    Lista.Add(new tbl_korisnik
                    {
                        id_korisnik = p.id_korisnik,
                        ime = p.ime,
                        prezime = p.prezime,
                        mail = p.mail,
                        username = p.username,
                        password = p.password,
                        tip = p.tip,
                        telefon = p.telefon,
                        aktivan = p.aktivan,
                        slika = p.slika,
                        pocetna = p.pocetna
                    });
                }
                return Lista;
            }
        }

        [OperationContract]
        public ObservableCollection<tbl_kupac> ListaKupaca()
        {
            ObservableCollection<tbl_kupac> Lista = new ObservableCollection<tbl_kupac>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_kupacs select a;
                Lista.Clear();
                foreach (var p in query)
                {
                    Lista.Add(new tbl_kupac
                    {
                        id_kupac = p.id_kupac,
                        pojam = p.pojam,
                        ime = p.ime,
                        prezime = p.prezime,
                        mjesto = p.mjesto,
                        grupa = p.grupa,
                        slobodno_polje = p.slobodno_polje,
                        ime2 = p.ime2,
                        ulica = p.ulica,
                        tel1 = p.tel1,
                        tel2 = p.tel2,
                        fax = p.fax,
                        mail = p.mail,
                        lk = p.lk,
                        dostava_na = p.dostava_na,
                        dostava_od = p.dostava_od,
                        vk_cijena = p.vk_cijena,
                        gotovina = p.gotovina,
                        popust_gotovina = p.popust_gotovina,
                        dnevni_popust = p.dnevni_popust,
                        predstavnik = p.predstavnik,
                        limit_narudzbe = p.limit_narudzbe,
                        tip = p.tip,
                        adresa_dostava = p.adresa_dostava,
                        adresa_fakture = p.adresa_fakture,
                        mail2 = p.mail2,
                        interner = p.interner,
                        tip_kupca = p.tip_kupca,
                        porez = p.porez,
                        broj  = p.broj,
                        broj_detalji = p.broj_detalji,
                        ocjena_kupca = p.ocjena_kupca,
                        biljeska = p.biljeska,
                        naziv = p.naziv,
                        zemlja = p.zemlja,
                        placa = p.placa,
                        rabat = p.rabat,
                        adresa2 = p.adresa2,
                        grad = p.grad,
                        predmet = p.predmet,
                        kontakt_osobe = p.kontakt_osobe,
                        detalji_rute = p.detalji_rute,
                        titel = p.titel,
                        broj_kupac = p.broj_kupac
                    });
                }
                return Lista;
            }
        }

        [OperationContract]
        public void ObrisiKupca(int brKupca)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_kupacs where a.broj_kupac == brKupca select a;

                foreach (var p in query)
                {
                    context.tbl_kupacs.DeleteOnSubmit(p);
                    context.SubmitChanges();
                }
            }
        }

        [OperationContract]
        public void UpdateKupac(tbl_kupac k)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                tbl_kupac kupac = (from a in context.tbl_kupacs where a.id_kupac == k.id_kupac select a).FirstOrDefault();
                kupac.gotovina = k.gotovina;
                kupac.adresa_dostava = k.adresa_dostava;
                kupac.adresa_fakture = k.adresa_fakture;
                kupac.adresa2 = k.adresa2;
                kupac.biljeska = k.biljeska;
                kupac.broj = k.broj;
                kupac.broj_detalji = k.broj_detalji;
                kupac.broj_kupac = k.broj_kupac;
                kupac.detalji_rute = k.detalji_rute;
                kupac.dnevni_popust = k.dnevni_popust;
                kupac.dostava_na = k.dostava_na;
                kupac.dostava_od = k.dostava_od;
                kupac.fax = k.fax;
                kupac.grad = k.grad;
                kupac.grupa = k.grupa;
                kupac.ime = k.ime;
                kupac.ime2 = k.ime2;
                kupac.interner = k.interner;
                kupac.kontakt_osobe = k.kontakt_osobe;
                kupac.limit_narudzbe = k.limit_narudzbe;
                kupac.lk = k.lk;
                kupac.mail = k.mail;
                kupac.mail2 = k.mail2;
                kupac.mjesto = k.mjesto;
                kupac.naziv = k.naziv;
                kupac.ocjena_kupca = k.ocjena_kupca;
                kupac.placa = k.placa;
                kupac.pojam = k.pojam;
                kupac.popust_gotovina = k.popust_gotovina;
                kupac.porez = k.porez;
                kupac.predmet = k.predmet;
                kupac.predstavnik = k.predstavnik;
                kupac.prezime = k.prezime;
                kupac.rabat = k.rabat;
                kupac.slobodno_polje = k.slobodno_polje;
                kupac.tel1 = k.tel1;
                kupac.tel2 = k.tel2;
                kupac.tip = k.tip;
                kupac.tip_kupca = k.tip_kupca;
                kupac.titel = k.titel;
                kupac.ulica = k.ulica;
                kupac.vk_cijena = k.vk_cijena;
                kupac.zemlja = k.zemlja;
                context.SubmitChanges();
            }
        }

        [OperationContract]
        public void UnesiUsera(string Name, string LastName, string Email, string Telefon, bool Aktivan, string Slika, string Username, string Password, int UserType, bool Pocetna, string Licence)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                int lastIdOld = (from l in context.tbl_korisniks orderby l.id_korisnik descending select l.id_korisnik).First();
                try
                {
                    tbl_korisnik korisnik = new tbl_korisnik();
                    korisnik.ime = Name;
                    korisnik.prezime = LastName;
                    korisnik.mail = Email;
                    korisnik.username = Username;
                    korisnik.password = Password;
                    korisnik.tip = UserType;
                    korisnik.telefon = Telefon;
                    korisnik.aktivan = Aktivan;
                    korisnik.slika = Slika;
                    korisnik.pocetna = Pocetna;
                    context.tbl_korisniks.InsertOnSubmit(korisnik);
                    context.SubmitChanges();
                    int lastIdNew = (from l in context.tbl_korisniks orderby l.id_korisnik descending select l.id_korisnik).First();
                    if (lastIdNew > lastIdOld)
                    {
                        tbl_korisnik_licenca korLicenca = new tbl_korisnik_licenca();
                        korLicenca.id_korisnik_FK = lastIdNew;
                        korLicenca.datum = Convert.ToDateTime(Licence);
                        korLicenca.aktivan = Aktivan;
                        context.tbl_korisnik_licencas.InsertOnSubmit(korLicenca);
                        context.SubmitChanges();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        [OperationContract]
        public ObservableCollection<p_get_User_ViewResult> ListaUserView()
        {
            ObservableCollection<p_get_User_ViewResult> Lista = new ObservableCollection<p_get_User_ViewResult>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
               // var query = from a in context.tbl_kupacs select a;
                var query = from t1 in context.tbl_korisniks
                            join t2 in context.tbl_korisnik_licencas on t1.id_korisnik equals t2.id_korisnik_FK
                            select new {t1.id_korisnik, t1.ime, t1.prezime, t1.mail, t1.tip, t1.username, t1.password, t1.telefon, t2.datum, t1.pocetna, t1.aktivan, t1.slika };
                Lista.Clear();
                foreach (var p in query)
                {
                    Lista.Add(new p_get_User_ViewResult
                    {
                        id_korisnik = p.id_korisnik,
                        ime = p.ime,
                        prezime = p.prezime,
                        mail = p.mail,
                        tip = p.tip,
                        username = p.username,
                        password = p.password,
                        telefon = p.telefon,
                        datum = p.datum,
                        pocetna = p.pocetna,
                        aktivan = p.aktivan,
                        slika = p.slika
                    });
                }
                return Lista;
            }
        }

        //[OperationContract]
        //public ObservableCollection<p_get_User_ViewResult> ListaUserView()
        //{
        //    ObservableCollection<p_get_User_ViewResult> Lista = new ObservableCollection<p_get_User_ViewResult>();
        //    using (DataBaseModelDataContext context = new DataBaseModelDataContext())
        //    {
        //        int a = context.ExecuteCommand("dbo.p_get_User_View");

        //    }
        //    return Lista;
        //}

        [OperationContract]
        public  DataSet getUsersView()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblKorisnik");
            dt.Columns.Add(new DataColumn("id_korisnik", typeof(int)));
            dt.Columns.Add(new DataColumn("ime", typeof(string)));
            dt.Columns.Add(new DataColumn("prezime", typeof(string)));
            dt.Columns.Add(new DataColumn("mail", typeof(string)));
            dt.Columns.Add(new DataColumn("tip", typeof(string)));
            dt.Columns.Add(new DataColumn("username", typeof(string)));
            dt.Columns.Add(new DataColumn("password", typeof(string)));
            dt.Columns.Add(new DataColumn("telefon", typeof(string)));
            dt.Columns.Add(new DataColumn("datum", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("pocetna", typeof(bool)));
            dt.Columns.Add(new DataColumn("aktivan", typeof(bool)));
            dt.Columns.Add(new DataColumn("slika", typeof(string)));
            //DataRow dr = dt.NewRow();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = (from t1 in context.tbl_korisniks
                            join t2 in context.tbl_korisnik_licencas on t1.id_korisnik equals t2.id_korisnik_FK
                            select new { t1.id_korisnik, t1.ime, t1.prezime, t1.mail, t1.tip, t1.username, t1.password, t1.telefon, t2.datum, t1.pocetna, t1.aktivan, t1.slika}).ToList();
                dt.Clear();
                foreach(var g in query)
            {
                    DataRow dr = dt.NewRow();
                dr["id_korisnik"] = g.id_korisnik;
                dr["ime"] = g.ime;
                dr["prezime"] = g.prezime;
                dr["mail"] = g.mail;
                if (g.tip == 0) {dr["tip"] = "Administrator";}
                else if (g.tip == 1) { dr["tip"] = "Mitarbeiter"; }
                else if (g.tip == 2) { dr["tip"] = "Sekretarin"; }
                else if (g.tip == 3) { dr["tip"] = "Techniker"; }
                else if (g.tip == 4) { dr["tip"] = "Werkstattleiter"; }
                dr["username"] = g.username;
                dr["password"] = g.password;
                dr["telefon"] = g.telefon;
                dr["datum"] = g.datum;
                dr["pocetna"] = g.pocetna;
                dr["aktivan"] = g.aktivan;
                dr["slika"] = g.slika;
                //dr["mail"] = g.mail;
                dt.Rows.Add(dr);
                //dt.Rows.Add(g.id_korisnik, g.ime, g.prezime, g.mail, g.tip, g.username, g.password, g.telefon, g.datum, g.pocetna, g.aktivan, g.slika);
            }
            ds.Tables.Add(dt);
            return ds;
            }
        }

        [OperationContract]
        public void DeleteRadnik(int sifraRadnik)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_radniks where a.sifra_radnik == sifraRadnik select a;

                foreach (var p in query)
                {
                    context.tbl_radniks.DeleteOnSubmit(p);
                    context.SubmitChanges();
                }
            }
        }

        [OperationContract]
        public void UpdateRadnika(tbl_radnik r, int id)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                tbl_radnik radnik = (from a in context.tbl_radniks where a.id_radnik == r.id_radnik select a).FirstOrDefault();
                radnik.sifra_radnik = r.sifra_radnik;
                radnik.tip = r.tip;
                radnik.ime = r.ime;
                radnik.prezime = r.prezime;
                radnik.adresa = r.adresa;
                radnik.tel1 = r.tel1;
                radnik.tel2 = r.tel2;
                radnik.mobitel = r.mobitel;
                radnik.fax = r.fax;
                radnik.skype = r.skype;
                radnik.email = r.email;
                radnik.zarada = r.zarada;
                radnik.satnica = r.satnica;
                radnik.odmor = r.odmor;
                radnik.odmor_na = r.odmor_na;
                radnik.broj_plate = r.broj_plate;
                radnik.bolovanje = r.bolovanje;
                radnik.banka = r.banka;
                radnik.blz = r.blz;
                radnik.bic = r.bic;
                radnik.KtoNr = r.KtoNr;
                radnik.iban = r.iban;
                radnik.vlasnik_racuna = r.vlasnik_racuna;
                radnik.biljeska = r.biljeska;
                radnik.datum = r.datum;
                radnik.id_korisnik_FK = id;
                r.status = true;
                radnik.folder = r.folder;
                radnik.status = r.status;
               
                context.SubmitChanges();
            }
        }

        [OperationContract]
        public tbl_korisnik VratiKorisnika(int id)
        {
            using(DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                tbl_korisnik korisnik = new tbl_korisnik();
                var query = (from a in context.tbl_korisniks where a.id_korisnik == id select a).Single();
                korisnik.id_korisnik = query.id_korisnik;
                korisnik.ime = query.ime;
                korisnik.prezime = query.prezime;
                korisnik.mail = query.mail;
                korisnik.username = query.username;
                korisnik.password = query.password;
                korisnik.tip = query.tip;
                korisnik.telefon = query.telefon;
                korisnik.aktivan = query.aktivan;
                korisnik.slika = query.slika;
                korisnik.pocetna = query.pocetna;
                return korisnik;
                
            }
        }

        [OperationContract]
        public void EditujUsera(int idUser, string Name, string LastName, string Email, string Telefon, bool Aktivan, string Slika, string Username, string Password, int UserType, bool Pocetna, string Licence)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                try
                {
                    tbl_korisnik_licenca korLIcenca = context.tbl_korisnik_licencas.Single(p => p.id_korisnik_FK == idUser);
                    korLIcenca.datum = Convert.ToDateTime(Licence);
                    context.SubmitChanges();

                    tbl_korisnik korisnik = context.tbl_korisniks.Single(e => e.id_korisnik == idUser);
                    korisnik.ime = Name;
                    korisnik.prezime = LastName;
                    korisnik.mail = Email;
                    korisnik.username = Username;
                    korisnik.password = Password;
                    korisnik.tip = UserType;
                    korisnik.telefon = Telefon;
                    korisnik.aktivan = Aktivan;
                    korisnik.slika = Slika;
                    korisnik.pocetna = Pocetna;
                    context.SubmitChanges();                  
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        [OperationContract]
        public void UpdateKorisnik(tbl_korisnik k)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                tbl_korisnik korisnik = (from a in context.tbl_korisniks where a.id_korisnik == k.id_korisnik select a).FirstOrDefault();
                korisnik.ime=k.ime;
                korisnik.prezime=k.prezime;
                korisnik.mail = k.mail;
                korisnik.username = k.username;
                korisnik.password = k.password;
                korisnik.tip = k.tip;
                korisnik.telefon = k.telefon;
                korisnik.aktivan = k.aktivan;
                korisnik.slika = k.slika;
                korisnik.pocetna = k.pocetna;
                context.SubmitChanges();
            }
        }

        [OperationContract]
        public void DeleteUser(int idUser)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var queryKor = from a in context.tbl_korisniks where a.id_korisnik == idUser select a;
                var queryLic = from a in context.tbl_korisnik_licencas where a.id_korisnik_FK == idUser select a;

                foreach (var u in queryLic)
                {
                    context.tbl_korisnik_licencas.DeleteOnSubmit(u);
                    context.SubmitChanges();
                }
                foreach (var p in queryKor)
                {
                    context.tbl_korisniks.DeleteOnSubmit(p);
                    context.SubmitChanges();
                }
            }
        }

        [OperationContract]
        public ObservableCollection<tbl_radnik> PretraziRadnika(string ime)
        {
            ObservableCollection<tbl_radnik> ListaTrazenihRadnika = new ObservableCollection<tbl_radnik>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_radniks where SqlMethods.Like(a.ime, "%"+ime+"%") select a;
                foreach (var p in query)
                {
                    ListaTrazenihRadnika.Add(new tbl_radnik
                    {
                        id_radnik=p.id_radnik,
                        sifra_radnik=p.sifra_radnik,
                        tip=p.tip,
                        ime=p.ime,
                        prezime=p.prezime,
                        adresa=p.adresa,
                        tel1=p.tel1,
                        tel2=p.tel2,
                        mobitel=p.mobitel,
                        fax=p.fax,
                        email=p.email,
                        zarada=p.zarada,
                        satnica=p.satnica,
                        odmor=p.odmor,
                        odmor_na=p.odmor_na,
                        broj_plate=p.broj_plate,
                        broj_nedelja=p.broj_nedelja,
                        bolovanje=p.bolovanje,
                        banka=p.banka,
                        blz=p.blz,
                        bic=p.bic,
                        KtoNr=p.KtoNr,
                        iban=p.iban,
                        vlasnik_racuna=p.vlasnik_racuna,
                        biljeska=p.biljeska,
                        datum=p.datum,
                        id_korisnik_FK=p.id_korisnik_FK,
                        folder=p.folder,
                        status=p.status


                    });

                }
                return ListaTrazenihRadnika;
            }
        }
        [OperationContract]
        public ObservableCollection<tbl_dobavljac> PretraziDobavljaca(string ime)
        {
            ObservableCollection<tbl_dobavljac> ListaTrazenihDobavljaca = new ObservableCollection<tbl_dobavljac>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_dobavljacs where SqlMethods.Like(a.ime, "%" + ime + "%") select a;

                foreach (var p in query)
                {
                    ListaTrazenihDobavljaca.Add(
                         new tbl_dobavljac { 
                        id_dobavljac=p.id_dobavljac,
                        broj_dobavljaca=p.broj_dobavljaca,
                        tip=p.tip,
                        ime=p.ime,
                        prezime=p.prezime,
                        adresa=p.adresa,
                        tel1=p.tel1,
                        tel2=p.tel2,
                        mobitel=p.mobitel,
                        skype=p.skype,
                        fax=p.fax,
                        email=p.email,
                        banka=p.banka,
                        blz=p.blz,
                        KtoNr=p.KtoNr,
                        bic=p.bic,
                        iban=p.iban,
                        vlasnik_racuna=p.vlasnik_racuna,
                        biljeska=p.biljeska,
                        id_korisnik_FK=p.id_korisnik_FK,
                        promet=p.promet,
                        nacin_placanja=p.nacin_placanja,
                        zemlja=p.zemlja,
                        poslovanje=p.poslovanje,
                        popust=p.popust,
                        broj_dana=p.broj_dana,
                        gotovina=p.gotovina,
                        rabat=p.rabat,
                        ziro_racun=p.ziro_racun,
                        porez=p.porez

                    
                        });

                }
                return ListaTrazenihDobavljaca;
            }
        }

        [OperationContract]
        public void changeUserPocetnaOrAktivan(int tip, int idUser, bool value)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                try
                {
                    tbl_korisnik korisnik = context.tbl_korisniks.Single(e => e.id_korisnik == idUser);

                    if (tip == 1)
                    { korisnik.pocetna = value; }
                    else if (tip == 2)
                    { korisnik.aktivan = value; }

                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        [OperationContract]
        public void ChangeWorkerStatus(int idRadnika,bool status)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                try
                {
                    tbl_radnik radnik = context.tbl_radniks.Single(e => e.id_radnik == idRadnika);
                    radnik.status = status;
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [OperationContract]
        public void unesiBug(string bugText, int idUser, bool status, string date)
        {

            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            { 
            try
            {
                tbl_greske greske = new tbl_greske();
                greske.idUser = idUser;
                greske.sadrzaj = bugText;
                greske.status = status;
                greske.datum =date;

                context.tbl_greskes.InsertOnSubmit(greske);
                context.SubmitChanges();
            }
                catch(Exception e)
            {
                throw e;
            }
            }
        }

        [OperationContract]
        public ObservableCollection<tbl_greske> ListaBugova()
        {
            ObservableCollection<tbl_greske> Lista = new ObservableCollection<tbl_greske>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = from a in context.tbl_greskes select a;
                Lista.Clear();
                foreach (var p in x)
                {
                    Lista.Add(new tbl_greske
                    {
                        idUser = p.idUser,
                        sadrzaj = p.sadrzaj,
                        status = p.status,
                        datum = p.datum
                    });
                }

            }
            return Lista;
        }

        [OperationContract]
        public void changeBugStatus(string datum , bool statusValue)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                try
                {
                    tbl_greske greske = context.tbl_greskes.Single(e => e.datum == datum);                
                    greske.status = statusValue;
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        [OperationContract]
        public void DeleteBug(string datum)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_greskes where a.datum == datum select a;

                foreach (var p in query)
                {
                    context.tbl_greskes.DeleteOnSubmit(p);
                    context.SubmitChanges();
                }
            }
        }

        [OperationContract]
        public int MitarbeiterNr()
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = (from a in context.tbl_radniks select new { a.sifra_radnik }).ToList().LastOrDefault();
                if (x == null)
                    return 1000;
                else
                    return x.sifra_radnik + 1;
            }
        }

        [OperationContract]
        public int LieferantNr()
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = (from a in context.tbl_dobavljacs select new { a.broj_dobavljaca }).ToList().LastOrDefault();
                if (x == null)
                    return 1000;
                else
                    return x.broj_dobavljaca + 1;
            }
        }

        [OperationContract]
        public int KundenNr()
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = (from a in context.tbl_kupacs select new { a.broj_kupac }).ToList().LastOrDefault();
                if (x == null)
                    return 1000;
                else
                    return x.broj_kupac + 1;
            }
        }

        [OperationContract]
        public int AngebotNr()
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = (from a in context.tbl_angebots select new { a.angebotnr }).ToList().LastOrDefault();
                if (x == null)
                    return 1000;
                else
                    return x.angebotnr + 1;
            }
        }

        [OperationContract]
        public ObservableCollection<tbl_poruka_primljene> ListaPrimljenihPoruka(int id)
        {
            ObservableCollection<tbl_poruka_primljene> Lista = new ObservableCollection<tbl_poruka_primljene>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = from a in context.tbl_poruka_primljenes where a.primio == id select a;
                Lista.Clear();
                foreach (var p in x)
                {
                    Lista.Add(new tbl_poruka_primljene { 
                        id_poruka_primljene=p.id_poruka_primljene,
                        poslao=p.poslao,
                        primio=p.primio,
                        datum=p.datum,
                        procitano=p.procitano,
                        predmet=p.predmet,
                        naslov=p.naslov
                    });
                }
            }
            return Lista;
        }

        [OperationContract]
        public ObservableCollection<tbl_poruka_poslane> ListaPoslanihPoruka(int id)
        {
            ObservableCollection<tbl_poruka_poslane> Lista = new ObservableCollection<tbl_poruka_poslane>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = from a in context.tbl_poruka_poslanes where a.poslao == id select a;
                Lista.Clear();
                foreach(var p in x)
                {
                    Lista.Add(new tbl_poruka_poslane
                    {
                        id_poruka_poslane=p.id_poruka_poslane,
                        poslao=p.poslao,
                        primio=p.primio,
                        datum=p.datum,
                        predmet=p.predmet,
                        naslov=p.naslov
                    });
                }
            }
            return Lista;
        }

        [OperationContract]
        public void PosaljiPoruku(int primio, int poslao, string predmet,string naslov)
        {
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                tbl_poruka_primljene poruka = new tbl_poruka_primljene();
                poruka.naslov = naslov;
                poruka.poslao = poslao;
                poruka.predmet = predmet;
                poruka.primio = primio;
                poruka.procitano = false;
                poruka.datum = DateTime.Now;
                context.tbl_poruka_primljenes.InsertOnSubmit(poruka);
              

                tbl_poruka_poslane poslana = new tbl_poruka_poslane();
                poslana.naslov = naslov;
                poslana.poslao = poslao;
                poslana.predmet = predmet;
                poslana.datum = DateTime.Now;
                poslana.primio = primio;
                context.tbl_poruka_poslanes.InsertOnSubmit(poslana);
                context.SubmitChanges();
                
            }
        }

        [OperationContract]
        public ObservableCollection<tbl_kupac> ListaKupacaSearch(int broj)
        {
            ObservableCollection<tbl_kupac> Lista = new ObservableCollection<tbl_kupac>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var query = from a in context.tbl_kupacs where a.broj_kupac.ToString().Contains("/'"+broj+"'/")  select a;
                Lista.Clear();
                foreach (var p in query)
                {
                    Lista.Add(new tbl_kupac
                    {
                        id_kupac = p.id_kupac,
                        pojam = p.pojam,
                        ime = p.ime,
                        prezime = p.prezime,
                        mjesto = p.mjesto,
                        grupa = p.grupa,
                        slobodno_polje = p.slobodno_polje,
                        ime2 = p.ime2,
                        ulica = p.ulica,
                        tel1 = p.tel1,
                        tel2 = p.tel2,
                        fax = p.fax,
                        mail = p.mail,
                        lk = p.lk,
                        dostava_na = p.dostava_na,
                        dostava_od = p.dostava_od,
                        vk_cijena = p.vk_cijena,
                        gotovina = p.gotovina,
                        popust_gotovina = p.popust_gotovina,
                        dnevni_popust = p.dnevni_popust,
                        predstavnik = p.predstavnik,
                        limit_narudzbe = p.limit_narudzbe,
                        tip = p.tip,
                        adresa_dostava = p.adresa_dostava,
                        adresa_fakture = p.adresa_fakture,
                        mail2 = p.mail2,
                        interner = p.interner,
                        tip_kupca = p.tip_kupca,
                        porez = p.porez,
                        broj = p.broj,
                        broj_detalji = p.broj_detalji,
                        ocjena_kupca = p.ocjena_kupca,
                        biljeska = p.biljeska,
                        naziv = p.naziv,
                        zemlja = p.zemlja,
                        placa = p.placa,
                        rabat = p.rabat,
                        adresa2 = p.adresa2,
                        grad = p.grad,
                        predmet = p.predmet,
                        kontakt_osobe = p.kontakt_osobe,
                        detalji_rute = p.detalji_rute,
                        titel = p.titel,
                        broj_kupac = p.broj_kupac
                    });
                }
                return Lista;
            }
        }

        [OperationContract]
        public ObservableCollection<tbl_materijal> getMaterijal() 
        {
            ObservableCollection<tbl_materijal> ListaM = new ObservableCollection<tbl_materijal>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext()) 
            {
                var x = from a in context.tbl_materijals select a;
                ListaM.Clear();
                foreach (var p in x) 
                {
                    ListaM.Add(new tbl_materijal { idmaterijal = p.idmaterijal, naziv = p.naziv});
                }
            }
            return ListaM;
        }
        [OperationContract]
        public ObservableCollection<tbl_produkt> getProdukt() 
        {
            ObservableCollection<tbl_produkt> ListaP = new ObservableCollection<tbl_produkt>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext()) 
            {
                var x = from a in context.tbl_produkts select a;
                ListaP.Clear();
                foreach (var p in x)
                {
                    ListaP.Add(new tbl_produkt { idprodukt = p.idprodukt, naziv = p.naziv});
                }
            }
            return ListaP;
        }
        [OperationContract]
        public ObservableCollection<tbl_povrsina> getPovrsinaByMaterijal(int matId) 
        {
            ObservableCollection<tbl_povrsina> ListP = new ObservableCollection<tbl_povrsina>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext()) 
            {
                var x = from a in context.tbl_povrsinas where a.materijal_FK == matId select a;
                ListP.Clear();
                foreach (var p in x)
                {
                    ListP.Add(new tbl_povrsina{id = p.id, materijal_FK = p.materijal_FK, pov = p.pov});
                }
            }
            return ListP;
        }
        [OperationContract]
        public ObservableCollection<tbl_debljina> getDebljinaByProduktId(int prodId)
        {
            ObservableCollection<tbl_debljina> ListaD = new ObservableCollection<tbl_debljina>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext()) 
            {
                var x = from a in context.tbl_debljinas where a.idProdukt_FK == prodId select a;
                ListaD.Clear();
                foreach (var p in x) 
                {
                    ListaD.Add(new tbl_debljina {id_debljina = p.id_debljina, idProdukt_FK = p.idProdukt_FK, naziv = p.naziv});
                }
            }
            return ListaD;
        }
        [OperationContract]
        public ObservableCollection<tbl_materijal> getMatIdByName(string value) 
        {
            ObservableCollection<tbl_materijal> ListaM = new ObservableCollection<tbl_materijal>();
            using(DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = from a in context.tbl_materijals where a.naziv == value select a;
                ListaM.Clear();
                foreach(var p in x)
                {
                    ListaM.Add(new tbl_materijal { idmaterijal = p.idmaterijal, naziv = p.naziv});
                }
                return ListaM;
            }
        }
        [OperationContract]
        public ObservableCollection<tbl_produkt> getProIdByName(string value)
        {
            ObservableCollection<tbl_produkt> ListP = new ObservableCollection<tbl_produkt>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = from a in context.tbl_produkts where a.naziv == value select a;
                ListP.Clear();
                foreach (var p in x)
                {
                    ListP.Add(new tbl_produkt { idprodukt = p.idprodukt, naziv = p.naziv });
                }
            }
            return ListP;
        }
        [OperationContract]
        public ObservableCollection<tbl_debljina> getDebljinaIdByName(string value)
        {
            ObservableCollection<tbl_debljina> ListP = new ObservableCollection<tbl_debljina>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = from a in context.tbl_debljinas where a.naziv == value select a;
                ListP.Clear();
                foreach (var p in x)
                {
                    ListP.Add(new tbl_debljina { id_debljina = p.id_debljina, idProdukt_FK = p.idProdukt_FK, naziv = p.naziv });
                }
            }
            return ListP;
        }

        [OperationContract]
        public ObservableCollection<tbl_mit_kalendar> ListaEventaMitarbeiter()
        {
            ObservableCollection<tbl_mit_kalendar> Lista = new ObservableCollection<tbl_mit_kalendar>();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                var x = from a in context.tbl_mit_kalendars select a;
                Lista.Clear();
                foreach (var p in x)
                {
                    Lista.Add(new tbl_mit_kalendar
                    {
                        id_kalendar = p.id_kalendar,
                        id_korisnik_FK = p.id_korisnik_FK,
                        datum = p.datum,
                        datu1 = p.datu1,
                        tip = p.tip,
                        odobreno = p.odobreno,
                        pogledno = p.pogledno,
                        biljeska = p.biljeska
                    
                    });
                }

            }
            return Lista;
        }

        [OperationContract]
        public void UnesiEventMitarbeiter(tbl_mit_kalendar mit_kalendar, int id)
        {
            tbl_mit_kalendar mk = new tbl_mit_kalendar();
            using (DataBaseModelDataContext context = new DataBaseModelDataContext())
            {
                mk.id_korisnik_FK = id;
                mk.biljeska = mit_kalendar.biljeska;
                mk.datu1 = mit_kalendar.datu1;
                mk.datum = mit_kalendar.datum;
                mk.tip = mit_kalendar.tip;
                mk.odobreno = false;
                mk.pogledno = false;
                context.tbl_mit_kalendars.InsertOnSubmit(mk);
                context.SubmitChanges();
            }
        }
    }
}
   

