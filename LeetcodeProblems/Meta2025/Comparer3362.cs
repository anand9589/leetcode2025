namespace Meta2025
{
    internal class Comparer3362 : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x[0] == y[0])
            {
                int diff1 = x[1] - x[0];
                int diff2 = y[1] - y[0];

                return diff2 - diff1;
            }
            return x[0] - y[0];
        }
    }
    internal class Comparer33621 : IComparer<(int l, int r)>
    {
        public int Compare((int l, int r) x, (int l, int r) y)
        {
            if(x.l == y.l)
            {
                return x.r - y.r;
            }
            return x.l - y.l;
        }
    }
}
