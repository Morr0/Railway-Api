namespace rail {
    public enum TrafficIndicator : byte {
        // Clear to proceed
        CLEAR,
        // Prepare to slow down but still to proceed slowly
        SLOW_CLEAR,
        // Drive really slow to stop
        PREPARE_TO_STOP,
        // Complete stop
        STOP
    }
}