namespace HumbleDialogBox
{
    public class OverseerPresenter
    {
        private readonly IHumbleView _view;
        public OverseerPresenter(IHumbleView view)
        {
            _view = view;
        }

        public void Close()
        {
            bool canClose = true;
            if (_view.IsDirty())
            {
                canClose = _view.AskUserToDiscardChanges();
            }

            if (canClose)
            {
                _view.Close();
            }
        }
    }
}