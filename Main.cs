using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace HKS_NoClip;

[BepInPlugin(Utils.Guid, Utils.Name, Utils.Version)]
[BepInProcess(Utils.GameName)]
public class Main : BaseUnityPlugin
{
    private readonly Harmony _harmony = new(Utils.Guid);

    internal static ConfigEntry<KeyCode>? NoClipToggleKey;
    internal static ConfigEntry<bool>? TurnOffCol2d;
    internal static ConfigEntry<bool>? Invincible;
    internal static ConfigEntry<bool>? QuickToggleNoClip;
    internal static ConfigEntry<float>? Speed;
    internal static ConfigEntry<float>? QuickToggleNoClipWaitTime;

    private const string SectionOptions = "Options";

    private void Awake()
    {
        Utils.Logger.Info($"Plugin {Utils.Name} loaded, version {Utils.Version}");
        _harmony.PatchAll(Assembly.GetExecutingAssembly());

        NoClipToggleKey = Config.Bind(SectionOptions, nameof(NoClipToggleKey), KeyCode.B,
            "The key to toggle noclip in game.");
        TurnOffCol2d = Config.Bind(SectionOptions, nameof(TurnOffCol2d), false,
            "Turn off player collider when noclip is on. (If collider is on may cause some issues)");
        Invincible = Config.Bind(SectionOptions, nameof(Invincible), false,
            "Make player invincible when noclip is on.");
        QuickToggleNoClip = Config.Bind(SectionOptions, nameof(QuickToggleNoClip), true,
            "Quickly toggle noclip by keep holding jump key and up arrow key.");
        Speed = Config.Bind(SectionOptions, nameof(Speed), 30f,
            "The speed of the player in noclip.");
        QuickToggleNoClipWaitTime = Config.Bind(SectionOptions, nameof(QuickToggleNoClipWaitTime), 2f,
            "The holding time need to quick toggle noclip.");
    }
}