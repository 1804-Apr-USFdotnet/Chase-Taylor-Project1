using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using NLog;

namespace RestaurantDataAccessLayer
{
    public class Crud<T> where T : class
    {
        private RestaurantDBEntities3 database;
        public DbSet<T> ents;
        public Crud()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            database = new RestaurantDBEntities3();
            ents = database.Set<T>();
        }

        public List<T> ToList()
        {
            return ents.ToList<T>();
        }
        public T Retrieve(object index)
        {
            return ents.Find(index);
        }

        public bool Add(T ent)
        {
            try
            {
                if (ent == null)
                {
                    throw new ArgumentNullException("entity");
                }
                ents.Add(ent);
                database.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                Logger log = LogManager.GetCurrentClassLogger();
                log.Error(fail, msg);
                return false;
            }
            catch (Exception ex)
            {
                Logger log = LogManager.GetCurrentClassLogger();
                log.Error(ex, "broken");
                return false;
            }
        }

        public bool Delete(T ent)
        {
            try
            {
                if (ent == null)
                {
                    throw new ArgumentNullException("entity");
                }
                ents.Remove(ent);
                database.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                Logger log = LogManager.GetCurrentClassLogger();
                log.Error(fail, msg);
                return false;
            }
            catch(Exception ex)
            {
                Logger log = LogManager.GetCurrentClassLogger();
                log.Error(ex, "broken");
                return false;
            }
        }

        public bool Update(T oldEnt, T newEnt)
        {
            try
            {
                if (newEnt == null)
                {
                    throw new ArgumentNullException("entity");
                }
                database.Entry(oldEnt).CurrentValues.SetValues(newEnt);
                    database.SaveChanges();
                    return true;

            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                Logger log = LogManager.GetCurrentClassLogger();
                log.Error(fail, msg);
                return false;
            }
            catch (Exception ex)
            {
                Logger log = LogManager.GetCurrentClassLogger();
                log.Error(ex, "broken");
                return false;
            }
        }
    }
}
