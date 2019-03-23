using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MySignalRProject
{
    public class mygame : Hub
    {
        public override Task OnConnected()
        {
            string userID = HttpContext.Current.Request.Cookies["user"].Value;

            GameUser user = new GameUser
            {
                userID = userID,
                Height = new Random().Next(25, 50),
                Width = new Random().Next(100, 200),
                PositionX = new Random().Next(5, 1300),
                PositionY = new Random().Next(5, 760),
                Color = new Random().Next(100, 999)
            };
            GameUser.addConnection(user, Context.ConnectionId);
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            string connectionID = Context.ConnectionId;
            /* string userID = HttpContext.Current.Request.Cookies["user"].Value;
             GameUser user = GameUser._connections.Keys.Where(t => t.userID == userID).FirstOrDefault();
             GameUser._connections.Remove(user);*/
            GameUser.removeConnection(connectionID);
            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
        public void sendGamer()
        {
            string userID = HttpContext.Current.Request.Cookies["user"].Value;
            List<GameUser> gamers = GameUser._connections.Keys.ToList();
            Clients.All.getgamer(gamers, userID);
        }

        public void sendUpButton()
        {
            string userID = HttpContext.Current.Request.Cookies["user"].Value;
            GameUser user = GameUser._connections.Keys.Where(t => t.userID == userID).FirstOrDefault();
            if (user.PositionY < 760 && user.PositionY >= 10)
            {
                user.PositionY += user.Height / 3 * -1;
            }
            else
                user.PositionY = 10;
            
            List<GameUser> gamers = GameUser._connections.Keys.Where(t => t.userID != userID).ToList();
            gamers.Add(user);
            Clients.All.getgamer(gamers, userID);
        }
        public void sendRightButton()
        {
            string userID = HttpContext.Current.Request.Cookies["user"].Value;
            GameUser user = GameUser._connections.Keys.Where(t => t.userID == userID).FirstOrDefault();
            if (user.PositionX < 1300 && user.PositionX >= 10)
            {
                user.PositionX += user.Width / 10;
            }
            else
                user.PositionX = 10;
            List<GameUser> gamers = GameUser._connections.Keys.Where(t => t.userID != userID).ToList();
            gamers.Add(user);
            Clients.All.getgamer(gamers, userID);
        }

        public void sendLeftButton()
        {
            string userID = HttpContext.Current.Request.Cookies["user"].Value;
            GameUser user = GameUser._connections.Keys.Where(t => t.userID == userID).FirstOrDefault();
            if (user.PositionX < 1300 && user.PositionX >= 10)
            {
                user.PositionX += user.Width / 10 * -1;
            }
            else
                user.PositionX = 10;
            List<GameUser> gamers = GameUser._connections.Keys.Where(t => t.userID != userID).ToList();
            gamers.Add(user);
            Clients.All.getgamer(gamers, userID);
        }

        public void sendDownButton()
        {
            string userID = HttpContext.Current.Request.Cookies["user"].Value;
            GameUser user = GameUser._connections.Keys.Where(t => t.userID == userID).FirstOrDefault();
            if (user.PositionY < 760 && user.PositionY >= 10)
            {
                user.PositionY += user.Height / 3;
            }
            else
                user.PositionY = 10;
            List<GameUser> gamers = GameUser._connections.Keys.Where(t => t.userID != userID).ToList();
            gamers.Add(user);
            Clients.All.getgamer(gamers, userID);
        }
    }
}