using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using HostFurnitureReset.Patches;

namespace HostFurnitureReset;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);
    public static ManualLogSource Log;

    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        Log = Logger;

        harmony.PatchAll(typeof(StartOfRoundPatch));
    }

}