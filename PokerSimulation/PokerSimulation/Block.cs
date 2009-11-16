using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    public class Block
    {
        #region Properties
         public string Block_ID { get; internal set; }
         public List<Trial> Trials { get; internal set; }
        #endregion

        #region Methods
         public void AddTrial(Trial t)
         {
             if (t != null) Trials.Add(t);
         }

         public bool RemoveTrial(Trial t)
         {
             return Trials.Remove(t);
         }
        #endregion
    }
}
