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

        /// <summary>
        /// How much of the train's length is inside this section. The length is dependent
        /// on if the train is forward biased or not.
        /// </summary>
        /// <value></value>
        public int TrainLengthInSection {get; private set;}

        public Crossing Type {get; private set;}

        /// <summary>
        /// Applies only if not a STRAIGHT crossing.
        /// If True, merges right.
        /// </summary>
        /// <value></value>
        public bool PointsRight {get; set;}

        public TrackSection SectionOnFront {get; internal set;}
        public TrackSection SectionOnBack {get; internal set;}
        /// <summary>
        /// Useable only when the crossing is to the right
        /// </summary>
        /// <value></value>
        public TrackSection SectionOnRight {get; internal set;}
        /// <summary>
        /// Useable only when the crossing is to the left
        /// </summary>
        /// <value></value>
        public TrackSection SectionOnLeft {get; internal set;}

        public TrackSection(string name, string trafficSignalName, Crossing type,
         int length, TrackSection front = null, TrackSection back = null,
         TrackSection right = null, TrackSection left = null){
            Name = name;
            Signal = new TrafficSignal(trafficSignalName);
            Type = type;

            SectionOnFront = front;
            SectionOnBack = back;
            SectionOnRight = right;
            SectionOnLeft = left;
        }

        // TODO eliminate direct access and allow trips to modify the train
        public void PlaceTrain(Train train) => CurrentTrain = train;

        // Next track in terms of bias of train and track
        public TrackSection NextSection(){
            TrackSection nextSection = null;
            if (CurrentTrain.ForwardBiased){
                if (Type == Crossing.STRAIGHT)
                    nextSection = SectionOnFront;
                else
                    nextSection = PointsRight? SectionOnRight: SectionOnLeft;

            } else
                nextSection = SectionOnBack;

            return nextSection;
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

        public enum TrainMovementResult : byte {
            FINE_FULLY_INSIDE,
            FINE_PARTIALLY_INSIDE,
            FINE_FULLY_OFF_TRACK,
            SHARES_TRACK_SECTION_WITH_ANOTHER_TRAIN,
            OFF_TRACK
        }

        // Train movement
        /// <summary>
        /// Moves the train one carriage length at a time.
        /// </summary>
        /// <returns></returns>
        public TrainMovementResult MoveTrain(){
            if (TrainLengthInSection > 0){
                
                // If the entire train is inside this section
                if (CurrentTrain.Length == TrainLengthInSection){
                    // To ease huge if statements
                    TrackSection nextSection = null;
                    if (CurrentTrain.ForwardBiased){
                        if (Type == Crossing.STRAIGHT)
                            nextSection = SectionOnFront;
                        else
                            nextSection = PointsRight? SectionOnRight: SectionOnLeft;

                    } else
                        nextSection = SectionOnBack;
                    //

                    // Checks for off-track
                    if (nextSection == null){
                        TrainLengthInSection--;
                        return TrainMovementResult.OFF_TRACK;
                    }

                    if (nextSection != null){
                        if (nextSection.CurrentTrain != null){
                            // TODO do something when there is another train in the section
                            TrainLengthInSection--;
                            return TrainMovementResult.SHARES_TRACK_SECTION_WITH_ANOTHER_TRAIN;
                        }
                    }
                }

                // If not the entire train inside this section
                else {

                    return TrainMovementResult.FINE_PARTIALLY_INSIDE;
                }

                TrainLengthInSection--;

                if (TrainLengthInSection == 0){
                    CurrentTrain = null;
                    return TrainMovementResult.FINE_FULLY_OFF_TRACK;
                }
            }

            return TrainMovementResult.FINE_FULLY_INSIDE;
        }
    }
}