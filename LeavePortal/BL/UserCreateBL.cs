using DMSSWE;
using DMSSWE.DATA;
using LeavePortal.Common;
using LeavePortal.Model;
using System;
using System.Data;
using System.Text;

namespace LeavePortal.BL
{
    internal class UserCreateBL
    {
        public int Add(UserModel _oUserModel)
        {
            try
            {
                int result = 0;
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" IF NOT EXISTS( SELECT * FROM UserAccount WHERE EmpNo=?EmpNo ) ");
                    sb.AppendLine(" BEGIN ");
                    sb.AppendLine(" INSERT INTO UserAccount VALUES(");
                    sb.AppendLine("?EmpNo,");
                    sb.AppendLine("?UserName,");
                    sb.AppendLine("?Password,");
                    sb.AppendLine("?Email,");
                    sb.AppendLine("?UserType,");
                    sb.AppendLine("?ExpiryDate,");
                    sb.AppendLine("?MaximumAttemps,");
                    sb.AppendLine("?Status,");
                    sb.AppendLine("?CreatedDateTime,");
                    sb.AppendLine("?CreatedBy,");
                    sb.AppendLine("?CreatedMachine,");
                    sb.AppendLine("?ModifiedDateTime,");
                    sb.AppendLine("?ModifiedBy,");
                    sb.AppendLine("?ModifiedMachine)");
                    sb.AppendLine(" END ");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = _oUserModel.EmpNo });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "UserName", Value = _oUserModel.UserName });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Password", Value = _oUserModel.Password });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Email", Value = _oUserModel.Email });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "UserType", Value = _oUserModel.UserType });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ExpiryDate", Value = _oUserModel.ExpiryDate });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "MaximumAttemps", Value = _oUserModel.MaximumAttemps });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Status", Value = _oUserModel.Status });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = _oUserModel.CreatedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedBy", Value = _oUserModel.CreatedBy });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedMachine", Value = _oUserModel.CreatedMachine });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = _oUserModel.ModifiedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedBy", Value = _oUserModel.ModifiedBy });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedMachine", Value = _oUserModel.ModifiedMachine });
                    result = oCloudConnection.ExecuteQuery();
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public object Login(string userName, string password, int userType)
        {
            object result = null;

            try
            {
                var _oUser = GetByUserNamePassword(userName, password, userType);
                //var _oUser = GetByUserNamePassword(userName, DMSSWE.CryptoUtil.Encrypt(userName,password), userType);
                if (_oUser == null)
                {
                    return new { result = 0, UserId = 0, UserName = "", msg = "Invalid User." };
                }
                else
                {
                    switch (_oUser.Status)
                    {
                        case (int)UserStatus.NewUser:
                            result = new { result = (int)UserStatus.NewUser, UserId = _oUser.UserID, UserName = _oUser.UserName, msg = "New User." };
                            break;

                        case (int)UserStatus.Active:
                            result = new { result = (int)UserStatus.Active, UserId = _oUser.UserID, UserName = _oUser.UserName, msg = "Active User." };
                            break;

                        case (int)UserStatus.PasswordReset:
                            result = new { result = (int)UserStatus.PasswordReset, UserId = _oUser.UserID, UserName = _oUser.UserName, msg = "Password reset required." };
                            break;

                        case (int)UserStatus.AutoInactive:
                            result = new { result = (int)UserStatus.AutoInactive, UserId = _oUser.UserID, UserName = _oUser.UserName, msg = "Account already auto inactivated." };
                            break;

                        case (int)UserStatus.Inactive:
                            result = new { result = (int)UserStatus.AutoInactive, UserId = _oUser.UserID, UserName = _oUser.UserName, msg = "Account already inactivated." };
                            break;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserModel GetByUserNamePassword(string userName, string Password, int UserType)
        {
            UserModel results = new UserModel();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("SELECT UserID, \n");
                    varname1.Append("       EmpNo, \n");
                    varname1.Append("       UserName, \n");
                    varname1.Append("       Password, \n");
                    varname1.Append("       Email, \n");
                    varname1.Append("       UserType, \n");
                    varname1.Append("       ExpiryDate, \n");
                    varname1.Append("       MaximumAttemps, \n");
                    varname1.Append("       Status, \n");
                    varname1.Append("       CreatedDateTime, \n");
                    varname1.Append("       CreatedBy, \n");
                    varname1.Append("       CreatedMachine, \n");
                    varname1.Append("       ModifiedDateTime, \n");
                    varname1.Append("       ModifiedBy, \n");
                    varname1.Append("       ModifiedMachine \n");
                    varname1.Append("       FROM   UserAccount \n");
                    varname1.Append(" WHERE 1=1 \n ");
                    varname1.Append(" AND (UserName=?UserName) \n");
                    varname1.Append(" AND (Password=?Password) \n");
                    varname1.Append(" AND (UserType=?UserType)");

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "UserName", Value = userName });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Password", Value = Password });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "UserType", Value = UserType });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            UserModel result = new UserModel();
                            result.UserID = Helper.GetDataValue<int>(dr, "UserID");
                            result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                            result.UserName = Helper.GetDataValue<string>(dr, "UserName");
                            result.Password = DMSSWE.CryptoUtil.Decrypt(Helper.GetDataValue<string>(dr, "Password"), result.UserName.Trim());
                            result.UserType = Helper.GetDataValue<int>(dr, "UserType");
                            result.Email = Helper.GetDataValue<string>(dr, "Email");
                            result.ExpiryDate = Helper.GetDataValue<DateTime>(dr, "ExpiryDate");
                            result.MaximumAttemps = Helper.GetDataValue<int>(dr, "MaximumAttemps");
                            result.Status = Helper.GetDataValue<int>(dr, "Status");
                            result.CreatedDateTime = Helper.GetDataValue<DateTime>(dr, "CreatedDateTime");
                            result.CreatedBy = Helper.GetDataValue<string>(dr, "CreatedBy");
                            result.CreatedMachine = Helper.GetDataValue<string>(dr, "CreatedMachine");
                            result.ModifiedDateTime = Helper.GetDataValue<DateTime>(dr, "ModifiedDateTime");
                            result.ModifiedBy = Helper.GetDataValue<string>(dr, "ModifiedBy");
                            result.ModifiedMachine = Helper.GetDataValue<string>(dr, "ModifiedMachine");
                        }
                        dr.Close();
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        private static StringBuilder AllUsers()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("UserID,");
            sb.AppendLine("EmpNo,");
            sb.AppendLine("UserName,");
            sb.AppendLine("Password,");
            sb.AppendLine("Email,");
            sb.AppendLine("UserType ,");
            sb.AppendLine("ExpiryDate,");
            sb.AppendLine("MaximumAttemps,");
            sb.AppendLine("Status,");
            sb.AppendLine("Status,");
            sb.AppendLine("CreatedDateTime,");
            sb.AppendLine("CreatedBy,");
            sb.AppendLine("CreatedMachine,");
            sb.AppendLine("ModifiedDateTime,");
            sb.AppendLine("ModifiedBy,");
            sb.AppendLine("ModifiedMachine");
            sb.AppendLine(" FROM UserAccount ");
            sb.AppendLine(" WHERE 1=1 ");
            return sb;
        }

        public UserModel GetByUserType(string userName)
        {
            UserModel result = new UserModel();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = AllUsers();
                    sb.AppendLine(" AND (UserName=?UserName)");
                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "UserName", Value = userName });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.UserName = Helper.GetDataValue<string>(dr, "UserName");
                            result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                            result.Password = Helper.GetDataValue<string>(dr, "Password");
                            result.UserType = Helper.GetDataValue<int>(dr, "UserType");
                        }
                        dr.Close();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }
    }
}