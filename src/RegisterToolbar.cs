using UnityEngine;
using ToolbarControl_NS;
//using KSP_Log;

namespace Targetron
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class RegisterToolbar : MonoBehaviour
    {
        bool initted = false;

#if false
         internal static Log Log = null;
       void Awake()
        {
            if (Log == null)
#if DEBUG
                Log = new Log("Targetron", Log.LEVEL.INFO);
#else
          Log = new Log("Targetron", Log.LEVEL.ERROR);
#endif

        }
#endif

        void Awake()
        {
            Targetron.DoAwake();
        }

        void Start()
        {
            ToolbarControl.RegisterMod(Targetron.MODID, Targetron.MODNAME);
        }

        void OnGUI()
        {
            if (!initted)
            {
                initted = true;
                Targetron.initStyles();
            }
        }
    }
}
