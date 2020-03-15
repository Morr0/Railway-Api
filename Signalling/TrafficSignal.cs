namespace rail {
    public class TrafficSignal {
        public string Name {get; private set;}

        public bool ManuallyControlled {get; internal set;}

        public TrafficIndicator Indicator {get; internal set;}

        public TrafficSignal(string name){
            Name = name;
        }

    }
}