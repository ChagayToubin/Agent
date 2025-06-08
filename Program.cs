using agegent.DAL;
using agegent.DB;
using agegent.ModelsS;

namespace agegent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Agent agent = new Agent
            (

                 "9090",
              "chagay toubin",
                "רב עקיבא",
                "Active",
                18
            );

            AgentDAL dal = new AgentDAL();

            dal.Addnewagent(agent);

            print(dal.GetAllAgents());

            dal.UpdateAgentLocation(47, "מצדה 6");
            print(dal.GetAllAgents());

            dal.DeleteAgent(46);
            print(dal.GetAllAgents());//צריל לחכות בשביל לראות את ההעדכון של המחיקה לא מראה מיד 

            //bonos 1

            //bonos 2
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic = dal.CountAgentsByStatus();
            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + "      " + item.Value);
            }








        }
        static void print(List<Agent> b)
        {
            foreach (var item in b)
            {
                Console.WriteLine("\n");
                item.printinfo();
            }

        }
    }

}
