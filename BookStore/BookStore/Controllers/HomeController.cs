using BookStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
   
        public ActionResult BookList()
        {
            XmlElement xRoot = GetRoot();
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            List<Book> books = new List<Book>();
            foreach (XmlNode book in childnodes)
            {
                books.Add(new Book
                {
                    Category = book.ChildNodes[0].InnerText,
                    Title = book.ChildNodes[1].InnerText,
                    Author = book.ChildNodes[2].InnerText,
                    Price = decimal.Parse(book.ChildNodes[3].InnerText),
                    Available = book.ChildNodes[4].InnerText
                });
            }
            return View(books);
        }

        [HttpPost]
        public ActionResult BookList(string parameter) // POST версия. Вызывается по кнопке submit
        {
            XmlElement xRoot = GetRoot();
            XmlNodeList filteredBook;
                 
            switch (parameter)
            {
                case "Authors":
                    {
                        List<string> authors = new List<string>();
                        filteredBook = xRoot.SelectNodes("*");
                        foreach (XmlNode book in filteredBook)
                        {
                            authors.Add(book.ChildNodes[2].InnerText);
                        }
                        return View("Authors", authors); // вывод списка авторов в отдельное окно
                    }
                case "Books about Programming":
                    {                  
                        filteredBook = xRoot.SelectNodes("book[category='Programming']"); // фильтрация книг по категории                    
                    };
                    break;
                case "Books with a price lower than 20 $":
                    {
                        filteredBook = xRoot.SelectNodes("book[price < '20']"); // фильтрация книг по цене 
                    }
                    break;
                default: filteredBook = xRoot.SelectNodes("*"); break; // выборка всех книг
            }

            List<Book> books = new List<Book>();
            foreach (XmlNode book in filteredBook) 
            {
                books.Add(new Book
                {
                    Category = book.ChildNodes[0].InnerText,
                    Title = book.ChildNodes[1].InnerText,
                    Author = book.ChildNodes[2].InnerText,
                    Price = decimal.Parse(book.ChildNodes[3].InnerText),
                    Available = book.ChildNodes[4].InnerText
                }); // создание типизированного списка книг, для представления
            }
            return View("Booklist", books);

        }

        public ActionResult TakeAndReturnBookJson(string name, bool isTake)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Server.MapPath("~/XML/BookStoreDB.xml"));
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode available = xRoot.SelectSingleNode("book[title = '"+name+ "']/available"); 
            string response = null;
            if (available.InnerText == "Yes") 
            {
                if (isTake)
                {
                    available.InnerText = "No";
                    xDoc.Save(Server.MapPath("~/XML/BookStoreDB.xml"));
                    response = "The book " + name + " is taken";
                }
                else
                {
                    response = "The book  " + name + " is already in the store";
                }                
            }
            else
            {
                if (isTake)
                {
                    response = "This book  " + name + "  is already on hand";
                }
                else
                {
                    available.InnerText = "Yes";
                    xDoc.Save(Server.MapPath("~/XML/BookStoreDB.xml"));
                    response = "The book " + name + " returned to the store";
                }
            }
            
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        private XmlElement GetRoot()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Server.MapPath("~/XML/BookStoreDB.xml"));
            XmlElement xRoot = xDoc.DocumentElement;
            return xRoot;
        }
      

    }
}