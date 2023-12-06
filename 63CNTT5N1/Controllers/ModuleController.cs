using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Model;

namespace _63CNTT5N1.Controllers
{
    public class ModuleController : Controller
    {
        MenusDAO menusDAO = new MenusDAO();
        // GET: Module

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MainMenu()
        {
            List<Menus> list = menusDAO.getListByParentId(0,"MainMenu");
            return View(list);
        }
        public ActionResult Slider()
        {
            SlidersDAO slidersDAO = new SlidersDAO();
            List<Sliders> list = slidersDAO.getListByPosition("slider");//ten ham dat tuy y
            return View("Slider", list);
        }
        public ActionResult MenuFooter()
        {
            MenusDAO menusDAO = new MenusDAO();
            List<Menus> list = menusDAO.getListByParentId(0, "Footer");
            return View("MenuFooter", list);
        }
    }
}