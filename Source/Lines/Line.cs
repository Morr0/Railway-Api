using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace rail{
    /// <summary>
    /// Represents a train line. A line can have shared TrackSections and structues.
    /// </summary>
    public class Line {
        public string Name {get; private set;}

        private List<TrackSection> leftLane = new List<TrackSection>();
        private List<TrackSection> rightLane = new List<TrackSection>();

        private List<Station> stations = new List<Station>();

        public ReadOnlyCollection<TrackSection> LeftLane {get {return leftLane.AsReadOnly();}}
        public ReadOnlyCollection<TrackSection> RightLane {get {return rightLane.AsReadOnly();}}
        public ReadOnlyCollection<Station> Stations {get {return stations.AsReadOnly();}}

        public Line(string name){
            Name = name;
        }

        public void AddStationToTheEnd(Station station){
            stations.Add(station);
        }
    }
}