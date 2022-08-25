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
    class Filter
    {
        public Texture2D Texture = new Texture2D(20, 20);
        public VesselType Type;
        public bool Enabled = true;

        public Filter(string textureLink, VesselType type, bool enabled)
        {
            ToolbarControl.LoadImageFromFile(ref Texture, textureLink);

            Type = type;
            Enabled = enabled;
        }

        public String getName()
        {
            if (Type.Equals(VesselType.Debris))
                return Type + "/Other";
            return Type.ToString();
        }

        public bool MatchType(VesselType type, List<VesselType> vesselTypes)
        {
            if (Type.Equals(type))
                return true;
            if (Type.Equals(VesselType.Debris) && !vesselTypes.Contains(type))
                return true;
            return false;
        }

        public void toggle()
        {
            Enabled = !Enabled;
        }
    }

}
