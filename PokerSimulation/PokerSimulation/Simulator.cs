using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    interface Simulator
    {
        void ShowFeedback();
        void ShowFixation();
        void ShowTrial();
        void ShowReady();
        void ShowNewSession();
        void ShowError();
        void ShowOpenSession();
        void ShowMessage(String message);
    }
}
