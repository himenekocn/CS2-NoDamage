using System;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;

namespace NoDamage;

public class NoDamage : BasePlugin
{
    public override string ModuleAuthor => "sphaxa & himeneko";
    public override string ModuleName => "NoDamage";
    public override string ModuleVersion => "v1.0.0";

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventPlayerHurt>(OnPlayerHurt, HookMode.Pre);
    }

    private HookResult OnPlayerHurt(EventPlayerHurt @event, GameEventInfo info)
    {
        if (!@event.Userid.IsValid)
        {
            return HookResult.Continue;
        }

        CCSPlayerController player = @event.Userid;

        if (player.Connected != PlayerConnectedState.PlayerConnected)
        {
            return HookResult.Continue;
        }

        if (!player.PlayerPawn.IsValid)
        {
            return HookResult.Continue;
        }

        @event.Userid.PlayerPawn.Value.Health = 100;

        @event.Userid.PlayerPawn.Value.VelocityModifier = 1;

        return HookResult.Continue;
    }
}
