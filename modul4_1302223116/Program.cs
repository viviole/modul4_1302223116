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

    public enum characterState { Jongkok, Berdiri, Tengkurap, Terbang};
    public enum characterTrigger { tombolW, tombolS};

    class PosisiKarakterGame
    {
        public characterState currentState = characterState.Berdiri;
        public class Movement
        {
            public characterState currentState;
            public characterState finalState;
            public characterTrigger trigger;

            public Movement(characterState currentState, characterState finalState, characterTrigger trigger)
            {
                this.currentState = currentState;
                this.finalState = finalState;
                this.trigger = trigger;
            }
        }

        Movement[] transisi =
        {
            new Movement(characterState.Berdiri, characterState.Terbang, characterTrigger.tombolW),
            new Movement(characterState.Berdiri, characterState.Jongkok, characterTrigger.tombolS),
            new Movement(characterState.Jongkok, characterState.Tengkurap, characterTrigger.tombolS),
            new Movement(characterState.Jongkok, characterState.Berdiri, characterTrigger.tombolW),
            new Movement(characterState.Tengkurap, characterState.Jongkok, characterTrigger.tombolW),
            new Movement(characterState.Terbang, characterState.Berdiri, characterTrigger.tombolS)
        };

        private characterState getNextState(characterState currentState, characterTrigger trigger)
        {
            characterState finalState = currentState;
            for (int i = 0; i < transisi.Length; i++)
            {
                Movement perubahan = transisi[i];
                if (currentState == perubahan.currentState && trigger == perubahan.trigger)
                {
                    finalState = perubahan.finalState;

                }
            }
            return finalState;
        }

        public void ActivateTrigger(characterTrigger trigger)
        {
            currentState = getNextState(currentState, trigger);
            if (trigger == characterTrigger.tombolW)
            {
                Console.WriteLine("tombol arah atas ditekan");
            }
            else if (trigger == characterTrigger.tombolS)
            {
                Console.WriteLine("Tombol arah bawah ditekan");
            }
            Console.WriteLine("Kondisi karakter saat ini adalah " + currentState);
            Console.WriteLine("");
            
        }
    }


    private static void Main(String[] args)
    {
        string input = "";
        KodeBuah buah = new KodeBuah();
        PosisiKarakterGame posisiKarakterGame = new PosisiKarakterGame();
        Console.WriteLine("Posisi awal: " + posisiKarakterGame.currentState);
        Console.WriteLine("");

        Console.WriteLine("Tekan S atau W");
       
        for (int i = 0; i < 4; i++)
        {
            input = Console.ReadLine();
            if (input == "w")
            {
                posisiKarakterGame.ActivateTrigger(characterTrigger.tombolW);
            }
            else if (input == "s")
            {
                posisiKarakterGame.ActivateTrigger(characterTrigger.tombolS);
            }
            else
            {
                Console.WriteLine("Input tidak sesuai");
            }
        }
    }
    
}