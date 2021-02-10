using DAL.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DAL.Contexts
{
    public class OracleContext
    {
        OracleConnection con = null;
        OracleCommand cmd = null;
        OracleDataReader reader = null;

        public List<SMPRICE> SMPRICES = new List<SMPRICE>();

        public OracleContext()
        {
            try
            {
                string constr = "user id = SM_VIEW; password = SELENA44; data source = 10.0.0.12:1521/DATA";
                con = new OracleConnection(constr);
                con.Open();

                //string Command = "SELECT SMPRICES.* FROM SUPERMAG.SMPRICES";
                //string Command = "SELECT SubQuery.ARTICLE, SubQuery.PRICE, SubQuery.STORELOC, SubQuery.SHOWLEVEL FROM(SELECT SMPRICES.STORELOC, SMPRICES.PRICE, SMPRICES.PRICETYPE, SMSTOCKLEVELS.SHOWLEVEL, CONCAT(CONCAT(SMPRICES.PRICETYPE, ' '), SMPRICES.STORELOC) AS EXPR1, SMPRICES.ARTICLE FROM SUPERMAG.SMPRICES INNER JOIN SUPERMAG.SMSTOCKLEVELS ON SMPRICES.ARTICLE = SMSTOCKLEVELS.ARTICLE AND SMPRICES.STORELOC = SMSTOCKLEVELS.STORELOC) SubQuery WHERE SubQuery.EXPR1 NOT LIKE '0 43' AND SubQuery.EXPR1 NOT LIKE '0 41' AND SubQuery.EXPR1 NOT LIKE '0 36' AND SubQuery.PRICETYPE <> 1 AND SubQuery.PRICETYPE <> 2 AND SubQuery.PRICETYPE <> 3";
                string Command = "SELECT SubQuery.ARTICLE,       SubQuery.PRICE,       SubQuery.STORELOC,       SubQuery.SHOWLEVEL,       SMCARD.SHORTNAME  FROM (SELECT SMPRICES.STORELOC,               SMPRICES.PRICE,               SMPRICES.PRICETYPE,               SMSTOCKLEVELS.SHOWLEVEL,               CONCAT(CONCAT(SMPRICES.PRICETYPE, ' '), SMPRICES.STORELOC) AS EXPR1,               SMPRICES.ARTICLE      FROM SUPERMAG.SMPRICES        INNER JOIN SUPERMAG.SMSTOCKLEVELS          ON SMPRICES.ARTICLE = SMSTOCKLEVELS.ARTICLE          AND SMPRICES.STORELOC = SMSTOCKLEVELS.STORELOC) SubQuery    INNER JOIN SUPERMAG.SMCARD      ON SubQuery.ARTICLE = SMCARD.ARTICLE  WHERE SubQuery.EXPR1 NOT LIKE '0 43'    AND SubQuery.EXPR1 NOT LIKE '0 41'    AND SubQuery.EXPR1 NOT LIKE '0 36'    AND SubQuery.PRICETYPE <> 1    AND SubQuery.PRICETYPE <> 2    AND SubQuery.PRICETYPE <> 3";

                cmd = new OracleCommand(Command, con);
                cmd.CommandType = System.Data.CommandType.Text;

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SMPRICES.Add(new SMPRICE(reader.GetString(2), reader.GetString(0), reader.GetString(1), reader.GetString(3), reader.GetString(4)));
                    //Console.WriteLine(reader.GetString(0) + "|" + reader.GetString(1) + "|" + reader.GetString(2) + "|" + reader.GetString(3)); //Just example
                }
            }
            catch //(Exception e)
            {
                new Exception("failed to connect to the database");
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }
        }
    }
}
