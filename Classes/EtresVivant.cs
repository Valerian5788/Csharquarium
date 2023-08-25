using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(_pv <= 0)
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
        //protected void MourirPoisson(Poisson poisson, List<Poisson> poissons)
        //{
        //       poissons.Remove(poisson);
        //       Console.WriteLine($"{poisson.Name} est mort de vieillesse, Paix à son ame");
        //}
        //protected void MourirAlgue(Algues algue, List<Algues> algues)
        //{
        //        algues.Remove(algue);
        //        Console.WriteLine($"Ironie du sort, une Algue vient de mourir de vieillesse");
        //}
        //protected void MourirAlgueMange(Algues algue, List<Algues> algues)
        //{
        //    algues.Remove(algue);
        //    Console.WriteLine($"Ironie du sort, une Algue vient de se faire manger");
        //}  
        //protected virtual void OnAgeSurveillance(Poisson poisson)
        //{
        //    AgeSurveillance.Invoke($"Le poisson {poisson.Name} à atteint l'age de 20 ans, il meurt");
        //}

        protected void RaiseMessageSurveillance(string message)
        {
            MessageSUrveillance?.Invoke(message);
        }
    }
}
