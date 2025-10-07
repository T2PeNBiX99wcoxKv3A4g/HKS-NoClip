using BepInExUtils.Attributes;
using JetBrains.Annotations;
using UnityEngine;

namespace HKS_NoClip.Extensions;

[AccessExtensions]
[AccessInstance<HeroController>]
[AccessField<Rigidbody2D>("rb2d")]
[AccessField<Collider2D>("col2d")]
[AccessField<InputHandler>("inputHandler")]
[UsedImplicitly]
public static partial class HeroControllerExtensions
{
}