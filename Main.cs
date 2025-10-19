using BepInEx;
using BepInExUtils.Attributes;
using UnityEngine;

namespace HKS_NoClip;

[BepInUtils("io.github.ykysnk.HKS-NoClip", "No Clip", Version)]
[BepInDependency("io.github.ykysnk.BepinExUtils", "1.0.0")]
[BepInProcess(Utils.GameName)]
[ConfigBind<KeyCode>("NoClipToggleKey", SectionOptions, KeyCode.B, "The key to toggle noclip in the game.")]
[ConfigBind<bool>("TurnOffCol2d", SectionOptions, false,
    "Turn off player collider when noclip is on. (If collider is on may cause some issues).")]
[ConfigBind<bool>("Invincible", SectionOptions, false, "Make the player invincible when noclip is on.")]
[ConfigBind<bool>("QuickToggleNoClip", SectionOptions, true,
    "Quickly toggle noclip by keep holding jump key and up arrow key.")]
[ConfigBind<bool>("FixFromOldVersion", SectionOptions, true, "If upgrade from old version, fix the save data issues.")]
[ConfigBind<float>("Speed", SectionOptions, 30f, "The speed of the player in noclip.")]
[ConfigBind<float>("QuickToggleNoClipWaitTime", SectionOptions, 2f, "The holding time needs to quickly toggle noclip.")]
public partial class Main
{
    private const string SectionOptions = "Options";
    private const string Version = "0.2.23";

    public void Init()
    {
    }
}