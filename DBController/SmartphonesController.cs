using SimpleConnectio.Models;

namespace SimpleConnectio.DBController
{
    public class SmartphonesController
    {

        public IEnumerable<Smartphone> GetAll()
        {
            return new SmartphonesDataBaseContext().Smartphones.ToList();
        }

        public bool Add(Smartphone smartphone)
        {
            if (smartphone == null)
                return false;

            using (SmartphonesDataBaseContext context = new SmartphonesDataBaseContext())
            {
                context.Smartphones.Add(smartphone);
                context.SaveChanges();
                return true;
            }
        }

        public bool Remove(int id)
        {
            if (id <= 0)
                return false;

            using (SmartphonesDataBaseContext context = new SmartphonesDataBaseContext())
            {
                var con = context.Smartphones.FirstOrDefault(x => x.Id == id);
                if (con == null)
                    return false;
                context.Remove(con);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(int id, Smartphone smartphone)
        {
            if (id <= 0)
                return false;

            using (SmartphonesDataBaseContext context = new SmartphonesDataBaseContext())
            {
                var con = context.Smartphones.FirstOrDefault(x => x.Id == id);
                if (con == null)
                    return false;
                con.Model = con.Model;
                con.Name = con.Name;
                context.SaveChanges();
                return true;
            }
        }
    }
}
