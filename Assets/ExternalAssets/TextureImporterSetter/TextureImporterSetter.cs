using System;
using System.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public static class TextureImporterSetter
{
    [MenuItem("Tools/CustomScripts/SetTextureSize %#t")]
    private static void SetTexturesSize()
    {
        if (TryGetTextureImporterSettings(out var importSettings) == false) return;

        foreach (var selected in Selection.objects)
        {
            if (selected is Texture2D == false)
            {
                Debug.Log(selected.name + " is not a texture");
                continue;
            }

            var texture2D = selected as Texture2D;
            var newSize = (int)math.pow(2, math.ceillog2(Math.Max(texture2D.height, texture2D.width)));
            var importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(selected)) as TextureImporter;
            if (importer == null) continue;
            importSettings.maxTextureSize = newSize;
            importer.SetPlatformTextureSettings(importSettings);
            importer.SaveAndReimport();
        }
    }

    private static bool TryGetTextureImporterSettings(out TextureImporterPlatformSettings platformSettings)
    {
        var selectedTexture = Selection.objects.FirstOrDefault(item => item is Texture2D);
        platformSettings = (AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(selectedTexture)) as TextureImporter)
            ?.GetDefaultPlatformTextureSettings();
        return selectedTexture != null;
    }
}