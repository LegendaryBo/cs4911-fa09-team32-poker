using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    public class Block
    {
        #region Properties
        public long Block_ID { get; internal set; }
        public List<Trial> Trials { get; internal set; }
        #endregion

        #region Methods
        public void AddTrial(Trial t)
        {
             if (t != null) Trials.Add(t);
        }

        #region Constructors
        public Block(long id)
        {
            Block_ID = id;
            Trials = new List<Trial>();
        }
        #endregion

        public bool RemoveTrial(Trial t)
        {
             return Trials.Remove(t);
        }
        #endregion
    }
}
