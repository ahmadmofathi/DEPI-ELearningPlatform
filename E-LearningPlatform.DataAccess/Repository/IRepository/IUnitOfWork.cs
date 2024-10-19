namespace E_LearningPlatform.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEnrollmentRepository  Enrollment{ get; }
        IRequestRepository Request{ get; }
        IProgressRepository Progress{ get; }
        ICourse Course { get; }
        ICategory Category { get; }
        IVideo Video { get; }
        void Save();
    }
}
