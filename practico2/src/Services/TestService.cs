using Common;
using System.Data.SqlClient;
using UnitOfWork.Interfaces;

namespace Services
{
    public class TestService
    {
        public static void TestConnection(IUnitOfWork _unitOfWork)
        {
            try
            {

                using (var context = _unitOfWork.Create())
                {
                    Console.WriteLine("SQL Connection successful");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sql Server: {ex.Message}");
            }
        }

    }
}