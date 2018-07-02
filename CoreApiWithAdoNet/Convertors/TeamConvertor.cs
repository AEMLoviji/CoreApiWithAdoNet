using CoreApiWithAdoNet.Model;
using CoreApiWithAdoNet.Utility;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CoreApiWithAdoNet.Convertors
{
    public static class TeamConvertor
    {
        public static Team ConvertToTeam(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Team();
            if (reader.IsColumnExist("Id"))
                item.Id = SqlHelper.GetInt(reader, "Id");

            if (reader.IsColumnExist("Name"))
                item.Name = SqlHelper.GetInt(reader, "Name");

            if (reader.IsColumnExist("Country"))
                item.Country = SqlHelper.GetInt(reader, "Country");

            if (reader.IsColumnExist("Email"))
                item.Email = SqlHelper.GetInt(reader, "Email");

            if (reader.IsColumnExist("Phone"))
                item.Phone = SqlHelper.GetInt(reader, "Phone");

            if (reader.IsColumnExist("WillPlayInCP"))
                item.WillPlayInChanpionsLeague = SqlHelper.GetBoolean(reader, "WillPlayInCP");

            return item;
        }

        public static List<Team> ConvertToTeamList(this SqlDataReader reader)
        {
            var list = new List<Team>();
            while (reader.Read())
            {
                list.Add(ConvertToTeam(reader, true));
            }
            return list;
        }

    }
}
