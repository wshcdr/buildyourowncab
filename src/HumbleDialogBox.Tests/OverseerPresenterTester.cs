using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace HumbleDialogBox.Tests
{
    [TestFixture]
    public class OverseerPresenterTester
    {
        private MockRepository mocks;
        private IHumbleView view;
                
        [SetUp]
        public void SetUpTest()
        {
            mocks = new MockRepository();
            view = mocks.CreateMock<IHumbleView>();
        }

        [Test]
        public void CloseTheScreenWhenTheScreenIsNotDirty()
        {

            using (mocks.Record())
            {
                Expect.Call(view.IsDirty()).Return(false);
                view.Close();
            }

            using (mocks.Playback())
            {
                OverseerPresenter presenter = new OverseerPresenter(view);
                presenter.Close();
            }
        }
        
        [Test]
        public void CloseTheScreenWhenTheScreenIsDirtyAndTheUserDecidesToDiscardTheChanges()
        {
            using (mocks.Record())
            {
                Expect.Call(view.IsDirty()).Return(true);
                Expect.Call(view.AskUserToDiscardChanges()).Return(true);
                view.Close();
            }

            using (mocks.Playback())
            {
                OverseerPresenter presenter = new OverseerPresenter(view);
                presenter.Close();
            }
        }
        
        [Test]
        public void CloseTheScreenWhenTheScreenIsDirtyAndTheUserDecidesNOTToDiscardTheChanges()
        {
            using (mocks.Record())
            {
                Expect.Call(view.IsDirty()).Return(true);
                Expect.Call(view.AskUserToDiscardChanges()).Return(false);

                // No call should be made to view.Close()
                // view.Close();
            }

            using (mocks.Playback())
            {
                OverseerPresenter presenter = new OverseerPresenter(view);
                presenter.Close();
            }
        }



    }
}
