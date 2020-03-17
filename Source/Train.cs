using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace rail
{
    public class Train{
        public string Name {get; private set;}

        /// <summary>
        /// Whether this train is moving from back -> forward sections.
        /// </summary>
        /// <value></value>
        public bool ForwardBiased {get; internal set;} = true;

        public bool Parked {get; set;}

        private List<Carriage> carriages = new List<Carriage>();

        public int Length {get {return carriages.Count;}}

        public ReadOnlyCollection<Carriage> Carriages {get {return carriages.AsReadOnly();}}

        public Train(string name, Carriage headCarriage, Carriage[] carriages = null){
            Name = name;

            this.carriages.Add(headCarriage);
            if (carriages != null)
                this.carriages.AddRange(carriages);
        }

        public void AddCarriage(Carriage carriage){
            this.carriages.Add(carriage);
        }

        /// <summary>
        /// Swaps driver ends
        /// </summary>
        public void SwitchEnds(){
            this.carriages.Reverse();
            this.ForwardBiased = !ForwardBiased;
        }
    }
}
