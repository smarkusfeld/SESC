using FinanceMicroservice.Core.Models;

namespace FinanceMicroservice.Infastructure.Context  
{
    public class DbInitializer 
    {

        public static void Initialize(DataContext context)
        {
            // Look for any inventory items
            if (context.Accounts.Any())
            {
                return;   // DB has been seeded
            }
            else
            {
                var accounts = new List<Account>
                {
                    //add accounts
                };
                accounts.ForEach(a => context.Accounts.Add(a));
                context.SaveChanges();
                var invoices = new List<Invoice>
                {
                    //add 
                };
                invoices.ForEach(i => context.Invoices.Add(i));
                context.SaveChanges();
                var payments = new List<Payment>
                {
                    //add 
                };
                payments.ForEach(p => context.Payments.Add(p));
                context.SaveChanges();
            }


        }
       
    }
}
