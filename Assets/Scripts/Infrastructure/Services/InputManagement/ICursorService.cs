namespace Infrastructure.Services.InputManagement
{
    public interface ICursorService
    {
        void LockCursor();
        void UnlockCursor();
    }
}