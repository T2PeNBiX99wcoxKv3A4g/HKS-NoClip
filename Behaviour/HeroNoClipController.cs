using UnityEngine;

namespace HKS_NoClip.Behaviour;

public class HeroNoClipController : MonoBehaviour
{
    public HeroController? Controller { get; internal set; }

    private void Update()
    {
        if (!Controller) return;
        if (!Input.GetKeyDown(Main.NoClipToggleKey.Value())) return;
        ToggleNoClip();
        Utils.Logger.Info($"No Clip is now {(Controller.GetIsNoClip() ? "On" : "Off")}");
    }

    public void ToggleNoClip()
    {
        if (!Controller) return;
        if (Controller.GetIsNoClip())
        {
            Controller.col2d().V.enabled = true;
            Controller.playerData().V.isInvincible = false;
            Controller.playerData().V.infiniteAirJump = false;
            if (Controller.Body)
                Controller.Body.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            Controller.col2d().V.enabled = false;
            Controller.playerData().V.isInvincible = true;
            Controller.playerData().V.infiniteAirJump = true;
            if (Controller.Body)
                Controller.Body.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}