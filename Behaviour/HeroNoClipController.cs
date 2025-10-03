using UnityEngine;

namespace HKS_NoClip.Behaviour;

public class HeroNoClipController : MonoBehaviour
{
    public HeroController? Controller { get; internal set; }
    public static HeroNoClipController? Instance { get; private set; }
    private Vector2? _lastVelocity;

    internal bool IsNoClip { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!Controller) return;
        HandleNoClip();
        if (!Input.GetKeyDown(Main.NoClipToggleKey.Value())) return;
        ToggleNoClip();
        Utils.Logger.Info($"No Clip is now {(Controller.GetIsNoClip() ? "On" : "Off")}");
    }

    private void FixedUpdate()
    {
        if (!Controller) return;
        FixBodyType();
    }

    private void ToggleNoClip(bool value)
    {
        if (!Controller) return;
        if (value)
        {
            if (Main.TurnOffCol2d.Value())
                Controller.col2d().V.enabled = false;
            if (Controller.Body)
                Controller.Body.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            if (!Controller.col2d().V.enabled)
                Controller.col2d().V.enabled = true;
            if (Controller.Body)
                Controller.Body.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void ToggleNoClip()
    {
        IsNoClip = !IsNoClip;
        ToggleNoClip(IsNoClip);
    }

    private void HandleNoClip()
    {
        if (!Controller || !IsNoClip) return;
        var inputHandler = Controller.inputHandler().V;
        if (!inputHandler) return;
        var vel = Vector2.zero;
        var inputVel = inputHandler.inputActions.MoveVector.Vector;

        vel += inputVel * Main.Speed.Value();

        if (inputHandler.inputActions.Dash.IsPressed)
            vel *= 2f;

        Controller.Body.linearVelocity = vel;
        _lastVelocity = vel;
    }

    private void FixBodyType()
    {
        if (!Controller || !IsNoClip) return;
        if (Controller.Body && Controller.Body.bodyType != RigidbodyType2D.Kinematic)
            Controller.Body.bodyType = RigidbodyType2D.Kinematic;
    }

    internal void FixVelocity()
    {
        if (!Controller || !IsNoClip || !_lastVelocity.HasValue) return;
        Controller.Body.linearVelocity = _lastVelocity ?? Vector2.zero;
    }
}