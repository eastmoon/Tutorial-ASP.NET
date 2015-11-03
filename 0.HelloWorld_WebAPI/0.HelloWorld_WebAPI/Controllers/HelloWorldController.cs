using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _0.HelloWorld_WebAPI.Models;

namespace _0.HelloWorld_WebAPI.Controllers
{
    public class HelloWorldController : ApiController
    {
        User[] m_userlist = new User[]
        {
            new User{ID = 1, Name ="Jacky", Mail ="xxx@hotmail.com"},
            new User{ID = 2, Name ="Albert", Mail ="yyy@hotmail.com"},
            new User{ID = 3, Name ="Atlanis", Mail ="zzz@hotmail.com"},
            new User{ID = 4, Name ="James", Mail ="www@hotmail.com"}
        };

        // GET : api/helloworld
        public IEnumerable<User> GetAllHelloWorld()
        {
            return m_userlist;
        }

        // GET : api/helloworld/[ID]
        [ActionName("user")]
        public IHttpActionResult GetHello(int id)
        {
            var user = this.m_userlist.FirstOrDefault((p) => p.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // GET : api/helloworld/mail/[ID]
        [ActionName("mail")]
        public IHttpActionResult GetMail(int id)
        {
            var user = this.m_userlist.FirstOrDefault((p) => p.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Mail);
        }
    }
}
