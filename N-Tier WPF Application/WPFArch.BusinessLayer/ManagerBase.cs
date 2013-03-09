using WPFArch.Data.CodeFirst.Infrastructure;

namespace WPFArch.BusinessLayer
{
    public abstract class ManagerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        protected ManagerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected  void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}