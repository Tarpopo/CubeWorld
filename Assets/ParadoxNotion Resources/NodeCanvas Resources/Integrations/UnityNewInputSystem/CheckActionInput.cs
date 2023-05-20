using UnityEngine;
using UnityEngine.InputSystem;
using ParadoxNotion.Design;
using ParadoxNotion;

namespace NodeCanvas.Tasks.Conditions
{
    [Category("Input (New System)")]
    [Description("Check if an input action is performed.")]
    public class CheckActionInput : NodeCanvas.Framework.ConditionTask
    {
        [RequiredField] public InputActionAsset inputActionAsset;
        [ShowIf(nameof(inputActionAsset), 1)] public PressTypes pressType = PressTypes.Down;
        [SerializeField] private string selectedActionID;

        private InputAction action;

        protected override string info
        {
            get
            {
                if (inputActionAsset == null)
                {
                    return "No InputActionAsset Assigned";
                }

                if (string.IsNullOrEmpty(selectedActionID))
                {
                    return "No InputAction Selected";
                }

                action = action != null ? action : inputActionAsset.FindAction(selectedActionID);
                if (action == null)
                {
                    return "Action can't be found";
                }

                return string.Format("Input {0} {1}", action.name, pressType);
            }
        }

        protected override string OnInit()
        {
            if (string.IsNullOrEmpty(selectedActionID))
            {
                return "No InputAction Selected";
            }

            action = inputActionAsset.FindAction(selectedActionID);
            if (action != null)
            {
                return null;
            }

            return "Input Action can not be resolved or is missing";
        }

        protected override bool OnCheck()
        {
            if (pressType == PressTypes.Down)
                return action.WasPerformedThisFrame();

            if (pressType == PressTypes.Up)
                return action.WasReleasedThisFrame();

            if (pressType == PressTypes.Pressed)
                return action.WasPressedThisFrame();
            return false;
        }

        ///----------------------------------------------------------------------------------------------
        ///---------------------------------------UNITY EDITOR-------------------------------------------
#if UNITY_EDITOR
        protected override void OnTaskInspectorGUI()
        {
            base.OnTaskInspectorGUI();
            if (inputActionAsset != null && GUILayout.Button("Select Input Action"))
            {
                var menu = new UnityEditor.GenericMenu();
                InputAction current = null;
                if (!string.IsNullOrEmpty(selectedActionID))
                {
                    current = inputActionAsset.FindAction(selectedActionID);
                }

                foreach (var map in inputActionAsset.actionMaps)
                {
                    foreach (var action in map.actions)
                    {
                        menu.AddItem(new GUIContent(map.name + "/" + action.name), current == action, () =>
                        {
                            UndoUtility.RecordObject(ownerSystem.contextObject, "Set Input Action");
                            selectedActionID = action.id.ToString();
                            this.action = null;
                        });
                    }
                }

                menu.ShowAsContext();
            }
        }
#endif
        ///----------------------------------------------------------------------------------------------
    }
}