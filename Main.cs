using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace HKS_NoClip;

[BepInPlugin(Utils.Guid, Utils.Name, Utils.Version)]
public class Main : BaseUnityPlugin
{
    private readonly Harmony _harmony = new(Utils.Guid);

    internal static ConfigEntry<KeyCode>? NoClipToggleKey;

    private const string SectionOptions = "Options";

    private void Awake()
    {
        Utils.Logger.Info($"Plugin {Utils.Name} loaded, version {Utils.Version}");
        _harmony.PatchAll(Assembly.GetExecutingAssembly());

        NoClipToggleKey = Config.Bind(SectionOptions, nameof(NoClipToggleKey), KeyCode.B,
            "The key to toggle noclip in game.");
    }
}