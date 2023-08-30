namespace Csharquarium.Classes
{
    internal class EtresVivant
    {
        public event Action<int> AgeSurveillance;
        public event Action<int> PvSurveillance;
        public event Action<string> MessageSUrveillance;

        private int _pv = 10;
        public int Pv
        {
            get { return _pv; }
            set
            {
                _pv = value;
                if (_pv <= 0)
                {
                    PvSurveillance?.Invoke(_pv);
                }
            }
        }
        private int _age = 0;
        public int age
        {
            get { return _age; }
            set
            {
                _age = value;
                if (age >= 20) { AgeSurveillance?.Invoke(_age); }
            }
        }
        protected void RaiseMessageSurveillance(string message)
        {
            MessageSUrveillance?.Invoke(message);
        }
    }
}
