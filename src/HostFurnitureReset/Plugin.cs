using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using HostFurnitureReset.Patches;

namespace HostFurnitureReset;

[BepInPlugin(LCMPluginInfo.PLUGIN_GUID, LCMPluginInfo.PLUGIN_NAME, LCMPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private readonly Harmony harmony = new(LCMPluginInfo.PLUGIN_GUID);
    public static ManualLogSource Log;

    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo($"Plugin {LCMPluginInfo.PLUGIN_GUID} is loaded!");
        Log = Logger;

        harmony.PatchAll(typeof(StartOfRoundPatch));
    }

}
