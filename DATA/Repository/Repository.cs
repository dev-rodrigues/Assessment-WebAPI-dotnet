using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db = DATA.Context.Database;

namespace DATA.Repository {
    public class Repository<T> where T : class {

        public T Salvar(T objeto) {
            try {
                Db.GetInstance.Entry(objeto).State = System.Data.Entity.EntityState.Added;
                Db.GetInstance.SaveChanges();
                return objeto;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public T FindOne(object id) {
            try {
                return Db.GetInstance.Set<T>().Find(id);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
