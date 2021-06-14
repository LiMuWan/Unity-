﻿using UnityEngine;
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
         AssetBundleBuild[] buildMap = new AssetBundleBuild[2];    //定义AssetBuild数组
         */
    }
}