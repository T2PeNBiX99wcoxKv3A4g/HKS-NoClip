using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace HKS_NoClip.EX;

public static class HeroControllerEX
{
    extension(HeroController instance)
    {
        [UsedImplicitly]
        public Rigidbody2D rb2d
        {
            get => Traverse.Create(instance).Field<Rigidbody2D>("rb2d").Value;
            set => Traverse.Create(instance).Field<Rigidbody2D>("rb2d").Value = value;
        }

        [UsedImplicitly]
        public Collider2D col2d
        {
            get => Traverse.Create(instance).Field<Collider2D>("col2d").Value;
            set => Traverse.Create(instance).Field<Collider2D>("col2d").Value = value;
        }

        [UsedImplicitly]
        public InputHandler inputHandler
        {
            get => Traverse.Create(instance).Field<InputHandler>("inputHandler").Value;
            set => Traverse.Create(instance).Field<InputHandler>("inputHandler").Value = value;
        }
    }
}