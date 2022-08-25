using KSP.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using KSP.UI.Screens;
using UnityEngine;
using ToolbarControl_NS;
using ClickThroughFix;

namespace Targetron
{
    class Target
    {
        public Vessel vessel;
        public List<ModuleDockingNode> availableDocks;
        public uint defaultDock = 0;
        public float lastDistance = 0;
        public String lastVName = null;
        public VesselType lastVType = new VesselType();
        public String queuedVName = null;
        public VesselType queuedVType = new VesselType();

        public Target(Vessel vessel, List<ModuleDockingNode> availableDocks, uint defaultDock)
        {
            this.vessel = vessel;
            if (availableDocks == null)
                this.availableDocks = new List<ModuleDockingNode>();
            else
                this.availableDocks = availableDocks;
            this.defaultDock = defaultDock;
            update();
        }
        public void update()
        {
            /*if (lastVName != null && this.vessel.GetName().Length != 0 && !this.vessel.GetName().Equals(this.lastVName) || !this.vessel.vesselType.Equals(this.lastVType))
                Debug.Log("TARGETRON: RENAME DETECTED ON VESSEL " + this.lastVName + "-" + this.lastVType + " -> " + this.vessel.GetName() + "-" + this.vessel.vesselType);*/
            lastVName = vessel.GetName();
            lastVType = vessel.vesselType;
            try
            {
                lastDistance = Vector3.Distance(FlightGlobals.fetch.activeVessel.transform.position, vessel.transform.position);
            }
            catch (Exception e)
            {
                Debug.Log("Targetron Error: Failed to get distance\n" + e.StackTrace);
            }
        }
    }
}
