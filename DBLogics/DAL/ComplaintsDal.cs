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
    public class ComplaintsDal
    {
        #region Members

        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);
        BooleanDAL objBooleanDAL = new BooleanDAL();

        #endregion

        #region Procedures

        private static string PROC_USP_GetCitizenComplaints = "USP_GetCitizenComplaints";//Karteek
        private static string PROC_USP_GetDepartmentComplaints = "USP_GetDepartmentComplaints";//Karteek
        private static string PROC_USP_InsertComplaintDetails = "USP_InsertComplaintDetails";//Karteek
        private static string PROC_USP_UpdateComplaintStatusToCleaned = "USP_UpdateComplaintStatusToCleaned";//Karteek

        #endregion

        #region Methods

        public List<ComplaintsResponse> GetCitizenComplaints(long loginId)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@LoginID", SqlDbType.BigInt) { Value = loginId } };
            DataSet ds = new DataSet();
            List<ComplaintsResponse> objComplaintsResponse = new List<ComplaintsResponse>();

            try
            {
                ds = objBooleanDAL.ExecuteDataSet(sqlparams, PROC_USP_GetCitizenComplaints, con);

                if (ds.Tables.Count > 0)
                {
                    objComplaintsResponse = ds.Tables[0].AsEnumerable().Select(dataRow => new ComplaintsResponse
                    {
                        ComplaintType = dataRow.Field<string>("ComplaintType"),
                        ComplaintTypeID = dataRow.Field<int>("ComplaintTypeID"),
                        CompliantID = dataRow.Field<int>("CompliantID"),
                        CompliantStatusID = dataRow.Field<int>("CompliantStatusID"),
                        CompliantStatus = dataRow.Field<string>("CompliantStatus"),
                        Longitude = dataRow.Field<string>("Longitude"),
                        Latitude = dataRow.Field<string>("Latitude"),
                        ImagePath = dataRow.Field<string>("ImagePath"),
                        ComplainedDate = dataRow.Field<string>("ComplainedDate"),
                        PendingDays = dataRow.Field<int>("PendingDays")
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
            return objComplaintsResponse;
        }

        public List<ComplaintsResponse> GetDepartmentComplaints(long loginId)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@LoginID", SqlDbType.BigInt) { Value = loginId } };
            DataSet ds = new DataSet();
            List<ComplaintsResponse> objComplaintsResponse = new List<ComplaintsResponse>();

            try
            {
                ds = objBooleanDAL.ExecuteDataSet(sqlparams, PROC_USP_GetDepartmentComplaints, con);

                if (ds.Tables.Count > 0)
                {
                    objComplaintsResponse = ds.Tables[0].AsEnumerable().Select(dataRow => new ComplaintsResponse
                    {
                        ComplaintType = dataRow.Field<string>("ComplaintType"),
                        ComplaintTypeID = dataRow.Field<int>("ComplaintTypeID"),
                        CompliantID = dataRow.Field<int>("CompliantID"),
                        CompliantStatusID = dataRow.Field<int>("CompliantStatusID"),
                        CompliantStatus = dataRow.Field<string>("CompliantStatus"),
                        Longitude = dataRow.Field<string>("Longitude"),
                        Latitude = dataRow.Field<string>("Latitude"),
                        ImagePath = dataRow.Field<string>("ImagePath"),
                        ComplainedDate = dataRow.Field<string>("ComplainedDate"),
                        PendingDays = dataRow.Field<int>("PendingDays")
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
            return objComplaintsResponse;
        }

        public DefaultResponse InsertComplaintDetails(int loginId, int compliantTypeID, string latitude, string longitude, string imagePath, string notes)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@ComplaintTypeID", SqlDbType.Int) { Value = compliantTypeID },
                                            new SqlParameter("@LoginID", SqlDbType.Int) { Value = loginId },
                                            new SqlParameter("@Latitude", SqlDbType.VarChar, 20) { Value = latitude },
                                            new SqlParameter("@Longitude", SqlDbType.VarChar, 20) { Value = longitude },
                                            new SqlParameter("@ImagePath", SqlDbType.VarChar, 1000) { Value = imagePath },
                                            new SqlParameter("@Notes", SqlDbType.VarChar, 200) { Value = notes }};
            SqlDataReader reader = null;
            DefaultResponse objDefaultResponse = new DefaultResponse();

            try
            {
                reader = objBooleanDAL.ExecuteDataReader(sqlparams, PROC_USP_InsertComplaintDetails, con);

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

        public DefaultResponse UpdateComplaintStatusToCleaned(long loginId, int compliantID)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@CompliantID", SqlDbType.Int) { Value = compliantID },
                                            new SqlParameter("@LoginID", SqlDbType.BigInt) { Value = loginId }};
            SqlDataReader reader = null;
            DefaultResponse objDefaultResponse = new DefaultResponse();

            try
            {
                reader = objBooleanDAL.ExecuteDataReader(sqlparams, PROC_USP_UpdateComplaintStatusToCleaned, con);

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