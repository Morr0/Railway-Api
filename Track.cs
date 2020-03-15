using System.Collections.Generic;

namespace rail{
    public class Track {
        public string Name {get; private set;}
        private List<TrackSection> sections = new List<TrackSection>();

        public Track(string name){
            Name = name;
        }

        // public 
    }
}