using AracKiralama.Entity;
using AracKiralama.Repository;
using AracKiralamaWebApi.Models;
using AracKiralamaWebApi.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AracKiralamaWebApi.Controllers
{
    
    public class AracController : ApiController
    {
        
        // GET: Arac
        public IHttpActionResult AracList()
        {
            using (var ar=new AraclarRepository())
            {
                List<araclar>  aracs = ar.AraclariListele();
                var content = new ResponseContent<araclar>(aracs);
                return new StandartResult<araclar>(content, Request);
            }
        }
        public IHttpActionResult KullaniciList()
        {
            using (var kr = new KullanicilarRepository())
            {
                List<kullanicilar> Kullanicilars= kr.KullaniciListele();
                var content = new ResponseContent<kullanicilar>(Kullanicilars);
                return new StandartResult<kullanicilar>(content, Request);
            }
        }
        public IHttpActionResult AracEkle(araclar araba)
        {
            var content = new ResponseContent<araclar>(null);
            if (araba != null)
            {
                using (var ar = new AraclarRepository())
                {
                    content.Result =ar.AracInsert(araba) ? "1" : "0";

                    return new StandartResult<araclar>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<araclar>(content, Request);
        }
        public IHttpActionResult KullaniciEkle(kullanicilar kullanicilar)
        {
            var content = new ResponseContent<kullanicilar>(null);
            if (kullanicilar != null)
            {
                using (var kr = new KullanicilarRepository())
                {
                    content.Result = kr.KullaniciInsert(kullanicilar) ? "1" : "0";

                    return new StandartResult<kullanicilar>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<kullanicilar>(content, Request);
        }
        public IHttpActionResult UpdateArac(int id,araclar arac)
        {
            var content = new ResponseContent<araclar>(null);

            if (arac != null)
            {
                using (var ar = new AraclarRepository())
                {
                    content.Result = ar.AracUpdate(arac) ? "1" : "0";

                    return new StandartResult<araclar>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<araclar>(content, Request);
        }
        public IHttpActionResult UpdateKullanici(int id, kullanicilar kul)
        {
            var content = new ResponseContent<kullanicilar>(null);

            if (kul != null)
            {
                using (var kr = new KullanicilarRepository())
                {
                    content.Result = kr.KullaniciUpdate(kul) ? "1" : "0";

                    return new StandartResult<kullanicilar>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<kullanicilar>(content, Request);
        }
        public IHttpActionResult AracDelete(int id)
        {
            var content = new ResponseContent<araclar>(null);

            using (var ar = new AraclarRepository())
            {
                content.Result = ar.AracDelete(id) ? "1" : "0";

                return new StandartResult<araclar>(content, Request);
            }
        }
        public IHttpActionResult KullaniciDelete(int id)
        {
            var content = new ResponseContent<kullanicilar>(null);

            using (var kr = new KullanicilarRepository())
            {
                content.Result = kr.KullaniciDelete(id) ? "1" : "0";

                return new StandartResult<kullanicilar>(content, Request);
            }
        }
        public IHttpActionResult AracKirala(kiralikAraclar arac)
        {
            var content = new ResponseContent<kiralikAraclar>(null);
            if (arac != null)
            {
                using (var ar = new AraclarRepository())
                {
                    content.Result = ar.AracKirala(arac) ? "1" : "0";

                    return new StandartResult<kiralikAraclar>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<kiralikAraclar>(content, Request);
        }
    }
}