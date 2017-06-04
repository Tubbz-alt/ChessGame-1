using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Library
{
    /// <summary>
    /// All status of ChessGame
    /// </summary>
    public class GameStatus
    {
        private eGameStatus status;
        private eGameEndReason reason;

        public eGameStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public eGameEndReason Reason
        {
            get
            {
                return reason;
            }

            set
            {
                reason = value;
            }
        }

        public GameStatus(eGameStatus status, eGameEndReason reason)
        {
            this.Status = status;
            this.Reason = reason;
        }
    }
}
