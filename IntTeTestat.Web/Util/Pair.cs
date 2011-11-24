using System;

namespace IntTeTestat.Web.Util
{
    [Serializable]
    public class Pair
    {
        public Pair()
        {
        }

        public Pair(object first, object second)
        {
            this.First = first;
            this.Second = second;
        }

        public object First;
        public object Second;
    } ;
}