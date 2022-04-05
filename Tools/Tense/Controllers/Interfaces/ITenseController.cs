namespace ESparrow.Utils.Tools.Tense.Controllers.Interfaces
{
    public interface ITenseController<out TTense>
    {
        TTense Now();
    }
}
