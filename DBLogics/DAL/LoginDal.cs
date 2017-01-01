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
    public class LoginDal
    {
        #region Members

        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);
        BooleanDAL objBooleanDAL = new BooleanDAL();

        #endregion

        #region Procedures

        private static string PROC_USP_CitizenLogin = "USP_CitizenLogin";//Karteek
        private static string PROC_USP_VerifyCitizenLoginOTP = "USP_VerifyCitizenLoginOTP";//Karteek
        private static string PROC_USP_DepartmentUserLogin = "USP_DepartmentUserLogin";//Karteek
        private static string PROC_USP_VerifyDepartmentUserLoginOTP = "USP_VerifyDepartmentUserLoginOTP";//Karteek
        private static string PROC_USP_WebsiteUserLogin = "USP_WebsiteUserLogin";//Karteek
        
        #endregion

        #region Methods

        public RegistrationResponse CitizenLogin(string mobileNumber)
        {
            SqlParameter[] sqlparams = { 
                                            new SqlParameter("@MobileNumber", SqlDbType.VarChar, 20) { Value = mobileNumber }
                                            };
            SqlDataReader reader = null;
            RegistrationResponse objRegistrationResponse = new RegistrationResponse();

            try
            {
                reader = objBooleanDAL.ExecuteDataReader(sqlparams, PROC_USP_CitizenLogin, con);

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

        public CitizenLoginResponse VerifyCitizenLoginOTP(int registrationId, string otp)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@RegistrationID", SqlDbType.Int) { Value = registrationId },
                                            new SqlParameter("@OTP", SqlDbType.VarChar, 10) { Value = otp }};
            SqlDataReader reader = null;
            CitizenLoginResponse objCitizenLoginResponse = new CitizenLoginResponse();

            try
            {
                reader = objBooleanDAL.ExecuteDataReader(sqlparams, PROC_USP_VerifyCitizenLoginOTP, con);

                while (reader.Read())
                {
                    objCitizenLoginResponse.StatusID = (int)reader["StatusID"];
                    objCitizenLoginResponse.StatusMessage = (string)reader["StatusMessage"];
                    objCitizenLoginResponse.RegistrationID = (int)reader["RegistrationID"];
                    objCitizenLoginResponse.Name = (string)reader["Name"];
                    objCitizenLoginResponse.LoginID = (long)reader["LoginID"];
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
            return objCitizenLoginResponse;
        }

        public DepartmentLoginResponse DepartmentUserLogin(string mobileNumber, string imei)
        {
            SqlParameter[] sqlparams = { 
                                            new SqlParameter("@MobileNumber", SqlDbType.VarChar, 20) { Value = mobileNumber },
                                            new SqlParameter("@IMEI", SqlDbType.VarChar, 20) { Value = imei }
                                            };
            SqlDataReader reader = null;
            DepartmentLoginResponse objDepartmentLoginResponse = new DepartmentLoginResponse();

            try
            {
                reader = objBooleanDAL.ExecuteDataReader(sqlparams, PROC_USP_DepartmentUserLogin, con);

                while (reader.Read())
                {
                    objDepartmentLoginResponse.StatusID = (int)reader["StatusID"];
                    objDepartmentLoginResponse.StatusMessage = (string)reader["StatusMessage"];
                    objDepartmentLoginResponse.UserID = (int)reader["UserID"];
                    objDepartmentLoginResponse.OTP = (string)reader["OTP"];
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
            return objDepartmentLoginResponse;
        }

        public DepartmentLoginDetailsResponse VerifyDepartmentUserLoginOTP(int userId, string otp)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserID", SqlDbType.Int) { Value = userId },
                                            new SqlParameter("@OTP", SqlDbType.VarChar, 10) { Value = otp }};
            SqlDataReader reader = null;
            DepartmentLoginDetailsResponse objDepartmentLoginDetailsResponse = new DepartmentLoginDetailsResponse();

            try
            {
                reader = objBooleanDAL.ExecuteDataReader(sqlparams, PROC_USP_VerifyDepartmentUserLoginOTP, con);

                while (reader.Read())
                {
                    objDepartmentLoginDetailsResponse.StatusID = (int)reader["StatusID"];
                    objDepartmentLoginDetailsResponse.StatusMessage = (string)reader["StatusMessage"];
                    objDepartmentLoginDetailsResponse.UserID = (int)reader["UserID"];
                    objDepartmentLoginDetailsResponse.Name = (string)reader["Name"];
                    objDepartmentLoginDetailsResponse.Masters = (string)reader["Masters"];
                    objDepartmentLoginDetailsResponse.LoginID = (long)reader["LoginID"];
                    objDepartmentLoginDetailsResponse.LastTripDate = (string)reader["LastTripDate"];
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
            return objDepartmentLoginDetailsResponse;
        }

        public DepartmentLoginDetailsResponse WebsiteUserLogin(string username, string password)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@Username", SqlDbType.VarChar, 50) { Value = username },
                                            new SqlParameter("@Password", SqlDbType.VarChar, 250) { Value = password }};
            SqlDataReader reader = null;
            DepartmentLoginDetailsResponse objDepartmentLoginDetailsResponse = new DepartmentLoginDetailsResponse();

            try
            {
                reader = objBooleanDAL.ExecuteDataReader(sqlparams, PROC_USP_WebsiteUserLogin, con);

                while (reader.Read())
                {
                    objDepartmentLoginDetailsResponse.StatusID = (int)reader["StatusID"];
                    objDepartmentLoginDetailsResponse.StatusMessage = (string)reader["StatusMessage"];
                    objDepartmentLoginDetailsResponse.UserID = (int)reader["UserID"];
                    objDepartmentLoginDetailsResponse.Name = (string)reader["Name"];
                    objDepartmentLoginDetailsResponse.Masters = (string)reader["Masters"];
                    objDepartmentLoginDetailsResponse.LoginID = (long)reader["LoginID"];
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
            return objDepartmentLoginDetailsResponse;
        }

        #endregion
    }
}
