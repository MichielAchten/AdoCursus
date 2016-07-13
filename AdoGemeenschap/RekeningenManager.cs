using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace AdoGemeenschap
{
    public class RekeningenManager
    {
        public Int32 SaldoBonus()
        {
            var dbManager = new BankDbManager();
            using (var conBank = dbManager.GetConnection())
            {
                using (var comBonus = conBank.CreateCommand())
                {
                    comBonus.CommandType = CommandType.Text;
                    comBonus.CommandText = "update Rekeningen set Saldo=Saldo*1.1";
                    conBank.Open();
                    return comBonus.ExecuteNonQuery();
                }
            }
        }

        public Boolean Storten(Decimal teStorten, string rekeningNr)
        {
            BankDbManager dbManager = new BankDbManager();
            using (var conBank = dbManager.GetConnection())
            {
                using (var comStorten = conBank.CreateCommand())
                {
                    comStorten.CommandType = CommandType.StoredProcedure;
                    comStorten.CommandText = "Storten";

                    DbParameter parTeStorten = comStorten.CreateParameter();
                    parTeStorten.ParameterName = "@teStorten";
                    parTeStorten.Value = teStorten;
                    parTeStorten.DbType = DbType.Currency;
                    comStorten.Parameters.Add(parTeStorten);

                    DbParameter parRekeningNr = comStorten.CreateParameter();
                    parRekeningNr.ParameterName = "@RekeningNr";
                    parRekeningNr.Value = rekeningNr;
                    comStorten.Parameters.Add(parRekeningNr);

                    conBank.Open();
                    return comStorten.ExecuteNonQuery() != 0;
                }
            }
            
            //var dbManager = new BankDbManager();
            //using (var conBank = dbManager.GetConnection())
            //{
            //    using (var comStorten = conBank.CreateCommand())
            //    {
            //        comStorten.CommandType = CommandType.Text;
            //        comStorten.CommandText = "update Rekeningen set Saldo=saldo+@teStorten where RekeningNr=@RekeningNr";

            //        DbParameter parTeStorten = comStorten.CreateParameter();
            //        parTeStorten.ParameterName = "@teStorten";
            //        parTeStorten.Value = teStorten;
            //        comStorten.Parameters.Add(parTeStorten);

            //        DbParameter parRekeningNr = comStorten.CreateParameter();
            //        parRekeningNr.ParameterName = "@RekeningNr";
            //        parRekeningNr.Value = rekeningNr;
            //        comStorten.Parameters.Add(parRekeningNr);

            //        conBank.Open();
            //        return comStorten.ExecuteNonQuery() != 0;
            //    }
            //}
        }
    }
}
