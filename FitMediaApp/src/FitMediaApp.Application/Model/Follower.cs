using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Model
{
    public class Follower
    {
#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
        protected Follower() { }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.

        public Follower(User follower, User following)
        {
            Follows = follower;
            Following = following;
        }

        public int id { get; set; }
        public Guid guid { get; set; }
        public User Follows { get; set; }
        public User Following { get; set; }
    }
}
