using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using testapi.Models;

namespace testapi.Controllers
{
    public class UserController : ApiController
    {
        NewEntities db = new NewEntities();

        public string Post(userdata userdata)
        {
            db.userdatas.Add(userdata);
                db.SaveChanges();
            return "product added";
        }
        public IEnumerable<userdata> Get()
        {
            return db.userdatas.ToList();
        }

        public userdata Get(int id)
        {
            userdata userdata = db.userdatas.Find(id);
            return userdata;

        }
        public string Put(int id, userdata userdata)
        {
            var user_ = db.userdatas.Find(id);
            user_.fname = userdata.fname;
            user_.email = userdata.email;
            user_.mnumber = userdata.mnumber;
            user_.isactive = userdata.isactive;
            user_.isinacitive = userdata.isinacitive;
            db.Entry(user_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return "data updated";
        }
        public string Delete(int id)
        {
            userdata userdata = db.userdatas.Find(id);
            db.userdatas.Remove(userdata);
            db.SaveChanges();

            return "deleted";
        }
    }
}
