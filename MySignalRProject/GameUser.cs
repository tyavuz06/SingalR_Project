using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MySignalRProject
{
    public class GameUser
    {
        public string userID { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Color { get; set; }

        public static Dictionary<GameUser, string> _connections = new Dictionary<GameUser, string>();

        public static void addConnection(GameUser user,string connectionID)
        {
            if (_connections.Where(t => t.Key.userID == user.userID).FirstOrDefault().Key == null)
            {
                _connections.Add(user, connectionID);
            }
        }

        public static void removeConnection(string connectionID)
        {
            if (_connections.Where(t => t.Value == connectionID).FirstOrDefault().Key != null)
            {
                GameUser _user = _connections.FirstOrDefault(t => t.Value== connectionID).Key;
                _connections.Remove(_user);
            }
        }
    }
}