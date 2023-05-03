using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public static class AnimationEnumGenerator
{
    [MenuItem("Tools/CustomScripts/GenerateAnimationEnum %#&a")]
    private static void GenerateAnimationEnum()
    {
        var activeGameObject = Selection.activeGameObject;
        if (activeGameObject == null) return;
        if (activeGameObject.TryGetComponent<Animator>(out var animator) == false) return;
        var runtimeController = animator.runtimeAnimatorController;
        if (runtimeController == null) return;
        var controller =
            AssetDatabase.LoadAssetAtPath<AnimatorController>(AssetDatabase.GetAssetPath(runtimeController));
        if (controller == null) return;
        //check uppercase
        // var names = controller.GetAllStateNames();
        // var split = Regex.Split(names.First(), @"(?<!^)(?=[A-Z])");
        // Debug.Log(split[0]);
        EnumGenerator.GenerateEnum(controller.GetAllStateNames(), controller.name,
            "Assets/Game/Scripts/Enums/Animations/");
    }
}