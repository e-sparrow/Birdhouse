namespace Birdhouse.Tools.Inputs.Buttons.Abstractions
{
    public interface IButtonService<in TButton>
    {
        bool GetButtonDown(TButton button);
        bool GetButton(TButton button);
        bool GetButtonUp(TButton button);
    }
}