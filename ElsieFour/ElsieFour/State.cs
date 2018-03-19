namespace ElsieFour
{
    public class State
    {
        public int[,] matrix = new int[6, 6];
        int i, j;
        public State(int[] key)
        {
            for(int i = 0; i < 36; i++)
            {
                matrix[i / 6, i % 6] = key[i];
            }
            i = 0;
            j = 0;
        }
    }
}
