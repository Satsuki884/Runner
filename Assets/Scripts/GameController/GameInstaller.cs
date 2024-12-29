using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameController gameController;// = FindObjectOfType<GameController>();
    [SerializeField] private SaveManager saveManager;// = FindObjectOfType<SaveManager>();
    public override void InstallBindings()
    {
        // [SerializeField] private GameController gameController;// = FindObjectOfType<GameController>();
        Container.Bind<GameController>().FromInstance(gameController).AsSingle().NonLazy();

        // SaveManager saveController = FindObjectOfType<SaveManager>();
        Container.Bind<SaveManager>().FromInstance(saveManager).AsSingle().NonLazy();
    }
}