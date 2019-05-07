using APBD_TEST1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APBD_TEST1.DAL
{
    class EFdbConn
    {
        private PjatkDb connection;
        public EFdbConn()
        {
            connection = new PjatkDb();
        }
        public ICollection<EMP> GetEMPs()
        {
            var list = new List<EMP>();
            try
            {
                return connection.EMPs.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd łączenia z bazą danych");
                return list;
            }
        }
        public void AddEmpToDB(EMP toAdd)
        {
            try
            {
                connection.EMPs.Add(toAdd);
                connection.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd łączenia z bazą danych");
            }
           
        }
    }
}
