using Domaine.Model;

namespace Domaine.Interfaces.IBooking
{
    public interface IWithAnotherActivity
    {
        IWithAnotherActivity SetActivity(Model.Activity activity);
        IBuildBooking Build();
    }
}