using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class UsesrDAO
    {
        private MyDBContext db = new MyDBContext();

        //SELECT * FROM ...
        public List<Users> getList()
        {
            return db.Users.ToList();
        }

        //Index chi voi staus 1,2        
        public List<Users> getList(string status = "ALL")//status 0,1,2
        {
            List<Users> list = null;
            switch (status)
            {
                default:
                    {
                        list = db.Users.ToList();
                        break;
                    }
            }
            return list;
        }
        //details
        public Users getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Users.Find(id);
            }
        }

        //tao moi mau tin
        public int Insert(Users row)
        {
            db.Users.Add(row);
            return db.SaveChanges();
        }

        //cap nhat mau tin
        public int Update(Users row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }

        //Xoa mau tin
        public int Delete(Users row)
        {
            db.Users.Remove(row);
            return db.SaveChanges();//thanh cong => return 1
        }
    }

}
