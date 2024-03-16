// See https://aka.ms/new-console-template for more information

public class Program
{
    internal class KodeBuah
    {
        public enum Buah
        {
            Apel, Aprikot, Alpukat, Pisang, Paprika, Blackberry, Ceri, Kelapa, Jagung
        };

        public static String getKodeBuah(Buah buah)
        {
            String[] KodeBuah = { "A00", "B00", "C00", "D00", "E00", "F00", "H00", "I00", "J00" };
            return KodeBuah[(int)buah];
        }
    }

    private static void Main(String[] args)
    {
        KodeBuah buah = new KodeBuah();
    }
    
}