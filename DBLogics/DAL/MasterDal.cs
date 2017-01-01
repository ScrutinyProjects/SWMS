using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooleanHelper;
using System.Data.SqlClient;
using System.Configuration;
using DBLogics.Responses;
using System.Data;

namespace DBLogics.DAL
{
    public class MasterDal
    {
        #region Members

        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);
        BooleanDAL objBooleanDAL = new BooleanDAL();

        #endregion

        #region Procedures

        private static string PROC_USP_GetComplaintTypes = "USP_GetComplaintTypes";//Karteek

        #endregion

        #region Methods

        public List<ComplaintTypeResponse> GetComplaintTypes()
        {
            DataSet ds = new DataSet();
            List<ComplaintTypeResponse> objComplaintTypeResponse = new List<ComplaintTypeResponse>();

            try
            {
                ds = objBooleanDAL.ExecuteDataSet(PROC_USP_GetComplaintTypes, con);

                if (ds.Tables.Count > 0)
                {
                    objComplaintTypeResponse = ds.Tables[0].AsEnumerable().Select(dataRow => new ComplaintTypeResponse
                    {
                        ComplaintType = dataRow.Field<string>("ComplaintType"),
                        ComplaintTypeID = dataRow.Field<int>("ComplaintTypeID")
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return objComplaintTypeResponse;
        }
        
        #endregion
    }
}
