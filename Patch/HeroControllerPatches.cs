using HarmonyLib;
using HKS_NoClip.Behaviour;

// ReSharper disable InconsistentNaming

namespace HKS_NoClip.Patch;

[HarmonyPatch(typeof(HeroController))]
internal class HeroControllerPatches
{
    [HarmonyPatch(nameof(Awake))]
    [HarmonyPrefix]
    private static void Awake(HeroController __instance)
    {
        Utils.Logger.Debug($"__instance {__instance}");
        var controller = !__instance.gameObject.TryGetComponent<HeroNoClipController>(out var getController)
            ? __instance.gameObject.AddComponent<HeroNoClipController>()
            : getController;
        Utils.Logger.Debug($"controller {controller}");
        controller.Controller = __instance;
    }
}