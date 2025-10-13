using System.Runtime.Serialization;

namespace DBdriver
{
    [DataContract]
    public class Roster
    {
        [DataMember]
        public string Playerid { get; set; }
        [DataMember]
        public int Jersey { get; set; }
        [DataMember]
        public string Fname { get; set; }
        [DataMember]
        public string Sname { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember]
        public string Birthday { get; set; }
        [DataMember]
        public int Weight { get; set; }
        [DataMember]
        public int Height { get; set; }
        [DataMember]
        public string Birthcity { get; set; }
        [DataMember]
        public string Birthstate { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Roster);
        }

        public bool Equals(Roster other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return Jersey == other.Jersey &&
                   Weight == other.Weight &&
                   Height == other.Height &&
                   string.Equals(Playerid, other.Playerid) &&
                   string.Equals(Fname, other.Fname) &&
                   string.Equals(Sname, other.Sname) &&
                   string.Equals(Position, other.Position) &&
                   string.Equals(Birthday, other.Birthday) &&
                   string.Equals(Birthcity, other.Birthcity) &&
                   string.Equals(Birthstate, other.Birthstate);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Playerid?.GetHashCode() ?? 0);
                hash = hash * 23 + Jersey.GetHashCode();
                hash = hash * 23 + (Fname?.GetHashCode() ?? 0);
                hash = hash * 23 + (Sname?.GetHashCode() ?? 0);
                hash = hash * 23 + (Position?.GetHashCode() ?? 0);
                hash = hash * 23 + (Birthday?.GetHashCode() ?? 0);
                hash = hash * 23 + Weight.GetHashCode();
                hash = hash * 23 + Height.GetHashCode();
                hash = hash * 23 + (Birthcity?.GetHashCode() ?? 0);
                hash = hash * 23 + (Birthstate?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public override string ToString()
        {
            return $"Roster {{ Playerid = {Playerid}, Jersey = {Jersey}, Fname = {Fname}, Sname = {Sname}, Position = {Position}, Birthday = {Birthday}, Weight = {Weight}, Height = {Height}, Birthcity = {Birthcity}, Birthstate = {Birthstate} }}";
        }

        public static bool operator ==(Roster left, Roster right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Roster left, Roster right)
        {
            return !Equals(left, right);
        }
    }
}