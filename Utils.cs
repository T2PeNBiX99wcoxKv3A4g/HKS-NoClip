global using BepInExUtils.EX;
global using HKS_NoClip.EX;
using Logger = BepInExUtils.Logger;

namespace HKS_NoClip;

public static class Utils
{
    internal const string Guid = "io.github.ykysnk.HKS-NoClip";
    internal const string Name = "No Clip";
    internal const string Version = "0.1.0";
    internal const string GameName = "Hollow Knight Silksong.exe";

    private static Logger? _logger;
    public static Logger Logger => _logger ??= new(Name);
}