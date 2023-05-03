using System;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class AnimationAction : ActionTask<AnimationComponent>
{
    [SerializeField] private string _animation = string.Empty;

    protected override string info => $"{_animation} Animation";

    protected override void OnExecute()
    {
        agent.PlayAnimation(_animation);
        EndAction(true);
    }

#if UNITY_EDITOR
    protected override void OnTaskInspectorGUI()
    {
        base.OnTaskInspectorGUI();
        if (agent.Animations != null && GUILayout.Button("SelectEnum"))
        {
            var menu = new UnityEditor.GenericMenu();
            foreach (var animation in Enum.GetNames(agent.Animations.GetType()))
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