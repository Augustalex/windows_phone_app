namespace Laboration_3
{
    public class GlobalClass
    {
        private static int ROOMIDCOUNTER = 0;

        public static void IncrementRoomId()
        {
            ROOMIDCOUNTER++;
        }

        public static int GetNextId()
        {
            IncrementRoomId();
            return ROOMIDCOUNTER;
        }
        
    }
}
