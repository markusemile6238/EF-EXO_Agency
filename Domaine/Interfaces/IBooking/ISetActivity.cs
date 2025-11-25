using Domaine.Model;

namespace Domaine.Interfaces.IBooking
{
    public interface ISetActivity
    {
        IWithAnotherActivity SetActivity(Model.Activity activity);
        IBuildBooking Build();
     }
}