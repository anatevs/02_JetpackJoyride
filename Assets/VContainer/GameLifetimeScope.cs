using VContainer;
using VContainer.Unity;
using UnityEngine;
using GameCore;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private MovingSectionsController _movingSections;

    [SerializeField]
    private LeftScreenAlign _leftScreenAlign;

    protected override void Configure(IContainerBuilder builder)
    {
        RegisterGameplayObjects(builder);

        RegisterControllers(builder);
    }

    private void RegisterGameplayObjects(IContainerBuilder builder)
    {
        builder.RegisterComponent(_player)
            .AsImplementedInterfaces()
            .AsSelf();

        builder.RegisterComponent(_movingSections)
            .AsImplementedInterfaces()
            .AsSelf();
    }

    private void RegisterControllers(IContainerBuilder builder)
    {
        builder.RegisterComponent(_leftScreenAlign);
    }
}
