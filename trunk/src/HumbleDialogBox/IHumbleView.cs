namespace HumbleDialogBox
{
    public interface IHumbleView
    {
        bool IsDirty();
        bool AskUserToDiscardChanges();
        void Close();
    }
}