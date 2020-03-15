using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace rail {
    public class Station {
        public string Name {get; private set;}

        private List<TrackSection> platforms = new List<TrackSection>();
        public ReadOnlyCollection<TrackSection> Platforms {get {return platforms.AsReadOnly();}}

        public Station(string name, TrackSection[] platforms){
            Name = name;
            this.platforms.AddRange(platforms);
        }

        public bool CanEnterTrain(int platform){
            return platforms[platform].CurrentTrain == null;
        }

        public bool CanStopHere(int platform, Train train){
            return platforms[platform].Length >= train.Carriages.Count;
        }

        public void StopHere(int platform, Train train){
            platforms[platform].CurrentTrain = train;
        }

        /// <summary>
        /// When a train leaves a platform
        /// </summary>
        /// <param name="platform"></param>
        public void EmptyPlatform(int platform){
            platforms[platform].CurrentTrain = null;
        }
    }
}