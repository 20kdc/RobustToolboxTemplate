﻿using Content.Client.GameObjects.Components;
using JetBrains.Annotations;
using Robust.Client.Player;
using Robust.Shared.GameObjects.Systems;
using Robust.Shared.IoC;

namespace Content.Client.GameObjects.EntitySystems
{
    [UsedImplicitly]
    public class PlayerKinesisSystem : EntitySystem
    {
        [Dependency] private IPlayerManager _playerManager = default!;

        public override void Update(float frameTime)
        {
            base.Update(frameTime);

            var target = _playerManager.LocalPlayer?.ControlledEntity;
            if (target == null)
                return;

            if (target.TryGetComponent<PlayerBrushComponent>(out var brush))
                brush.Update();
        }
    }
}
