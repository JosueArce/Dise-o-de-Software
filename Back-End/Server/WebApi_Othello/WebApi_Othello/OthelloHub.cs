using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApi_Othello
{
    public class OthelloHub : Hub
    {
        public static int _hitCounter = 0;

        public void RecordHit()
        {
            _hitCounter += 1;
            this.Clients.All.onHitRecorded(_hitCounter);
        }
    }
}