using CoreApiWithAdoNet.Model;
using CoreApiWithAdoNet.Utility;
using System.Collections.Generic;
using CoreApiWithAdoNet.Convertors;
using System.Data.SqlClient;
using System.Data;

namespace CoreApiWithAdoNet.Repository
{
    public class DbClient
    {
        public List<Team> GetAllTeam(string connectionString)
        {
            return SqlHelper.ExtecuteProcedure(connectionString, "GetTeam", c => c.ConvertToTeamList());
        }

        public string SaveTeam(Team model, string connectionString)
        {
            var outputParameter = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@Name",model.Name),
                new SqlParameter("@Country",model.Country),
                new SqlParameter("@EmailId",model.Email),
                new SqlParameter("@Phone",model.Phone),
                new SqlParameter("@WillPlayInCL",model.WillPlayInChanpionsLeague),
                outputParameter
            };

            SqlHelper.ExecuteProcedure(connectionString, "SaveTeam", param);
            return (string)outputParameter.Value;
        }

        public string DeleteUser(int id, string connectionString)
        {
            var outputParameter = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            var param = new SqlParameter[] {
                new SqlParameter("@Id",id),
                outputParameter
            };

            SqlHelper.ExecuteProcedure(connectionString, "DeleteTeam", param);
            return (string)outputParameter.Value;
        }
    }
}
