using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult BookList()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Server.MapPath("~/XML/BookStoreDB.xml"));
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("*");

            List<Book> books = new List<Book>();

            foreach (XmlNode book in childnodes)
            {
                books.Add(new Book { Category = book.ChildNodes[0].InnerText, Title = book.ChildNodes[1].InnerText,
                    Author = book.ChildNodes[2].InnerText, Price = book.ChildNodes[3].InnerText });
            }
            return View(books);
        }
    }
}