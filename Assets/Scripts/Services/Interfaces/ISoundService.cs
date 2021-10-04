using ESparrow.Utils.Enums;

namespace ESparrow.Utils.Services.Interfaces
{
    public interface ISoundService
    {
        void PlayToStop(string name);
        void PlayFor(string name, float duration, ESoundVolumeType type);
        void PlayOneShot(string name, ESoundVolumeType type);

        void Stop(string name);
    }
}
    