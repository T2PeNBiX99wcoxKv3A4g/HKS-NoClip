using HarmonyLib;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace HKS_NoClip.EX;

public static class HeroControllerEX
{
    public static TraverseEX<Rigidbody2D> rb2d(this HeroController instance) =>
        new(Traverse.Create(instance).Field<Rigidbody2D>(nameof(rb2d)));

    public static TraverseEX<Collider2D> col2d(this HeroController instance) =>
        new(Traverse.Create(instance).Field<Collider2D>(nameof(col2d)));

    public static TraverseEX<PlayerData> playerData(this HeroController instance) =>
        new(Traverse.Create(instance).Field<PlayerData>(nameof(playerData)));
}