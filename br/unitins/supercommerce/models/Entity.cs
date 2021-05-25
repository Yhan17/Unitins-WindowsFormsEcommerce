using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.models
{
    public class Entity<T>: IEquatable<T>, ICloneable
    {
        private int _id;

        public int ID {
            get => _id;
            set => _id = value;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public bool Equals(T other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }
            else
            {
                T p = other;
                return (p.Equals(this));
            }
        }
    }
}
