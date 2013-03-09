using WPFArch.Data.CodeFirst.Infrastructure;
using WPFArch.Data.CodeFirst.Models;

namespace WPFArch.Data.CodeFirst.Infrastructure
{
    public abstract class RepositoryBase
    {
        private WPFRealWorldContext _dataContext;
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }
        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }
        protected WPFRealWorldContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }
    }
}
