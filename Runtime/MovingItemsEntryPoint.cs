
using System.Threading.Tasks;
using com.appidea.MiniGamePlatform.CommunicationAPI;
using UnityEngine;

public class MovingItemsEntryPoint : BaseMiniGameEntryPoint
{
    [SerializeField] private GameObject gamePrefab;
    protected override Task LoadInternal()
    {
        var gameManager = Instantiate(gamePrefab);
        gameManager.GetComponentInChildren<GameManagerScript>().SetEntryPoint(this);
        return Task.CompletedTask;
    }

    protected override Task UnloadInternal()
    {
        return Task.CompletedTask;
    }
}