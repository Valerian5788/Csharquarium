namespace Csharquarium.Classes
{
    internal class EtresVivant
    {
        public event Action<EtresVivant> AgeSurveillance;
        public event Action<EtresVivant> PvSurveillance;
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
                    PvSurveillance?.Invoke(this);
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
                if (age >= 20) { 
                    AgeSurveillance?.Invoke(this);
                    Pv = 0;
                }
            }
        }
        protected void RaiseMessageSurveillance(string message)
        {
            MessageSUrveillance?.Invoke(message);
        }
    }
}
