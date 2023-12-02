using System.Data;
using static Dapper.SqlMapper;
using System.Data.SqlClient;
using Dapper;
using Electronic_Store_Api.Common;
using Electronic_Store_Api.Entities;
using Electronic_Store_Api.DataModels;
using Electronic_Store_Api.ViewModels;
using AutoMapper;

namespace Electronic_Store_Api.Services
{
    public class LoginService: ILoginService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public LoginService(IConfiguration config, AutoMapper.IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public IDbConnection Connection 
        { 
            get
            {
                return new SqlConnection(_config.GetConnectionString(ConstantProp.dataBaseName));
            }
        }

        public User EsUsersLogin(Login login, out int status, out string message)
        {
            string inputParam = TraceLog.appendSingleObject(login);
            TraceLog.LogActivity(ConstantProp.serviceIn, 0, "", null, "Login Intiated", inputParam);
            var user = new User();
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    var esLogin = _mapper.Map<LoginDM>(login);
                    DynamicParameters parameters = new DynamicParameters(esLogin);
  
                    parameters.Add(ConstantProp.statusDbParam, 0, DbType.Int16, direction: ParameterDirection.Output, size: 1);
                    parameters.Add(ConstantProp.errMsgDbParam, null,DbType.String, direction: ParameterDirection.Output, size: 5000);

                    user = con.Query<User>(SpConstants.esUserLogin, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    status = parameters.Get<Int16>(ConstantProp.status);
                    message = parameters.Get<string>(ConstantProp.errMsg);
                    if (status != 2)
                    {
                        user = null;
                    }
                }
            }
            catch (Exception ex)
            {
                TraceLog.LogError(Convert.ToString(0), "", "Login Intiated", ex, inputParam);
                user = null;
                status = -1;
                message = ex.Message;
            }
            return user;
        }

    }
}
