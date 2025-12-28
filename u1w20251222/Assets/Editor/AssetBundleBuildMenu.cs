using UnityEngine;
using BuildAsset;
using UnityEditor;

public class AssetBundleBuildMenu
{
    // AddressableAssetのGroupからビルドができるためいらない。
    [MenuItem("Build/Build Asset Bundles")]
    private static void StartAssetBundleBuild()
    {
        BuildAsset.AssetBundle.BuildABs();
    }
}
