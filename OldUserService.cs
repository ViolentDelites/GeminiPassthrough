using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Web;
using clwater_new.Models;
using NLog;

namespace clwater_new.Services
{
    public class UserService : ServiceBase
    {
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public LoginUser LoginUser(string cacLoginName)
        {
            logger.Debug($"Cac LoginName: {cacLoginName}");
            LoginUser loginUser = new LoginUser();
            try
            {

                OleDbCommand oleDbCommand = new OleDbCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spCheckCACLoginName"
                };

                oleDbCommand.Parameters.AddWithValue("@p_login_nm", cacLoginName);
                DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    logger.Debug($"Dataset empty.");
                    return loginUser;
                }

                loginUser = new LoginUser
                {
                    FirstName = dataSet.Tables[0].Rows[0]["first_nm"].ToString(),
                    LastName = dataSet.Tables[0].Rows[0]["last_nm"].ToString(),
                    UserId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["user_id"]),
                    IsAdmin = Convert.ToInt32(dataSet.Tables[0].Rows[0]["is_admin"]),
                    IsVaUser = Convert.ToInt32(dataSet.Tables[0].Rows[0]["is_va_user"])
                };
                HttpContext.Current.Session.Add("Name", loginUser.LastName + ", " + loginUser.FirstName);
                HttpContext.Current.Session.Add("UserId", loginUser.UserId.ToString(CultureInfo.InvariantCulture));
                HttpContext.Current.Session.Add("isAdmin", loginUser.IsAdmin.ToString(CultureInfo.InvariantCulture));
                HttpContext.Current.Session.Add("isVAUser", loginUser.IsVaUser.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                logger.Debug($"Error in User Service: {ex}");
                throw new Exception("Check Login CAC Name Failed");
            }
            return loginUser;
        }
    }
}