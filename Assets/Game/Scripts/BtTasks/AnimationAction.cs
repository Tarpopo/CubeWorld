using System;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class AnimationAction : ActionTask
{
    public BBParameter<AnimationComponent> animationComponent;
    [SerializeField] private string _animation = string.Empty;

    protected override string info => $"{_animation} Animation";

    protected override void OnExecute()
    {
        animationComponent.value.PlayAnimation(_animation);
        EndAction(true);
    }

#if UNITY_EDITOR
    protected override void OnTaskInspectorGUI()
    {
        base.OnTaskInspectorGUI();
        if (animationComponent.value != null && animationComponent.value.Animations != null &&
            GUILayout.Button("SelectEnum"))
        {
            var menu = new UnityEditor.GenericMenu();
            foreach (var animation in Enum.GetNames(animationComponent.value.Animations.GetType()))
            {
                menu.AddItem(new GUIContent(animation), _animation.Equals(animation), () =>
                {
                    UndoUtility.RecordObject(ownerSystem.contextObject, "Set Input Action");
                    _animation = animation;
                });
            }

            menu.ShowAsContext();
        }
#endif
    }
}