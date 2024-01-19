using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._HashTable
{
    public class CheatKey
    {
        private Dictionary<string, Action> cheatDic;

         public CheatKey()
         {  
            cheatDic = new Dictionary<string, Action>();

            cheatDic.Add("Money", ShowMeTheMoney);
            cheatDic.Add("Win", ThereIsNoCowLevel);
         }
        public void Run( string cheatKey )
        {
            cheatDic.TryGetValue(cheatKey, out Action action);
            action?.Invoke();
            //if (CheatDic.ContainsKey(cheat))
            //{
            //      cheatDic[cheat]();
            //}
        }

        public void ShowMeTheMoney()
        {
             Console.WriteLine("골드를 늘려주는 치트키 발동 ! ");
        }
        public void ThereIsNoCowLevel()
        {
             Console.WriteLine("바로 승리합니다 치트키 발동 ! ");
        }

        static void Main()
        {
            CheatKey cheatKey = new CheatKey();
            
            string input = Console.ReadLine();
            cheatKey.Run(input);
        }

    }
}
