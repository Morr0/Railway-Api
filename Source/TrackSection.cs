namespace rail {
    public class TrackSection{
        public string Name {get; private set;}
        public Train CurrentTrain {get; internal set;}

        public TrafficSignal Signal {get; private set;}

        /// <summary>
        /// 1 length = 1 carriage length
        /// </summary>
        /// <value></value>
        public int Length {get; private set;}

        public Crossing Type {get; private set;}

        /// <summary>
        /// Applies only if not a STRAIGHT crossing.
        /// If True, merges right.
        /// </summary>
        /// <value></value>
        public bool PointsRight {get; set;}

        public TrackSection SectionInFront {get; private set;}
        public TrackSection SectionInBack {get; private set;}

        public TrackSection(string name, string trafficSignalName, Crossing type, TrackSection front = null, TrackSection back = null){
            Name = name;
            Signal = new TrafficSignal(trafficSignalName);
            Type = type;
        }

        // Enum of track section types
        public enum Crossing : byte {
            // Straight section
            STRAIGHT,
            // Right crossing
            RIGHT_MERGE,
            // Left crossing
            LEFT_MERGE
        }
    }
}