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

    [HarmonyPatch(nameof(FixedUpdate))]
    [HarmonyPostfix]
    private static void FixedUpdate(HeroController __instance)
    {
        if (!HeroNoClipController.Instance) return;
        var noClipController = HeroNoClipController.Instance;
        noClipController.FixVelocity();
    }

    private static bool ChangeCanTakeDamage(ref bool __result)
    {
        if (!HeroNoClipController.Instance) return true;
        var noClipController = HeroNoClipController.Instance;
        if (!noClipController.IsNoClip) return true;
        if (!Configs.Invincible) return true;
        __result = false;
        return false;
    }

    [HarmonyPatch(nameof(CanTakeDamage))]
    [HarmonyPrefix]
    private static bool CanTakeDamage(HeroController __instance, ref bool __result) =>
        ChangeCanTakeDamage(ref __result);

    [HarmonyPatch(nameof(CanTakeDamageIgnoreInvul))]
    [HarmonyPrefix]
    // ReSharper disable once IdentifierTypo
    private static bool CanTakeDamageIgnoreInvul(HeroController __instance, ref bool __result) =>
        ChangeCanTakeDamage(ref __result);
}