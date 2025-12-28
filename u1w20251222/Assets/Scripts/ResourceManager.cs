using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.AddressableAssets;

public interface IResourceManager
{
    void LoadAsync<T>(string path, Action<T> finishCallback);
    void Unload(GameObject obj);
}

public class ResourceManager : IResourceManager
{
    public void LoadAsync<T>(string path, Action<T> finishCallback)
    {
        Load<T>(path, (obj) => 
        {
            finishCallback(obj);
        }).Forget();
    }

    public async UniTask Load<T> (string path, Action<T> finishCallback)
    {
        var handle = Addressables.LoadAssetAsync<T>(path);
        await handle;
        T obj = handle.Result;
        finishCallback(obj);
    }

    public void Unload(GameObject obj)
    {
        Addressables.ReleaseInstance(obj);
    }

}
