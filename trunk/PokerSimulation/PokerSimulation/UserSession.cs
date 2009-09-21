using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace PokerSimulation
{
    class UserSession
    {
        #region Fields
         private string _subject_id;
         private string _session_id;
         private string _schedule;
         private string _block_id;
         private string _trial_id;
         private float _reaction_time;
         private float _response_time;
        #endregion

        #region Constructors

         public UserSession()
         {
             Subject_id = "";
             Session_id = "";
             Schedule = "";
             Block_id = "";
             Trial_id = "";
         }

         public UserSession(string subject_id, string session_id, string schedule, 
             string block_id, string trial_id)
         {
             Subject_id = subject_id;
             Session_id = session_id;
             Schedule = schedule;
             Block_id = block_id;
             Trial_id = trial_id;
         }

        #endregion

        #region Properties
         public string Subject_id
         {
             get { return _subject_id; }
             set { _subject_id = value; }
         }

         public string Session_id
         {
             get { return _session_id; }
             set { _session_id = value; }
         }

         public string Schedule
         {
             get { return _schedule; }
             set { _schedule = value; }
         }

         public string Block_id
         {
             get { return _block_id; }
             set { _block_id = value; }
         }

         public string Trial_id
         {
             get { return _trial_id; }
             set { _trial_id = value; }
         }

         public float Reaction_time
         {
             get { return _reaction_time; }
             set { _reaction_time = value; }
         }

         public float Response_time
         {
             get { return _response_time; }
             set { _response_time = value; }
         }
         #endregion

        #region Methods

        #endregion


    }
}
