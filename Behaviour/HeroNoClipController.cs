using UnityEngine;

namespace HKS_NoClip.Behaviour;

public class HeroNoClipController : MonoBehaviour
{
    private bool _holdChangeNoClip;
    private bool _isHold;
    private bool _isSetNoClip;
    private Vector2? _lastVelocity;

    private float _needTime;
    public HeroController? Controller { get; internal set; }
    public static HeroNoClipController? Instance { get; private set; }

    internal bool IsNoClip { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!Controller) return;
        HandleNoClip();
        QuickToggleNoClip();
        if (!Input.GetKeyDown(Main.NoClipToggleKey.Value())) return;
        ToggleNoClip();
        Utils.Logger.Info($"No Clip is now {(IsNoClip ? "On" : "Off")}");
    }

    private void FixedUpdate()
    {
        if (!Controller) return;
        FixBodyType();
    }

    private void QuickToggleNoClip()
    {
        if (!Main.QuickToggleNoClip.Value()) return;
        if (!Controller) return;
        var inputHandler = Controller.inputHandler().V;
        if (!inputHandler) return;
        if ((!IsNoClip && (!inputHandler.inputActions.Jump.IsPressed || !inputHandler.inputActions.Up.IsPressed)) ||
            (IsNoClip && !inputHandler.inputActions.Jump.IsPressed))
        {
            _needTime = -1;
            _isHold = false;
            _isSetNoClip = false;
            return;
        }

        if (!_isHold)
            _holdChangeNoClip = !IsNoClip;
        _isHold = true;
        if (_needTime < 0)
            _needTime = Time.time + Main.QuickToggleNoClipWaitTime.Value();

        // Utils.Logger.Debug($"_needTime {_needTime}, Time.time {Time.time}");

        if (_needTime < 0 || Time.time < _needTime || _isSetNoClip) return;
        ToggleNoClip(_holdChangeNoClip);
        Utils.Logger.Info($"No Clip is now {(IsNoClip ? "On" : "Off")}");
        _isSetNoClip = true;
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

        IsNoClip = value;
    }

    private void ToggleNoClip()
    {
        ToggleNoClip(!IsNoClip);
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