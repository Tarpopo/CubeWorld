using NodeCanvas.Framework;
using ParadoxNotion.Design;

public class CameraVisibleTask : ConditionTask
{
    [RequiredField] public BBParameter<ICameraVisibleCheck> visibleCheck;

    protected override bool OnCheck() => visibleCheck.value.Visible;
}