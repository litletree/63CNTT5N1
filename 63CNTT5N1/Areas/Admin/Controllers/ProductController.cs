﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;
using MyClass.DAO;
using UDW.Library;
using System.IO;

namespace _63CNTT5N1.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductsDAO productsDAO = new ProductsDAO();
        CategoriesDAO categoriesDAO = new CategoriesDAO();
        SuppliersDAO suppliersDAO = new SuppliersDAO();

        //////////////////////////////////////////////////////////////////////////////////////
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(productsDAO.getList("Index"));
        }

        //////////////////////////////////////////////////////////////////////////////////////
        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại sản phẩm");
                return RedirectToAction("Index");
            }
            Products products = productsDAO.getRow(id);
            if (products == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại sản phẩm");
                return RedirectToAction("Index");
            }
            return View(products);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.ListCatID = new SelectList(categoriesDAO.getList("Index"), "id", "Name");//sai CatID - truy van tu bang Categories
            ViewBag.ListSupID = new SelectList(suppliersDAO.getList("Index"), "id", "Name");//sai SupplierID - truy van bang Suppliers
            //dung de lua chon tu danh sach droplist nhu bang Categories: ParentID va Supplier: ParentID
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                //Xu ly thong tin tu dong mot so truong
                //Xu ly tu dong: CreateAt
                products.CreateAt = DateTime.Now;
                //Xu ly tu dong: UpdateAt
                products.UpdateAt = DateTime.Now;
                //Xu ly tu dong: CreateBy
                products.CreateBy = Convert.ToInt32(Session["UserId"]);
                //Xu ly tu dong: Updateby
                products.UpdateBy = Convert.ToInt32(Session["UserId"]);
                //Xu ly tu dong: Slug
                products.Slug = XString.Str_Slug(products.Name);

                //xu ly cho phan upload hình ảnh
                var img = Request.Files["img"];//lay thong tin file
                if (img.ContentLength != 0)
                {
                    string[] FileExtentions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    //kiem tra tap tin co hay khong
                    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))//lay phan mo rong cua tap tin
                    {
                        string slug = products.Slug;
                        //ten file = Slug + phan mo rong cua tap tin
                        string imgName = slug + img.FileName.Substring(img.FileName.LastIndexOf("."));
                        products.Img = imgName;
                        //upload hinh
                        string PathDir = "~/Public/img/product";
                        string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                        img.SaveAs(PathFile);
                    }
                }//ket thuc phan upload hinh anh

                //Luu vao DB
                productsDAO.Insert(products);
                // thong bao thanh cong
                TempData["message"] = new XMessage("success", "Tạo mới sản phẩm thành công ");
                return RedirectToAction("Index");
            }
            ViewBag.ListCatID = new SelectList(categoriesDAO.getList("Index"), "id", "Name");//sai CatID - truy van tu bang Categories
            ViewBag.ListSupID = new SelectList(suppliersDAO.getList("Index"), "id", "Name");//sai SupplierID - truy van bang Suppliers
            return View(products);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại sản phẩm");
                return RedirectToAction("Index");
            }
            Products products = productsDAO.getRow(id);
            if (products == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại sản phẩm");
                return RedirectToAction("Index");
            }
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                //xu ly tu dong cho cac truong: Slug, CreateAt/By, UpdateAt/By, Order
                //Xu ly tu dong: UpdateAt
                products.UpdateAt = DateTime.Now;

                //Xu ly tu dong: Slug
                products.Slug = XString.Str_Slug(products.Name);

                //xu ly cho phan upload hình ảnh
                var img = Request.Files["img"];//lay thong tin file
                string PathDir = "~/Public/img/supplier/";
                if (img.ContentLength != 0)
                {
                    //xu ly cho muc xoa hinh anh
                    if (products.Img != null)
                    {
                        string DelPath = Path.Combine(Server.MapPath(PathDir), products.Img);
                        System.IO.File.Delete(DelPath);
                    }
                    string[] FileExtentions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    //kiem tra tap tin co hay khong
                    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))//lay phan mo rong cua tap tin
                    {
                        string slug = products.Slug;
                        //ten file = Slug + phan mo rong cua tap tin
                        string imgName = slug + img.FileName.Substring(img.FileName.LastIndexOf("."));
                        products.Img = imgName;
                        //upload hinh
                        string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                        img.SaveAs(PathFile);
                    }
                }//ket thuc phan upload hinh anh         

                //cap mhat mau tin vao DB
                productsDAO.Update(products);
                // thong bao thanh cong
                TempData["message"] = new XMessage("success", "Cập nhật sản phẩm thành công");
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại sản phẩm");
                return RedirectToAction("Index");
            }
            Products products = productsDAO.getRow(id);
            if (products == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại sản phẩm");
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = productsDAO.getRow(id);
            //xu ly cho phan upload hình ảnh
            var img = Request.Files["img"];//lay thong tin file
            string PathDir = "~/Public/img/supplier/";
            //xoa mau tin ra khoi DB
            if (productsDAO.Delete(products) == 1)
            {
                //Xu ly cho muc xoa hinh anh
                if (products.Img != null)
                {
                    string DelPath = Path.Combine(Server.MapPath(PathDir), products.Img);
                    System.IO.File.Delete(DelPath);
                }
            }
            // thong bao thanh cong
            TempData["message"] = new XMessage("success", "Xóa sản phẩm thành công");
            return RedirectToAction("Index");
        }
        //phat sinh them mot so aciton moi: Status, Trash, Deltrash, Undo
        //////////////////////////////////////////////////////////////////////////////////////
        // STATUS
        // GET: Admin/Category/Status/5

        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }

            // tim row co id == id cua loai SP can thay doi Status
            Products products = productsDAO.getRow(id);

            if (products == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            else
            {
                // kiem tra trang thai cua status; neu hien tai la 1 -> 2 va nguoc lai
                products.Status = (products.Status == 1) ? 2 : 1;

                // cap nhat gia tri cho UpdateAt
                products.UpdateAt = DateTime.Now;

                // cap nhat lai DB
                productsDAO.Update(products);

                // thong bao thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Cập nhật trạng thái thành công");

                // tra ket qua ve Index
                return RedirectToAction("Index");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////
        // STATUS
        // GET: Admin/Category/DelTrash/5
        public ActionResult DelTrash(int? id)
        {
            if (id == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "không tìm thấy mẫu tin");
                return RedirectToAction("Index");
            }

            // tim row co id == id cua loai SP can thay doi Status
            Products products = productsDAO.getRow(id);

            if (products == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "không tìm thấy mẫu tin");
                return RedirectToAction("Index");
            }
            else
            {
                // kiem tra trang thai cua status tu 1,2 -> 0: khong hien thi o Index
                products.Status = 0;

                // cap nhat gia tri cho UpdateAt
                products.UpdateAt = DateTime.Now;

                // cap nhat lai DB
                productsDAO.Update(products);

                // thong bao thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "xóa mẫu tin thành công");

                // tra ket qua ve Index
                return RedirectToAction("Index");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////
        //Luc thung rac
        // GET: Admin/Product/Trash
        public ActionResult Trash()
        {
            return View(productsDAO.getList("Trash"));
        }

        //////////////////////////////////////////////////////////////////////////////////////
        // Recover
        // GET: Admin/Category/Recover/5

        public ActionResult Recover(int? id)
        {
            if (id == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "Phục hồi mẫu tin thất bại");
                return RedirectToAction("Index");
            }

            // tim row co id == id cua loai SP can thay doi Status
            Products products = productsDAO.getRow(id);

            if (products == null)
            {
                // thong bao that bai
                TempData["message"] = new XMessage("danger", "Phục hồi mẫu tin thất bại");
                return RedirectToAction("Index");
            }
            else
            {
                // kiem tra trang thai cua status tu 0 -> 2: khong xuat ban
                products.Status = 2;

                // cap nhat gia tri cho UpdateAt
                products.UpdateAt = DateTime.Now;

                // cap nhat lai DB
                productsDAO.Update(products);

                // thong bao phuc hoi du lieu thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Phục hồi mẫu tin thành công");

                // tra ket qua ve Index
                return RedirectToAction("Index");
            }
        }
    }
}