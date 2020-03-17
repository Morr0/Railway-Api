using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace rail{
    public class Trip{
        public TripType Type {get; private set;}

        public Line Line {get; private set;}

        public Train Train {get; private set;}

        private List<Station> stations = new List<Station>();

        public ReadOnlyCollection<Station> Stations {get{return stations.AsReadOnly();}}

        public Station LastPassedStation {get; private set;}

        public DateTime StartTime {get; private set;}

        public Trip(TripType type, Line line, Train train, Station[] stations, DateTime startTime){
            Type = type;
            Line = line;
            Train = train;
            this.stations.AddRange(stations);
            this.StartTime = startTime;
        }
    }
}