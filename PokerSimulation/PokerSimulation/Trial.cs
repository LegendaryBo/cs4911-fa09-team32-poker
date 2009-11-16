using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    public class Trial
    {
        #region Properties
         public string Trial_ID { get; internal set; }
         public string Response { get; internal set; }
         public Hand Hand { get; internal set; }
         public int Number_of_cards { get; internal set; }
         public bool Correct { get; internal set; }
         public string Nuts { get; internal set; }
         public bool Valid { get; internal set; }
         public long Reaction_Time { get; internal set; }
         public long Response_Time { get; internal set; }
         public long Feedback_Time { get; internal set; }
        #endregion

        #region Constructors

         public Trial(string id, Hand hand, int num_of_cards, string nuts)
         {
             Trial_ID = id;
             Hand = hand;
             Number_of_cards = num_of_cards;
             Nuts = nuts;
         }
        #endregion
    }
}
