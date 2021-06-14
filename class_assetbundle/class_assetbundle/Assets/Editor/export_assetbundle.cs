using UnityEngine;
using System.Collections;
using UnityEditor;

public class export_assetbundle : Editor {
    [MenuItem("build/build_assetbundle")]
    static void run() { 
        // 调用函数来打包asset bundle;
        // 输出路径: "Assets/AssetBundles", 手动创建好
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        // end 

        /*
         AssetBundleBuild[] buildMap = new AssetBundleBuild[2];    //定义AssetBuild数组        buildMap[0].assetBundleName = "resources";                //打包的资源包名称，开发者可以随便命名        string[] resourcesAssets = new string[2];                  //定义字符串，用来记录此资源包文件名称        resourcesAssets[0] = "resources/1.prefab";                 //将需要打包的资源名称赋给数组        resourcesAssets[1] = "resources/MainO.cs";        buildMap[0].assetNames = resourcesAssets;                  //将资源名称数组赋给AssetBuild           BuildPipeline.BuildAssetBundles("Assets/AssetBundles", buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64)
         */
    }
}
