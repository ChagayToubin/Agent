using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agegent.ModelsS
{
    internal class Agent
    {
        public int ID;
        public string codeName { get; set; }

        public string realName { get; set; }

        public string loction { get; set; }

        public string status { get; set; }
        public int missionsCompletad { get; set; }

        public Agent( string codename, string realname, string loctionn, string statuss, int missionsCompletadd)
        {
            codeName = codename;
            realName = realname;
            loction = loctionn;
            status = statuss;
            missionsCompletad = missionsCompletadd;
        }

        public void printinfo()
        {
            Console.WriteLine($"id   {ID}  ,codename  {codeName} ,realname  {realName},loction: {loction},status:{status},missionscompetadd :{missionsCompletad}"  );
        }
    }


}
