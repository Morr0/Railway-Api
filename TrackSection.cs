namespace rail {
    public class TrackSection{
        public Train CurrentTrain {get; set;}

        public Crossing Type {get; private set;}

        /// <summary>
        /// Applies only if not a STRAIGHT crossing.
        /// If True, merges right.
        /// </summary>
        /// <value></value>
        public bool PointsRight {get; set;}

        public TrackSection(Crossing type){
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