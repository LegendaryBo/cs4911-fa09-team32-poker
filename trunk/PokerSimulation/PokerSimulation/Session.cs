using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    public class Session
    {
        #region Properties
         public string Subject_ID { get; internal set; }
         public string Session_ID { get; internal set; }
         public List<Block> Blocks { get; internal set; }
        #endregion

        #region Constructors

         public Session(string file)
         {
             Blocks = new List<Block>();
         }
        #endregion
    }
}
