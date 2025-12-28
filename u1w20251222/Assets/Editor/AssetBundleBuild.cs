using UnityEngine;
using System.IO;
using UnityEditor;

namespace BuildAsset
{
    public class AssetBundle
    {   
        public static void BuildABs()
        {
            AssetBundleBuild[] buildMap = new AssetBundleBuild[1];

            string[] AssetNames = new string[1];
            AssetNames[0] = "Assets/AddressableAssets/Effect/Hit/Hit_01.prefab";

            buildMap[0].assetNames = AssetNames;
            buildMap[0].assetBundleName = "Hit";

            string outputPath = "Assets/AssetBundle/WebGL";
            if( !Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            BuildPipeline.BuildAssetBundles(outputPath, buildMap, BuildAssetBundleOptions.None, BuildTarget.WebGL);
        }
    }
}
