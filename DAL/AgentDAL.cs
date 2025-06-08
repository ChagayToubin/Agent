using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agegent.ModelsS;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace agegent.DAL
{
    internal class AgentDAL
    {


        private string connStr = "Server=localhost;Database=eagleEyeDB;User=root;Password=;Port=3306;";
        private MySqlConnection _conn;
        public MySqlConnection openConnection()
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connStr);
            }

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
                Console.WriteLine("Connection successful");
            }

            return _conn;
        }
        public void Addnewagent(Agent agent)
        {
            var conn = openConnection();

            string query = $" INSERT INTO agents (codeName, realName, location, status, missionsCompleted)" +
        $"VALUES('{agent.codeName}','{agent.realName}','{agent.loction}', '{agent.status}', '{agent.missionsCompletad}')";


            new MySqlCommand(query, conn).ExecuteReader();
            conn.Close();

        }
        public List<Agent> GetAllAgents()
        {
            _conn.Open();
            List<Agent> list = new List<Agent>();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                cmd = new MySqlCommand("SELECT * FROM agents", _conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    string codename = reader.GetString("codeName");
                    string realName = reader.GetString("realName");
                    string loction = reader.GetString("location");
                    string status = reader.GetString("status");
                    int missionsCompleted = reader.GetInt32("missionsCompleted");
                    Agent a = new Agent(codename, realName, loction, status, missionsCompleted);
                    a.ID = reader.GetInt32("id");
                    list.Add(a);


                }
                _conn.Close();

                return list;

            }
            catch
            {
                Console.WriteLine("!@#$%^&*(*&^%$#@");
                throw;
            }



        }

        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            _conn.Open();
            var quary = $"UPDATE agents SET location ='{newLocation}' where id ={agentId}";
            try
            {
                new MySqlCommand(quary, _conn).ExecuteReader();
            }
            catch
            {
                Console.WriteLine("in update stack");
                throw;
            }
            _conn.Close();



        }
        public void DeleteAgent(int agentId)
        {
            _conn.Open();
            string quary = $"DELETE FROM agents WHERE agents.id= {agentId}";
            new MySqlCommand(quary, _conn).ExecuteReader();
            _conn.Close();
        }

        //bonossssssss
        public Dictionary<string, int> CountAgentsByStatus()
        {
           
            Dictionary<string, int> dic = new Dictionary<string, int>();
            List<Agent> list = new List<Agent>();
            list = GetAllAgents();
            foreach (var item in list)
            {
                string key = item.status;
                if (dic.ContainsKey(key))
                {
                    dic[key] += 1;

                }
                else
                {
                    dic[key] = 1;
                }

            }
            return dic;
        }



    }
}
