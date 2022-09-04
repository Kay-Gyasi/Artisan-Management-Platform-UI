using System;

namespace AMP.Web.Models.Stores.Base
{
    public class StoreBase
    {
        
        #region observer pattern

        private Action _listeners;

        public void AddStateChangeListener(Action listener)
        {
            _listeners += listener;
        }

        public void RemoveStateChangeListener(Action listener)
        {
            _listeners -= listener;
        }

        protected void BroadcastStateChange()
        {
            if (_listeners == null) return;
            _listeners.Invoke();
        }

        #endregion
    }
}
