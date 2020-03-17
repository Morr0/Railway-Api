namespace rail.util {
    public class Utils {
        /// <summary>
        /// Makes a track of equal lengths outside a station/yard.
        /// </summary>
        /// <returns></returns>
        public static TrackSection[] MakeTrack(int trackLength, int noTracks, 
        string startingSectionName, string startingSignalName){
            TrackSection[] sections = new TrackSection[noTracks];

            string tempSectionName, tempSignalName;
            TrackSection tempObjBefore = null, tempObj;


            for (int i = 0; i < noTracks; i++){
                tempSectionName = $"{startingSectionName + i}";
                tempSignalName = $"{startingSignalName + i}";

                tempObj = new TrackSection(startingSectionName, startingSignalName,
                TrackSection.Crossing.STRAIGHT, trackLength, null, tempObjBefore);
                tempObjBefore = tempObj; 

                // Updates the section before to have a reference to this 
                // current section as the one in the front
                if (i >= 1){
                    sections[i - 1].SectionOnFront = tempObj;
                }

                sections[i] = tempObj;
            }

            return sections;
        }
    }
}