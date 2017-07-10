using BusinessLayer.Interfaces;

namespace BusinessLayer.UnitOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        public IUserBusinessObject UserBussinesObject { get; }

        public UserUnitOfWork(IUserBusinessObject _userBusinessObject)
        {
            UserBussinesObject = _userBusinessObject;
        }
    }
}