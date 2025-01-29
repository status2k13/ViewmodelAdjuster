using BepInEx;
using BepInEx.Configuration;
using Comfort.Common;
using EFT;

namespace ViewmodelAdjuster
{
    [BepInPlugin("com.meanw.viewmodeladjuster", "Viewmodel Adjuster", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static ConfigEntry<float> vmx;
        internal static ConfigEntry<float> vmy;
        internal static ConfigEntry<float> vmz;

        protected void Awake()
        {
            vmx = Config.Bind("MAIN", "VIEWMODEL_X", 0.04f, new ConfigDescription("", new AcceptableValueRange<float>(-0.1f, 0.1f)));
            vmy = Config.Bind("MAIN", "VIEWMODEL_Y", 0.04f, new ConfigDescription("", new AcceptableValueRange<float>(-0.1f, 0.1f)));
            vmz = Config.Bind("MAIN", "VIEWMODEL_Z", 0.05f, new ConfigDescription("", new AcceptableValueRange<float>(-0.1f, 0.1f)));
        }

        protected void Update()
        {
            var gameWorld = Singleton<GameWorld>.Instance;
            if (gameWorld?.RegisteredPlayers == null || gameWorld.MainPlayer?.ProceduralWeaponAnimation?.HandsContainer == null)
            {
                return;
            }

            gameWorld.MainPlayer.ProceduralWeaponAnimation.HandsContainer.CameraOffset.x = vmx.Value;
            gameWorld.MainPlayer.ProceduralWeaponAnimation.HandsContainer.CameraOffset.y = vmy.Value;
            gameWorld.MainPlayer.ProceduralWeaponAnimation.HandsContainer.CameraOffset.z = vmz.Value;
        }
    }
}
