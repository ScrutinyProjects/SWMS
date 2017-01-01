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
    public class TrackingDal
    {
        #region Members

        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);
        BooleanDAL objBooleanDAL = new BooleanDAL();

        #endregion

        #region Procedures

        private static string PROC_USP_InsertLiveTrackingDetails = "USP_InsertLiveTrackingDetails";//Karteek

        #endregion

        #region Methods

        public DefaultResponse SaveLiveTrackingDetails(string imei, int loginId, int cycleId, long tripId, string latitude, string longitude, int bearing)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@IMEI", SqlDbType.VarChar, 50) { Value = imei },
                                            new SqlParameter("@Latitude", SqlDbType.VarChar, 20) { Value = latitude },
                                            new SqlParameter("@Longitude", SqlDbType.VarChar, 20) { Value = longitude },
                                            new SqlParameter("@LoginID", SqlDbType.Int) { Value = loginId },
                                            new SqlParameter("@CycleID", SqlDbType.Int) { Value = cycleId },
                                            new SqlParameter("@TripID", SqlDbType.BigInt) { Value = tripId },
                                            new SqlParameter("@Bearing", SqlDbType.Int) { Value = bearing }};
            SqlDataReader reader = null;
            DefaultResponse objDefaultResponse = new DefaultResponse();

            try
            {
                reader = objBooleanDAL.ExecuteDataReader(sqlparams, PROC_USP_InsertLiveTrackingDetails, con);

                while (reader.Read())
                {
                    objDefaultResponse.StatusID = (int)reader["StatusID"];
                    objDefaultResponse.StatusMessage = (string)reader["StatusMessage"];
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
            return objDefaultResponse;
        }

        #endregion
    }
}
