using HarmonyLib;
using UnityEngine;
using Unity.Netcode;

namespace HostFurnitureReset.Patches;

public class StartOfRoundPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Start")]
    public static void StartOfRunResetAllItems()
    {

        Plugin.Log.LogMessage("Reset all furniture now");

        if (!NetworkManager.Singleton.IsHost)
        {
            Plugin.Log.LogMessage("Player is not host, exit");
            return;
        }

        ShipBuildModeManager buildMan = GameObject.Find("Systems/GameSystems/ShipBuildMode").GetComponent<ShipBuildModeManager>();
        PlaceableShipObject[] items = GameObject.FindObjectsByType<PlaceableShipObject>(FindObjectsSortMode.None);

        foreach (var item in items)
        {
            //Plugin.Log.LogInfo($"Resetting {item.name}");
            buildMan.ResetShipObjectToDefaultPosition(item);
        }

        Plugin.Log.LogMessage("Reset all furniture done");
    }
}