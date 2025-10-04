# Hollow Knight: Silksong NoClip

Very simple mod press `b` key toggle noclip  
Compatible with controller

## Controls

* Toggle noclip by pressing `b` key by default.
* Move in any direction by pressing arrow keys.
* Pressing the dash key speedup.
* Quickly toggle noclip by holding jump key and up arrow key in 2 seconds, then turn off noclip by holding jump key in 2
  seconds. you need `QuickToggleNoClip` config to be enabled.

## Installation

1. Download [BepInEx](https://github.com/BepInEx/BepInEx)
   and [install](https://docs.bepinex.dev/articles/user_guide/installation/index.html).
2. Download [BepinEx-Utils](https://github.com/T2PeNBiX99wcoxKv3A4g/BepinEx-Utils/releases/latest).
3. Extract all the .dll file to `game folder/BepInEx/plugins`
4. Launch game

## Configuration

The mod configuration file name is `io.github.ykysnk.HKS-NoClip.cfg` inside `game folder/BepInEx/config`,
If you are not using any mod manager, you can manually change the value, also if you
installed [BepinEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager), you can change any
values in game instead.

* `NoClipToggleKey` Default `B` - The key to toggle noclip in game.
* `TurnOffCol2d` Default `false` - Turn off player collider when noclip is on. (If collider is on may cause some issues)
* `Invincible` Default `false` - Make player invincible when noclip is on.
* `QuickToggleNoClip` Default `true` - Quickly toggle noclip by keep holding jump key and up arrow key.
* `Speed` Default `30` - The speed of the player in noclip.
* `QuickToggleNoClipWaitTime` Default `2` - The holding time need to quick toggle noclip.