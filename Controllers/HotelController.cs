using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudHotel.Models;

// <Nombre_de_proyecto>.Controllers
namespace CrudHotel.Controllers
{
    [RoutePrefix("Api/Hotel")]
    public class HotelController : ApiController
    {
        // <Nombre_de_BD>Entities
        HotelDemoEntities DB = new HotelDemoEntities();
        [Route("AddOrUpdateHotel")]
        [HttpPost]
        public object AddOrUpdateHotel(Hotel st)
        {
            try
            {
                if (st.IdHotel == 0)
                {
                    Hoteles sm = new Hoteles();
                    sm.Nombre = st.Nombre;
                    sm.Estrella = st.Estrella;

                    DB.Hoteles.Add(sm);
             
                    DB.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
                else
                {
                    var obj = DB.Hoteles.Where(x => x.IdHotel == st.IdHotel).ToList().FirstOrDefault();
                    if (obj.IdHotel > 0)
                    {

                        obj.Nombre = st.Nombre;
                        obj.Estrella = st.Estrella;
                      
                        DB.SaveChanges();
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };

        }
        [Route("HotelDetails")]
        [HttpGet]
        public object HotelDetails()
        {

            var a = DB.Hoteles.ToList();
            return a;
        }

        [Route("HotelDetailById")]
        [HttpGet]
        public object HotelDetailById(int id)
        {
            var obj = DB.Hoteles.Where(x => x.IdHotel == id).ToList().FirstOrDefault();
            return obj;
        }
        [Route("DeleteHotel")]
        [HttpDelete]
        public object DeleteHotel(int id)
        {
            var obj = DB.Hoteles.Where(x => x.IdHotel == id).ToList().FirstOrDefault();
            DB.Hoteles.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
    }


}