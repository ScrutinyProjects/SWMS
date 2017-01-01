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
    public class RegistrationDal
    {
        #region Members

        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);
        BooleanDAL objBooleanDAL = new BooleanDAL();

        #endregion

        #region Procedures

        private static string PROC_USP_RegisterUser = "USP_RegisterUser";//Karteek
        private static string PROC_USP_VerifyRegisteredUserOTP = "USP_VerifyRegisteredUserOTP";//Karteek

        #endregion

        #region Methods

        public RegistrationResponse UserRegistration(string userName, string emailId, string mobileNumber, string address)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserName", SqlDbType.VarChar, 50) { Value = userName },
                                            new SqlParameter("@EmailID", SqlDbType.VarChar, 100) { Value = emailId },
                                            new SqlParameter("@MobileNumber", SqlDbType.VarChar, 20) { Value = mobileNumber },
                                            new SqlParameter("@Address", SqlDbType.VarChar, 200) { Value = address }};
            SqlDataReader reader = null;
            RegistrationResponse objRegistrationResponse = new RegistrationResponse();

            try
            {
                reader = objBooleanDAL.ExecuteDataReader(sqlparams, PROC_USP_RegisterUser, con);

                while (reader.Read())
                {
                    objRegistrationResponse.StatusID = (int)reader["StatusID"];
                    objRegistrationResponse.StatusMessage = (string)reader["StatusMessage"];
                    objRegistrationResponse.RegistrationID = (int)reader["RegistrationID"];
                    objRegistrationResponse.OTP = (string)reader["OTP"];
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
            return objRegistrationResponse;
        }

        public DefaultResponse VerifyRegisteredUser(int registrationId, string otp)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@RegistrationID", SqlDbType.Int) { Value = registrationId },
                                            new SqlParameter("@OTP", SqlDbType.VarChar, 10) { Value = otp }};
            SqlDataReader reader = null;
            DefaultResponse objDefaultResponse = new DefaultResponse();

            try
            {
                reader = objBooleanDAL.ExecuteDataReader(sqlparams, PROC_USP_VerifyRegisteredUserOTP, con);

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
