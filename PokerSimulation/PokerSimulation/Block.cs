using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    /// <summary>
    /// Used to house any number of Trials in a single Session. 
    /// A Block is initialized when the raw input file has a 
    /// valid third column with the string "Yes".
    /// </summary>
    public class Block
    {
        #region Properties
        /// <summary>
        /// An identification number for the Block
        /// </summary>
        public long Block_ID { get; internal set; }

        /// <summary>
        /// A List of Trials contained by the Block
        /// </summary>
        public List<Trial> Trials { get; internal set; }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a Trial to the Block.
        /// </summary>
        /// <param name="t">
        /// The Trial to add.
        /// </param>
        public void AddTrial(Trial t)
        {
             if (t != null) Trials.Add(t);
        }

        /// <summary>
        /// Removes the given Trial from the Block.
        /// </summary>
        /// <param name="t">
        /// The Trial to remove.
        /// </param>
        /// <returns>
        /// True or False depending on if the Trial was removed.
        /// </returns>
        public bool RemoveTrial(Trial t)
        {
            return Trials.Remove(t);
        }

        #region Constructors
        /// <summary>
        /// Constructor for Block class.
        /// </summary>
        /// <param name="id">
        /// An identification number for the Block
        /// </param>
        public Block(long id)
        {
            Block_ID = id;
            Trials = new List<Trial>();
        }
        #endregion
        #endregion
    }
}
