using WPFArch.Data.CodeFirst.Models;

namespace WPFArch.Data.CodeFirst.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private WPFRealWorldContext _dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        protected WPFRealWorldContext DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }
}
